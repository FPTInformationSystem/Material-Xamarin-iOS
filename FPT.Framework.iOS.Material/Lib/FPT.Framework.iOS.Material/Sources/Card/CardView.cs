// MIT/X11 License
//
// CardView.cs
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
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;
namespace FPT.Framework.iOS.Material
{
	public class CardView : MaterialPulseView
	{

		#region PROPERTIES

		internal CAShapeLayer DividerLayer { get; set;}

		private UIColor mDividerColor;
		public UIColor DividerColor
		{
			get
			{
				return mDividerColor;
			}
			set
			{
				mDividerColor = value;
				if (DividerLayer != null)
				{
					DividerLayer.BackgroundColor = DividerColor.CGColor;
				}
			}
		}

		private bool mDivider = true;
		public bool Divider
		{
			get
			{
				return mDivider;
			}
			set
			{
				mDivider = value;
				reloadView();
			}
		}

		private MaterialEdgeInset mDividerInsetPreset = MaterialEdgeInset.None;
		public MaterialEdgeInset DividerInsetPreset
		{
			get
			{
				return mDividerInsetPreset;
			}
			set
			{
				mDividerInsetPreset = value;
				DividerInset = Convert.MaterialEdgeInsetToValue(mDividerInsetPreset);
			}
		}

		private UIEdgeInsets mDividerInset = new UIEdgeInsets(top: 8f, left: 0, bottom:8f, right: 0);
		public UIEdgeInsets DividerInset
		{
			get
			{
				return mDividerInset;
			}
			set
			{
				mDividerInset = value;
				reloadView();
			}
		}

		private MaterialEdgeInset mContentInsetPreset = MaterialEdgeInset.Square2;
		public MaterialEdgeInset ContentInsetPreset
		{
			get
			{
				return mContentInsetPreset;
			}
			set
			{
				mContentInsetPreset = value;
				ContentInset = Convert.MaterialEdgeInsetToValue(mContentInsetPreset);
			}
		}

		private UIEdgeInsets mContentInset = Convert.MaterialEdgeInsetToValue(MaterialEdgeInset.Square2);
		public UIEdgeInsets ContentInset
		{
			get
			{
				return mContentInset;
			}
			set
			{
				mContentInset = value;
			}
		}

		private MaterialEdgeInset mTitleLabelInsetPreset = MaterialEdgeInset.Square2;
		public MaterialEdgeInset TitleLabelInsetPreset
		{
			get
			{
				return mTitleLabelInsetPreset;
			}
			set
			{
				mTitleLabelInsetPreset = value;
				TitleLabelInset = Convert.MaterialEdgeInsetToValue(mTitleLabelInsetPreset);
			}
		}

		private UIEdgeInsets mTitleLabelInset = Convert.MaterialEdgeInsetToValue(MaterialEdgeInset.Square2);
		public UIEdgeInsets TitleLabelInset
		{
			get
			{
				return mTitleLabelInset;
			}
			set
			{
				mTitleLabelInset = value;
				reloadView();
			}
		}

		private UILabel mTitleLabel;
		public UILabel TitleLabel
		{
			get
			{
				return mTitleLabel;
			}
			set
			{
				mTitleLabel = value;
				reloadView();
			}
		}

		private MaterialEdgeInset mContentViewInsetPreset = MaterialEdgeInset.Square2;
		public MaterialEdgeInset ContentViewInsetPreset
		{
			get
			{
				return mContentViewInsetPreset;
			}
			set
			{
				mTitleLabelInsetPreset = value;
				ContentViewInset = Convert.MaterialEdgeInsetToValue(mContentViewInsetPreset);
			}
		}

		private UIEdgeInsets mContentViewInset = Convert.MaterialEdgeInsetToValue(MaterialEdgeInset.Square2);
		public UIEdgeInsets ContentViewInset
		{
			get
			{
				return mContentViewInset;
			}
			set
			{
				mContentViewInset = value;
				reloadView();
			}
		}

		private UIView mContentView;
		public UIView ContentView
		{
			get
			{
				return mContentView;
			}
			set
			{
				mContentView = value;
				reloadView();
			}
		}

		private MaterialEdgeInset mLeftButtonsInsetPreset = MaterialEdgeInset.None;
		public MaterialEdgeInset LeftButtonsInsetPreset
		{
			get
			{
				return mLeftButtonsInsetPreset;
			}
			set
			{
				mLeftButtonsInsetPreset = value;
				LeftButtonsInset = Convert.MaterialEdgeInsetToValue(mLeftButtonsInsetPreset);
			}
		}

