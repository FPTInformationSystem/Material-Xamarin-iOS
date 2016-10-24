// MIT/X11 License
//
// TabBar.cs
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
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace FPT.Framework.iOS.Material
{

	public enum TabBarLineAlignment
	{
		Top, Bottom
	}

	public class TabBarDelegate
	{
		public virtual void WillSelect(TabBar tabBar, UIButton button) { }
		public virtual void DidSelect(TabBar tabBar, UIButton button) { }
	}

	public class TabBar : Bar
	{

		#region PROPERTIES
		/// A boolean indicating if the TabBar line is in an animation state.
		public bool IsAnimating { get; internal set; } = false;

		/// A delegation reference.
		public TabBarDelegate Delegate { get; set; }

		/// The currently selected button.
		public UIButton Selected {get; internal set;}

		/// Buttons.
		private List<UIButton> mButtons = new List<UIButton>();
		public List<UIButton> Buttons
		{
			get
			{
				return mButtons;
			}
			set
			{
				foreach (var b in Buttons)
				{
					b.RemoveFromSuperview();
				}

				mButtons = value;

				CenterViews = Buttons.Cast<UIView>().ToList();

				LayoutSubviews();
			}
		}

		private bool mIsLineAnimated = true;
		public bool IsLineAnimated
		{
			get
			{
				return mIsLineAnimated;
			}
			set
			{
				mIsLineAnimated = value;
				foreach (var b in Buttons)
				{
					if (IsLineAnimated)
					{
						prepareLineAnimationHandler(b);
					}
					else
					{
						removeLineAnimationHandler(b);
					}
				}
			}
		}

		internal UIView Line { get; set;}

		public UIColor LineColor
		{
			get
			{
				return Line.BackgroundColor;
			}
			set
			{
				Line.BackgroundColor = value;
			}
		}

		private TabBarLineAlignment mLineAlignment = TabBarLineAlignment.Bottom;
		public TabBarLineAlignment LineAlignment
		{
			get
			{
				return mLineAlignment;
			}
			set
			{
				mLineAlignment = value;
			}
		}

		public nfloat LineHeight
		{
			get
			{
				return Line.Height();
			}
			set
			{
				Line.SetHeight(value);
			}
		}

		#endregion

		#region FUNCTIONS

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			if (WillLayout && 0 < Buttons.Count)
			{
				foreach (var b in Buttons)
				{
					b.Grid().Columns = 0;
					b.SetCornerRadius(0);
					b.ContentEdgeInsets = UIEdgeInsets.Zero;

					if (IsLineAnimated)
					{
						prepareLineAnimationHandler(b);
					}
				}

				ContentView.Grid().Reload();

				if (Selected == null)
				{
					Selected = Buttons[0];
				}

				Line.Frame = new CGRect(Selected.X(), LineAlignment == TabBarLineAlignment.Bottom? this.Height() - LineHeight : 0, Selected.Width(), LineHeight);
			}
		}

		[Export("handleButton:")]
		internal void handleButton(UIButton button)
		{
			Animate(button);
		}

		public void Select(int atIndex, Action<UIButton> completion = null)
		{
			if (-1 < atIndex && atIndex < Buttons.Count)
			{
				Animate(Buttons[atIndex], completion);
			}
		}

		public void Animate(UIButton toButton, Action<UIButton> completion = null)
		{
			var button = toButton;
			if (Delegate != null)
			{
				Delegate.WillSelect(this, button);
			}
			Selected = button;
			IsAnimating = true;

			UIView.Animate(0.25f, () =>
			{
				var s = this;
				var point = s.Line.Center;
				point.X = button.Center.X;
				s.Line.Center = point;
				s.Line.SetWidth(button.Width());

			}, () =>
			{
				var s = this;
				s.IsAnimating = false;
				if (s.Delegate != null)
				{
					s.Delegate.DidSelect(s, button);
				}
				if (completion != null)
				{
					completion(button);
				}
			});
		}

		public override void Prepare()
		{
			base.Prepare();
			this.SetHeightPreset(HeightPreset.Normal);
			ContentEdgeInsetsPreset = EdgeInsetsPreset.None;
			InterimSpacePreset = InterimSpacePreset.None;
			prepareLine();
			prepareDivider();
		}

		private void prepareLine()
		{
			Line = new UIView();
			Line.SetZPosition(6000);
			LineColor = Color.BlueGrey.Lighten3;
			LineHeight = 3;
			AddSubview(Line);
		}

		private void prepareDivider()
		{
			this.SetDividerAlignment(DividerAlignment.Top);
		}

		private void prepareLineAnimationHandler(UIButton button)
		{
			removeLineAnimationHandler(button);
			button.AddTarget(this, new Selector("handleButton:"), UIControlEvent.TouchUpInside);
		}

		private void removeLineAnimationHandler(UIButton button)
		{
			button.RemoveTarget(this, new Selector("handleButton:"), UIControlEvent.TouchUpInside);
		}

		#endregion

	}
}
