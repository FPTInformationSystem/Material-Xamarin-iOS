// MIT/X11 License
//
// Menu.cs
//
// Author:
//       Pham Quan <QuanP@fpt.com.vn, mr.pquan@gmail.com> at FPT Software Service Center.
//
// Copyright (c) 2016 FPT Information System.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using CoreGraphics;
using UIKit;

namespace FPT.Framework.iOS.Material
{

	public enum MenuDirection { Up, Down, Left, Right }

	public class Menu
	{

		#region PROPERTOES

		/// A Boolean that indicates if the menu is open or not.
		public bool Opened { get; private set; } = false;

		/// The rectangular bounds that the menu animates.
		private CGPoint mOrigin;
		public CGPoint Origin
		{
			get
			{
				return mOrigin;
			}
			set
			{
				mOrigin = value;
				ReloadLayout();
			}
		}

		/// A preset wrapper around spacing.
		private MaterialSpacing mSpacingPreset = MaterialSpacing.None;
		public MaterialSpacing SpacingPreset
		{
			get
			{
				return mSpacingPreset;
			}
			set
			{
				mSpacingPreset = value;
				mSpacing = Convert.MaterialSpacingToValue(value);
			}
		}

		/// The space between views.
		private nfloat mSpacing;
		public nfloat Spacing
		{
			get
			{
				return mSpacing;
			}
			set
			{
				mSpacing = value;
				ReloadLayout();
			}
		}

		/// Enables the animations for the Menu.
		public bool Enabled { get; set; } = true;

		/// The direction in which the animation opens the menu.
		private MenuDirection mDirection = MenuDirection.Up;
		public MenuDirection Direction
		{
			get
			{
				return mDirection;
			}
			set
			{
				mDirection = value;
				ReloadLayout();
			}
		}

		/// An Array of UIViews.
		private UIView[] mViews;
		public UIView[] Views
		{
			get
			{
				return mViews;
			}
			set
			{
				mViews = value;
				ReloadLayout();
			}
		}

		/// Size of views, not including the first view.
		public CGSize ItemSize { get; set; } = new CGSize(48, 48);

		/// An Optional base view size.
		public CGSize? BaseSize { get; set; }

		#endregion

		#region CONSTRUCTORS

		/**
		Initializer.
		- Parameter origin: The origin position of the Menu.
		- Parameter spacing: The spacing size between views.
		*/
		public Menu(CGPoint origin, nfloat spacing)
		{
			this.Origin = origin;
			this.Spacing = spacing;
		}

		public Menu(CGPoint origin, MaterialSpacing spacingPreset = MaterialSpacing.Spacing3)
		{
			this.Origin = origin;
			this.SpacingPreset = spacingPreset;
		}

		/// Convenience initializer.
		public Menu() : this(CGPoint.Empty)
		{
		}

		#endregion

		#region FUNCTIONS

		/// Reload the view layout.
		public void ReloadLayout()
		{
			Opened = false;
			layoutButtons();
		}

		/**
		Open the Menu component with animation options.
		- Parameter duration: The time for each view's animation.
		- Parameter delay: A delay time for each view's animation.
		- Parameter usingSpringWithDamping: A damping ratio for the animation.
		- Parameter initialSpringVelocity: The initial velocity for the animation.
		- Parameter options: Options to pass to the animation.
		- Parameter animations: An animation block to execute on each view's animation.
		- Parameter completion: A completion block to execute on each view's animation.
		*/
		public void Open(double duration = 0.15, double delay = 0, nfloat? usingSpringWithDamping = null, nfloat initialSpringVelocity = default(nfloat), UIViewAnimationOptions options = default(UIViewAnimationOptions), Action<UIView> animations = null, Action<UIView> completion = null)
		{
			usingSpringWithDamping = usingSpringWithDamping ?? 0.5f;
			if (Enabled)
			{
				disable();
				switch (Direction)
				{
					case MenuDirection.Up:
						{
							openUpAnimation(duration, delay, usingSpringWithDamping.Value, initialSpringVelocity, options, animations, completion);
						}
						break;
					case MenuDirection.Down:
						{
							openDownAnimation(duration, delay, usingSpringWithDamping.Value, initialSpringVelocity, options, animations, completion);
						}
						break;
					case MenuDirection.Left:
						{
							openLeftAnimation(duration, delay, usingSpringWithDamping.Value, initialSpringVelocity, options, animations, completion);
						}
						break;
					case MenuDirection.Right:
						{
							openRightAnimation(duration, delay, usingSpringWithDamping.Value, initialSpringVelocity, options, animations, completion);
						}
						break;
				}
			}
		}

