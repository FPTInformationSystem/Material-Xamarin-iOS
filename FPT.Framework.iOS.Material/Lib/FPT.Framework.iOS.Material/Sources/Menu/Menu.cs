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
using Foundation;
using UIKit;

namespace FPT.Framework.iOS.Material
{

	public enum MenuDirection { Up, Down, Left, Right }

	public class MenuDelegate
	{
		public virtual void TappedAt(Menu menu, CGPoint point, bool isOutside) { }
	}

	public class Menu : View
	{

		#region PROPERTOES

		/// A Boolean that indicates if the menu is open or not.
		public bool IsOpened { get; private set; } = false;

		/// Enables the animations for the Menu.
		public bool IsEnabled { get; set; } = true;

		/// A preset wrapper around spacing.
		private InterimSpacePreset mInterimSpacePreset = InterimSpacePreset.None;
		public InterimSpacePreset InterimSpacePreset
		{
			get
			{
				return mInterimSpacePreset;
			}
			set
			{
				mInterimSpacePreset = value;
				mInterimSpace = Convert.InterimSpacePresetToValue(value);
			}
		}

		/// The space between views.
		private nfloat mInterimSpace;
		public nfloat InterimSpace
		{
			get
			{
				return mInterimSpace;
			}
			set
			{
				mInterimSpace = value;
				Reload();
			}
		}

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
				Reload();
			}
		}

		public MenuDelegate Delegate { get; set;}

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
				if (mViews != null)
				{
					foreach (var v in mViews)
					{
						v.RemoveFromSuperview();
					}
				}
				mViews = value;
				if (mViews != null)
				{
					foreach (var v in mViews)
					{
						AddSubview(v);
					}
				}
				Reload();
			}
		}

		/// An Optional base view size.
		public CGSize BaseSize { get; set; } = new CGSize(48, 48);

		/// Size of views, not including the first view.
		public CGSize ItemSize { get; set; } = new CGSize(48, 48);

		#endregion

		#region CONSTRUCTORS
		public Menu(NSCoder coder) : base(coder) { }

		public Menu(CGRect frame) : base(frame) { }

		//public Menu(CGPoint point) : base(new CGRect(point, CGSize.Empty)) { }

		public Menu() : this(CGRect.Empty) { }

		#endregion

		#region FUNCTIONS

		public override UIKit.UIView HitTest(CGPoint point, UIEvent uievent)
		{
			/**
			Since the subviews will be outside the bounds of this view,
			we need to look at the subviews to see if we have a hit.
			*/
			if (Hidden)
			{
				return null;
			}

			if (IsOpened)
			{
				foreach (var v in Subviews)
				{
					var p = v.ConvertPointFromView(point, this);
					if (v.Bounds.Contains(p))
					{
						Delegate.TappedAt(this, point, false);
						return v.HitTest(p, uievent);
					}
				}

				if (Delegate != null)
				{
					Delegate.TappedAt(this, point, true);
				}
			}
			return base.HitTest(point, uievent);
		}

		public override void Prepare()
		{
			base.Prepare();
			BackgroundColor = null;
			InterimSpacePreset = InterimSpacePreset.InterimSpacing6;
		}

		/// Reload the view layout.
		public void Reload()
		{
			IsOpened = false;
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
			if (IsEnabled)
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
			if (IsEnabled)
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
							view.SetY(baseView.Y() - ((nfloat)i) * s.ItemSize.Height - ((nfloat)i) * s.InterimSpace);
							if (animations != null)
							{
								animations(view);
							}
						}, completion: (bool finished) =>
						{
							var s = this;
							s.enable(view);
							if (view == v[v.Length - 1])
							{
								s.IsOpened = true;
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
							view.Alpha = 0;
							view.SetY(baseView.Y());
							if (animations != null)
							{
								animations(view);
							}
						}, completion: (bool finished) =>
						{
							var s = this;
							view.Hidden = true;
							s.enable(view);
							if (view == v[v.Length - 1])
							{
								s.IsOpened = false;
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

					var h = BaseSize.Height;
					UIView.AnimateNotify(duration: ((double)i) * duration,
						delay: delay,
						springWithDampingRatio: usingSpringWithDamping,
						initialSpringVelocity: initialSpringVelocity,
						options: options,
						animations: () =>
						{
							var s = this;
							view.Alpha = 1;
							view.SetY(baseView.Y() + h + ((nfloat)i - 1) * s.ItemSize.Height + ((nfloat)i) * s.InterimSpace);
							if (animations != null)
							{
								animations(view);
							}
						}, completion: (bool finished) =>
						{
							var s = this;
							s.enable(view);
							if (view == v[v.Length - 1])
							{
								s.IsOpened = true;
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

					var h = BaseSize.Height;
					UIView.AnimateNotify(duration: ((double)i) * duration,
						delay: delay,
						springWithDampingRatio: usingSpringWithDamping,
						initialSpringVelocity: initialSpringVelocity,
						options: options,
						animations: () =>
						{
							view.Alpha = 0;
							view.SetY(baseView.Y() + h);
							if (animations != null)
							{
								animations(view);
							}
						}, completion: (bool finished) =>
						{
							var s = this;
							view.Hidden = true;
							s.enable(view);
							if (view == v[v.Length - 1])
							{
								s.IsOpened = false;
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
							view.SetX(baseView.X() - ((nfloat)i) * s.ItemSize.Width - ((nfloat)i) * s.InterimSpace);
							if (animations != null)
							{
								animations(view);
							}
						}, completion: (bool finished) =>
						{
							var s = this;
							s.enable(view);
							if (view == v[v.Length - 1])
							{
								s.IsOpened = true;
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
							view.Alpha = 0;
							view.SetX(baseView.X());
							if (animations != null)
							{
								animations(view);
							}
						}, completion: (bool finished) =>
						{
							var s = this;
							view.Hidden = true;
							s.enable(view);
							if (view == v[v.Length - 1])
							{
								s.IsOpened = false;
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

					var w = BaseSize.Width;
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
							frame.X = baseView.Frame.X + w + ((nfloat)i - 1) * s.ItemSize.Width + ((nfloat)i) * s.InterimSpace;
							view.Frame = frame;
							if (animations != null)
							{
								animations(view);
							}
						}, completion: (bool finished) =>
						{
							var s = this;
							s.enable(view);
							if (view == v[v.Length - 1])
							{
								s.IsOpened = true;
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

					var w = BaseSize.Width;
					UIView.AnimateNotify(duration: ((double)i) * duration,
						delay: delay,
						springWithDampingRatio: usingSpringWithDamping,
						initialSpringVelocity: initialSpringVelocity,
						options: options,
						animations: () =>
						{
							view.Alpha = 0;
							view.SetX(baseView.X()+ w);
							if (animations != null)
							{
								animations(view);
							}
						}, completion: (bool finished) =>
						{
							var s = this;
							view.Hidden = true;
							s.enable(view);
							if (view == v[v.Length - 1])
							{
								s.IsOpened = false;
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
			if (Views == null || Views.Length == 0) return;

			var baseView = Views[0];

			var frame = baseView.Frame;
			frame.Size = BaseSize;
			baseView.Frame = frame;
			baseView.SetZPosition(10000);
			for (var i = 1; i < Views.Length; i++)
			{
				var v = Views[i];
				v.Alpha = 0;
				v.Hidden = true;

				frame = v.Frame;
				frame.Size = ItemSize;
				v.Frame = frame;

				v.SetX(baseView.X() + (BaseSize.Width - ItemSize.Width) / 2);
				v.SetY(baseView.Y() + (BaseSize.Height - ItemSize.Height) / 2);


				v.SetZPosition((nfloat)10000 - Views.Length - i);
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
					IsEnabled = false;
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
					IsEnabled = true;
				}
			}
		}

		#endregion

	}
}