		private UIEdgeInsets mLeftButtonsInset;
		public UIEdgeInsets LeftButtonsInset
		{
			get
			{
				return mLeftButtonsInset;
			}
			set
			{
				mLeftButtonsInset = value;
				reloadView();
			}
		}

		private UIButton[] mLeftButtons;
		public UIButton[] LeftButtons
		{
			get
			{
				return mLeftButtons;
			}
			set
			{
				mLeftButtons = value;
				reloadView();
			}
		}

		private MaterialEdgeInset mRightButtonsInsetPreset = MaterialEdgeInset.None;
		public MaterialEdgeInset RightButtonsInsetPreset
		{
			get
			{
				return mRightButtonsInsetPreset;
			}
			set
			{
				mRightButtonsInsetPreset = value;
				RightButtonsInset = Convert.MaterialEdgeInsetToValue(mRightButtonsInsetPreset);
			}
		}

		private UIEdgeInsets mRightButtonsInset;
		public UIEdgeInsets RightButtonsInset
		{
			get
			{
				return mRightButtonsInset;
			}
			set
			{
				mRightButtonsInset = value;
				reloadView();
			}
		}

		private UIButton[] mRightButtons;
		public UIButton[] RightButtons
		{
			get
			{
				return mRightButtons;
			}
			set
			{
				mRightButtons = value;
				reloadView();
			}
		}

		#endregion

		#region CONSTRUCTORS

		public CardView(Foundation.NSCoder coder) : base(coder)
		{
		}

		public CardView(CGRect frame) : base(frame)
		{
		}

		public CardView() : this(CGRect.Empty)
		{
		}

		public CardView(UIImage image = null, UILabel titleLabel = null, UIView contentView = null, UIButton[] leftButtons = null, UIButton[] rightButtons = null) : this(CGRect.Empty)
		{
			
		}

		#endregion

		#region OVERRIDE FUNCTIONS

		public override void PrepareView()
		{
			base.PrepareView();
			Depth = MaterialDepth.Depth1;
			DividerColor = MaterialColor.Grey.Lighten3;
			CornerRadiusPreset = MaterialRadius.Radius1;
		}

		#endregion

		#region FUNTIONS