		/**
		Close the Menu component with animation options.
		- Parameter duration: The time for each view's animation.
		- Parameter delay: A delay time for each view's animation.
		- Parameter usingSpringWithDamping: A damping ratio for the animation.
		- Parameter initialSpringVelocity: The initial velocity for the animation.
		- Parameter options: Options to pass to the animation.
		- Parameter animations: An animation block to execute on each view's animation.
		- Parameter completion: A completion block to execute on each view's animation.
		*/
		public void Close(double duration = 0.15, double delay = 0, nfloat? usingSpringWithDamping = null, nfloat initialSpringVelocity = default(nfloat), UIViewAnimationOptions options = default(UIViewAnimationOptions), Action<UIView> animations = null, Action<UIView> completion = null)
		{
			usingSpringWithDamping = usingSpringWithDamping ?? 0.5f;
			if (Enabled)
			{
				disable();
				switch (Direction)
				{
					case MenuDirection.Up:
						{
							closeUpAnimation(duration, delay, usingSpringWithDamping.Value, initialSpringVelocity, options, animations, completion);
						}
						break;
					case MenuDirection.Down:
						{
							closeDownAnimation(duration, delay, usingSpringWithDamping.Value, initialSpringVelocity, options, animations, completion);
						}
						break;
					case MenuDirection.Left:
						{
							closeLeftAnimation(duration, delay, usingSpringWithDamping.Value, initialSpringVelocity, options, animations, completion);
						}
						break;
					case MenuDirection.Right:
						{
							closeRightAnimation(duration, delay, usingSpringWithDamping.Value, initialSpringVelocity, options, animations, completion);
						}
						break;
				}
			}
		}

		/**
		Open the Menu component with animation options in the Up direction.
		- Parameter duration: The time for each view's animation.
		- Parameter delay: A delay time for each view's animation.
		- Parameter usingSpringWithDamping: A damping ratio for the animation.
		- Parameter initialSpringVelocity: The initial velocity for the animation.
		- Parameter options: Options to pass to the animation.
		- Parameter animations: An animation block to execute on each view's animation.
		- Parameter completion: A completion block to execute on each view's animation.
		*/
		private void openUpAnimation(double duration, double delay, nfloat usingSpringWithDamping, nfloat initialSpringVelocity, UIViewAnimationOptions options, Action<UIView> animations, Action<UIView> completion)
		{
			var v = Views;
			if (v != null)
			{
				UIView baseView = null;
				for (var i = 1; i < v.Length; i++)
				{
					if (baseView == null)
					{
						baseView = v[0];
					}
					var view = v[i];
					view.Hidden = false;

					UIView.AnimateNotify(duration: ((double)i) * duration,
						delay: delay,
						springWithDampingRatio: usingSpringWithDamping,
						initialSpringVelocity: initialSpringVelocity,
						options: options,
						animations: () =>
						{
							var s = this;
							view.Alpha = 1;
							var frame = view.Frame;
							frame.Y = baseView.Frame.Y - ((nfloat)i) * s.ItemSize.Height - ((nfloat)i) * s.Spacing;
							view.Frame = frame;
							animations(view);
						}, completion: (bool finished) =>
						{
							var s = this;
							s.enable(view);
							if (view == v[v.Length - 1])
							{
								s.Opened = true;
							}
							if (completion != null)
							{
								completion(view);
							}
						});
				}
			}
		}

		/**
		Close the Menu component with animation options in the Up direction.
		- Parameter duration: The time for each view's animation.
		- Parameter delay: A delay time for each view's animation.
		- Parameter usingSpringWithDamping: A damping ratio for the animation.
		- Parameter initialSpringVelocity: The initial velocity for the animation.
		- Parameter options: Options to pass to the animation.
		- Parameter animations: An animation block to execute on each view's animation.
		- Parameter completion: A completion block to execute on each view's animation.
		*/
		private void closeUpAnimation(double duration, double delay, nfloat usingSpringWithDamping, nfloat initialSpringVelocity, UIViewAnimationOptions options, Action<UIView> animations, Action<UIView> completion)
		{
			var v = Views;
			if (v != null)
			{
				UIView baseView = null;
				for (var i = 1; i < v.Length; i++)
				{
					if (baseView == null)
					{
						baseView = v[0];
					}
					var view = v[i];
					view.Hidden = false;

					UIView.AnimateNotify(duration: ((double)i) * duration,
						delay: delay,
						springWithDampingRatio: usingSpringWithDamping,
						initialSpringVelocity: initialSpringVelocity,
						options: options,
						animations: () =>
						{
							var s = this;
							view.Alpha = 1;
							var frame = view.Frame;
							frame.Y = s.Origin.Y;
							view.Frame = frame;
							animations(view);
						}, completion: (bool finished) =>
						{
							var s = this;
							view.Hidden = true;
							s.enable(view);
							if (view == v[v.Length - 1])
							{
								s.Opened = true;
							}
							if (completion != null)
							{
								completion(view);
							}
						});
				}
			}
		}

		/**
		Open the Menu component with animation options in the Down direction.
		- Parameter duration: The time for each view's animation.
		- Parameter delay: A delay time for each view's animation.
		- Parameter usingSpringWithDamping: A damping ratio for the animation.
		- Parameter initialSpringVelocity: The initial velocity for the animation.
		- Parameter options: Options to pass to the animation.
		- Parameter animations: An animation block to execute on each view's animation.
		- Parameter completion: A completion block to execute on each view's animation.
		*/
		private void openDownAnimation(double duration, double delay, nfloat usingSpringWithDamping, nfloat initialSpringVelocity, UIViewAnimationOptions options, Action<UIView> animations, Action<UIView> completion)
		{
			var v = Views;
			if (v != null)
			{
				UIView baseView = null;
				for (var i = 1; i < v.Length; i++)
				{
					if (baseView == null)
					{
						baseView = v[0];
					}
					var view = v[i];
					view.Hidden = false;

					var h = BaseSize == null ? ItemSize.Height : BaseSize.Value.Height;
					UIView.AnimateNotify(duration: ((double)i) * duration,
						delay: delay,
						springWithDampingRatio: usingSpringWithDamping,
						initialSpringVelocity: initialSpringVelocity,
						options: options,
						animations: () =>
						{
							var s = this;
							view.Alpha = 1;
							var frame = view.Frame;
							frame.Y = baseView.Frame.Y + h + ((nfloat)i - 1) * s.ItemSize.Height - ((nfloat)i) * s.Spacing;
							view.Frame = frame;
							animations(view);
						}, completion: (bool finished) =>
						{
							var s = this;
							s.enable(view);
							if (view == v[v.Length - 1])
							{
								s.Opened = true;
							}
						});
				}
			}
		}

		/**
		Close the Menu component with animation options in the Down direction.
		- Parameter duration: The time for each view's animation.
		- Parameter delay: A delay time for each view's animation.
		- Parameter usingSpringWithDamping: A damping ratio for the animation.
		- Parameter initialSpringVelocity: The initial velocity for the animation.
		- Parameter options: Options to pass to the animation.
		- Parameter animations: An animation block to execute on each view's animation.
		- Parameter completion: A completion block to execute on each view's animation.
		*/
		private void closeDownAnimation(double duration, double delay, nfloat usingSpringWithDamping, nfloat initialSpringVelocity, UIViewAnimationOptions options, Action<UIView> animations, Action<UIView> completion)
		{
			var v = Views;
			if (v != null)
			{
				UIView baseView = null;
				for (var i = 1; i < v.Length; i++)
				{
					if (baseView == null)
					{
						baseView = v[0];
					}
					var view = v[i];
					view.Hidden = false;

					var h = BaseSize == null ? ItemSize.Height : BaseSize.Value.Height;
					UIView.AnimateNotify(duration: ((double)i) * duration,
						delay: delay,
						springWithDampingRatio: usingSpringWithDamping,
						initialSpringVelocity: initialSpringVelocity,
						options: options,
						animations: () =>
						{
							var s = this;
							view.Alpha = 1;
							var frame = view.Frame;
							frame.Y = s.Origin.Y + h;
							view.Frame = frame;
							animations(view);
						}, completion: (bool finished) =>
						{
							var s = this;
							view.Hidden = true;
							s.enable(view);
							if (view == v[v.Length - 1])
							{
								s.Opened = true;
							}
							if (completion != null)
							{
								completion(view);
							}
						});
				}
			}
		}