		void reloadView()
		{
			RemoveConstraints(Constraints);
			foreach (var v in Subviews)
			{
				v.RemoveFromSuperview();
			}

			var verticalFormat = "V:|";
			var views = new NSMutableDictionary();
			var metrics = new NSMutableDictionary();

			if (TitleLabel != null)
			{
				verticalFormat += "-(insetTop)";
				metrics["insetTop"] = NSNumber.FromNFloat(ContentInset.Top + TitleLabelInset.Top);
			}
			else if (ContentView != null)
			{
				verticalFormat += "-(insetTop)";
				metrics["insetTop"] = NSNumber.FromNFloat(ContentInset.Top + ContentViewInset.Top);
			}

			if (TitleLabel != null)
			{
				verticalFormat += "-[titleLabel]";
				views["titleLabel"] = TitleLabel;

				this.Layout(TitleLabel).Horizontally(left: ContentInset.Left + TitleLabelInset.Left, right: ContentInset.Right + TitleLabelInset.Right);
			}

			if (ContentView != null)
			{
				if (TitleLabel == null)
				{
					metrics["insetTop"] = NSNumber.FromNFloat((metrics["insetTop"] as NSNumber).NFloatValue + ContentViewInset.Top);
				}
				else
				{
					verticalFormat += "-(insetB)";
					metrics["insetB"] = NSNumber.FromNFloat(TitleLabelInset.Bottom + ContentViewInset.Top);
				}
				verticalFormat += "-[contentView]";
				views["contentView"] = ContentView;

				this.Layout(ContentView).Horizontally(left: ContentInset.Left + ContentViewInset.Left, right: ContentInset.Right + ContentViewInset.Right);
			}

			if (LeftButtons != null && LeftButtons.Length > 0)
			{
				var h = "H:|";
				var d = new NSMutableDictionary();
				var i = 0;
				foreach (var b in LeftButtons)
				{
					var k = String.Format("b{0}", i);
					d[k] = b;

					if (i == 0)
					{
						h += "-(left)-";
					}
					else
					{
						h += "-(left_right)-";
					}

					h += String.Format("[{0}]", k);

					this.Layout(b).Bottom(ContentInset.Bottom + LeftButtonsInset.Bottom);

					i += 1;
				}

				AddConstraints(Layout.Constraint(h, 0, NSDictionary.FromObjectsAndKeys(
					new object[] { ContentInset.Left + LeftButtonsInset.Left, LeftButtonsInset.Left + LeftButtonsInset.Right },
					new object[] { "left", "left_right" }
				), d));
			}

			if (RightButtons != null && RightButtons.Length > 0)
			{
				var h = "H:|";
				var d = new NSMutableDictionary();
				var i = RightButtons.Length - 1;
				foreach (var b in LeftButtons)
				{
					var k = String.Format("b{0}", i);
					d[k] = b;

					if (i == 0)
					{
						h += "-(right)-";
					}
					else
					{
						h += "-(right_left)-";
					}

					h += String.Format("[{0}]", k);

					this.Layout(b).Bottom(ContentInset.Bottom + RightButtonsInset.Bottom);

					i -= 1;
				}

				AddConstraints(Layout.Constraint(h + "|", 0, NSDictionary.FromObjectsAndKeys(
					new object[] { ContentInset.Right + RightButtonsInset.Right, RightButtonsInset.Right + RightButtonsInset.Left },
					new object[] { "right", "right_left" }
				), d));
			}

			if (LeftButtons != null && LeftButtons.Length > 0)
			{
				verticalFormat += "-(insetC)-[button]";
				views["button"] = LeftButtons[0];
				metrics["insetC"] = NSNumber.FromNFloat(LeftButtonsInset.Top);
				metrics["insetBottom"] = NSNumber.FromNFloat(ContentInset.Bottom + LeftButtonsInset.Bottom);
			}
			else if (RightButtons != null && RightButtons.Length > 0)
			{
				verticalFormat += "-(insetC)-[button]";
				views["button"] = RightButtons[0];
				metrics["insetC"] = NSNumber.FromNFloat(RightButtonsInset.Top);
				metrics["insetBottom"] = NSNumber.FromNFloat(ContentInset.Bottom + RightButtonsInset.Bottom);
			}

			if (ContentView != null)
			{
				if (metrics["insetC"] == null)
				{
					metrics["insetBottom"] = NSNumber.FromNFloat(ContentInset.Bottom + ContentViewInset.Bottom + (Divider ? DividerInset.Top + DividerInset.Bottom : 0));
				}
				else
				{
					metrics["insetC"] = NSNumber.FromNFloat((metrics["insetC"] as NSNumber).NFloatValue + ContentViewInset.Bottom + (Divider ? DividerInset.Top + DividerInset.Bottom : 0));
				}
			}
			else if (TitleLabel != null)
			{
				if (metrics["insetC"] == null)
				{
					metrics["insetBottom"] = NSNumber.FromNFloat(ContentInset.Bottom + TitleLabelInset.Bottom + (Divider ? DividerInset.Top + DividerInset.Bottom : 0));
				}
				else
				{
					metrics["insetC"] = NSNumber.FromNFloat((metrics["insetC"] as NSNumber).NFloatValue + TitleLabelInset.Bottom + (Divider ? DividerInset.Top + DividerInset.Bottom : 0));
				}
			}
			else if (metrics["insetC"] != null)
			{
				metrics["insetC"] = NSNumber.FromNFloat((metrics["insetC"] as NSNumber).NFloatValue + ContentInset.Bottom + (Divider ? DividerInset.Top + DividerInset.Bottom : 0));	
			}

			if (views.Count > 0)
			{
				verticalFormat += "-(insetBottom)-|";

				AddConstraints(Layout.Constraint(verticalFormat, 0, metrics, views));
			}
		}

		internal void prepareDivider(nfloat y, nfloat width)
		{
			if (DividerLayer == null)
			{
				DividerLayer = new CAShapeLayer();
				if (DividerLayer != null)
				{
					DividerLayer.ZPosition = 0;
				}
				Layer.AddSublayer(DividerLayer);
			}
			if (DividerLayer != null && DividerColor != null)
			{
				DividerLayer.BackgroundColor = DividerColor.CGColor;
				DividerLayer.Frame = new CGRect(DividerInset.Left, y, width - DividerInset.Left - DividerInset.Right, 1);
			}
		}

		internal void prepareProperotes(UIImage image, UILabel titileLabel, UIView contentView, UIButton[] leftButtons, UIButton[] rightButtons)
		{
			this.Image = image;
			this.TitleLabel = TitleLabel;
			this.ContentView = contentView;
			this.LeftButtons = leftButtons;
			this.RightButtons = rightButtons;
		}

		#endregion
	}
}