		/**
		Open the Menu component with animation options in the Left direction.
		- Parameter duration: The time for each view's animation.
		- Parameter delay: A delay time for each view's animation.
		- Parameter usingSpringWithDamping: A damping ratio for the animation.
		- Parameter initialSpringVelocity: The initial velocity for the animation.
		- Parameter options: Options to pass to the animation.
		- Parameter animations: An animation block to execute on each view's animation.
		- Parameter completion: A completion block to execute on each view's animation.
		*/
		private void openLeftAnimation(double duration, double delay, nfloat usingSpringWithDamping, nfloat initialSpringVelocity, UIViewAnimationOptions options, Action<UIView> animations, Action<UIView> completion)
		{
			var v = Views;
			if (v != null)
			{
				UIView baseView = null;
				for (var i = 1; i < v.Length; i++)
				{
					if (baseView == null)
					{
						baseView = v[0];
					}
					var view = v[i];
					view.Hidden = false;

					UIView.AnimateNotify(duration: ((double)i) * duration,
						delay: delay,
						springWithDampingRatio: usingSpringWithDamping,
						initialSpringVelocity: initialSpringVelocity,
						options: options,
						animations: () =>
						{
							var s = this;
							view.Alpha = 1;
							var frame = view.Frame;
							frame.X = baseView.Frame.X - ((nfloat)i) * s.ItemSize.Width - ((nfloat)i) * s.Spacing;
							view.Frame = frame;
							animations(view);
						}, completion: (bool finished) =>
						{
							var s = this;
							s.enable(view);
							if (view == v[v.Length - 1])
							{
								s.Opened = true;
							}
							if (completion != null)
							{
								completion(view);
							}
						});
				}
			}
		}

		/**
		Close the Menu component with animation options in the Left direction.
		- Parameter duration: The time for each view's animation.
		- Parameter delay: A delay time for each view's animation.
		- Parameter usingSpringWithDamping: A damping ratio for the animation.
		- Parameter initialSpringVelocity: The initial velocity for the animation.
		- Parameter options: Options to pass to the animation.
		- Parameter animations: An animation block to execute on each view's animation.
		- Parameter completion: A completion block to execute on each view's animation.
		*/
		private void closeLeftAnimation(double duration, double delay, nfloat usingSpringWithDamping, nfloat initialSpringVelocity, UIViewAnimationOptions options, Action<UIView> animations, Action<UIView> completion)
		{
			var v = Views;
			if (v != null)
			{
				UIView baseView = null;
				for (var i = 1; i < v.Length; i++)
				{
					if (baseView == null)
					{
						baseView = v[0];
					}
					var view = v[i];
					view.Hidden = false;

					UIView.AnimateNotify(duration: ((double)i) * duration,
						delay: delay,
						springWithDampingRatio: usingSpringWithDamping,
						initialSpringVelocity: initialSpringVelocity,
						options: options,
						animations: () =>
						{
							var s = this;
							view.Alpha = 1;
							var frame = view.Frame;
							frame.X = s.Origin.X;
							view.Frame = frame;
							animations(view);
						}, completion: (bool finished) =>
						{
							var s = this;
							view.Hidden = true;
							s.enable(view);
							if (view == v[v.Length - 1])
							{
								s.Opened = true;
							}
							if (completion != null)
							{
								completion(view);
							}
						});
				}
			}
		}

		/**
		Open the Menu component with animation options in the Right direction.
		- Parameter duration: The time for each view's animation.
		- Parameter delay: A delay time for each view's animation.
		- Parameter usingSpringWithDamping: A damping ratio for the animation.
		- Parameter initialSpringVelocity: The initial velocity for the animation.
		- Parameter options: Options to pass to the animation.
		- Parameter animations: An animation block to execute on each view's animation.
		- Parameter completion: A completion block to execute on each view's animation.
		*/
		private void openRightAnimation(double duration, double delay, nfloat usingSpringWithDamping, nfloat initialSpringVelocity, UIViewAnimationOptions options, Action<UIView> animations, Action<UIView> completion)
		{
			var v = Views;
			if (v != null)
			{
				UIView baseView = null;
				for (var i = 1; i < v.Length; i++)
				{
					if (baseView == null)
					{
						baseView = v[0];
					}
					var view = v[i];
					view.Hidden = false;

					var w = BaseSize == null ? ItemSize.Width : BaseSize.Value.Width;
					UIView.AnimateNotify(duration: ((double)i) * duration,
						delay: delay,
						springWithDampingRatio: usingSpringWithDamping,
						initialSpringVelocity: initialSpringVelocity,
						options: options,
						animations: () =>
						{
							var s = this;
							view.Alpha = 1;
							var frame = view.Frame;
							frame.X = baseView.Frame.X + w + ((nfloat)i - 1) * s.ItemSize.Width - ((nfloat)i) * s.Spacing;
							view.Frame = frame;
							animations(view);
						}, completion: (bool finished) =>
						{
							var s = this;
							s.enable(view);
							if (view == v[v.Length - 1])
							{
								s.Opened = true;
							}
						});
				}
			}
		}

		/**
		Close the Menu component with animation options in the Up direction.
		- Parameter duration: The time for each view's animation.
		- Parameter delay: A delay time for each view's animation.
		- Parameter usingSpringWithDamping: A damping ratio for the animation.
		- Parameter initialSpringVelocity: The initial velocity for the animation.
		- Parameter options: Options to pass to the animation.
		- Parameter animations: An animation block to execute on each view's animation.
		- Parameter completion: A completion block to execute on each view's animation.
		*/
		private void closeRightAnimation(double duration, double delay, nfloat usingSpringWithDamping, nfloat initialSpringVelocity, UIViewAnimationOptions options, Action<UIView> animations, Action<UIView> completion)
		{
			var v = Views;
			if (v != null)
			{
				UIView baseView = null;
				for (var i = 1; i < v.Length; i++)
				{
					if (baseView == null)
					{
						baseView = v[0];
					}
					var view = v[i];
					view.Hidden = false;

					var w = BaseSize == null ? ItemSize.Width : BaseSize.Value.Width;
					UIView.AnimateNotify(duration: ((double)i) * duration,
						delay: delay,
						springWithDampingRatio: usingSpringWithDamping,
						initialSpringVelocity: initialSpringVelocity,
						options: options,
						animations: () =>
						{
							var s = this;
							view.Alpha = 1;
							var frame = view.Frame;
							frame.Y = s.Origin.Y + w;
							view.Frame = frame;
							animations(view);
						}, completion: (bool finished) =>
						{
							var s = this;
							view.Hidden = true;
							s.enable(view);
							if (view == v[v.Length - 1])
							{
								s.Opened = true;
							}
							if (completion != null)
							{
								completion(view);
							}
						});
				}
			}
		}

		/// Layout the views.
		private void layoutButtons()
		{
			var v = Views;
			if (v != null)
			{
				var size = BaseSize == null ? ItemSize : BaseSize.Value;
				for (var i = 0; i < v.Length; i++)
				{
					var view = v[i];
					if (i == 0)
					{
						var frame = view.Frame;
						frame.Size = size;
						frame.Location = Origin;
						view.Frame = frame;
						view.Layer.ZPosition = 10000;
					}
					else
					{
						view.Alpha = 0;
						view.Hidden = true;

						var frame = view.Frame;
						frame.Size = ItemSize;
						frame.X = Origin.X + (size.Width - ItemSize.Width) / 2;
						frame.Y = Origin.Y + (size.Height - ItemSize.Height) / 2;
						view.Frame = frame;

						view.Layer.ZPosition = (nfloat)10000 - v.Length - i;
					}
				}
			}
		}

		/// Disable the Menu if views exist.
		private void disable()
		{
			var v = Views;
			if (v != null)
			{
				if (v.Length > 0)
				{
					Enabled = false;
				}
			}
		}

		/**
		Enable the Menu if the last view is equal to the passed in view.
		- Parameter view: UIView that is passed in to compare.
		*/
		private void enable(UIView view)
		{
			var v = Views;
			if (v != null)
			{
				if (view == v[v.Length - 1])
				{
					Enabled = true;
				}
			}
		}

		#endregion

	}
}
