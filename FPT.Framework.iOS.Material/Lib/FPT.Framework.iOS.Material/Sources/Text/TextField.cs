// MIT/X11 License
//
// TextField.cs
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
using CoreAnimation;
using UIKit;
using Foundation;
using ObjCRuntime;
using System.ComponentModel;

namespace FPT.Framework.iOS.Material
{

	public class TextFieldDelegate : UITextFieldDelegate 
	{
		public virtual void DidChange(UITextField textField, string text) { }

		public virtual void WillClear(UITextField textField, string text) { }

		public virtual void DidClear(UITextField textField, string text) { }
	}

	[Register("TextField"), DesignTimeVisible(true)]
	public class TextField : UITextField
	{

		private NSObject TextFieldContext = new NSObject();

		#region VARIABLES

		//private TextFieldAnimationDelegate mAnimationDelegate;

		#endregion


		#region PROPERTIES

		public bool WillLayout
		{
			get
			{
				return 0 < this.Width() && 0 < this.Height() && Superview != null;
			}
		}

		public override CGSize IntrinsicContentSize
		{
			get
			{
				return new CGSize(this.Width(), 32);
			}
		}

		public bool IsPlaceholderAnimated { get; set; } = true;

		public bool IsAnimating { get; private set; } = false;

		public override UIView LeftView
		{
			get
			{
				return base.LeftView;
			}
			set
			{
				base.LeftView = value;
				prepareLeftView();
				LayoutSubviews();
			}
		}

		public bool IsEmpty
		{
			get
			{
				return string.IsNullOrEmpty(Text);
			}
		}

		public nfloat LeftViewWidth
		{
			get
			{
				if (LeftView != null)
				{
					return LeftViewOffset + this.Height();
				}

				return 0;
			}
		}

		public nfloat LeftViewOffset { get; set; } = 16f;

		public nfloat DividerNormalHeight { get; set; } = 1f;

		public nfloat DividerActiveHeight { get; set; } = 2f;

		private UIColor mDividerNormalColor = Color.DarkText.Dividers;
		public UIColor DividerNormalColor
		{
			get
			{
				return mDividerNormalColor;
			}
			set
			{
				mDividerNormalColor = value;
				if (!IsEditing)
				{
					this.SetDividerColor(DividerNormalColor);
				}
			}
		}

		private UIColor mDividerActiveColor = Color.Blue.Base;
		public UIColor DividerActiveColor
		{
			get
			{
				return mDividerActiveColor;
			}
			set
			{
				mDividerActiveColor = value;
				if (mDividerActiveColor != null)
				{
					if (IsEditing)
					{
						this.SetDividerColor(mDividerActiveColor);
					}
				}
			}
		}

		public override UIFont Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
				PlaceholderLabel.Font = value;
			}
		}

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				if (string.IsNullOrEmpty(value) && !IsFirstResponder)
				{
					placeholderEditingDidEndAnimation();
				}
			}
		}

		public override string Placeholder
		{
			get
			{
				return PlaceholderLabel.Text;
			}
			set
			{
				PlaceholderLabel.Text = value;
				if (value != null)
				{
					PlaceholderLabel.AttributedText = new NSAttributedString(str: value, attributes: new UIStringAttributes()
					{
						ForegroundColor = PlaceholderNormalColor
					});
				}
			}
		}

		public UILabel PlaceholderLabel {
			[Export("placeholderLabel", ArgumentSemantic.Retain)]
			get;
			[Export("setPlaceholderLabel:", ArgumentSemantic.Retain)]
			private set;
		} = new UILabel(CGRect.Empty);

		private UIColor mPlaceholderNormalColor = Color.DarkText.Others;
		public UIColor PlaceholderNormalColor
		{
			get
			{
				return mPlaceholderNormalColor;
			}
			set
			{
				mPlaceholderNormalColor = value;
				updatePlaceholderLabelColor();
				//if (IsEditing)
				//{
				//	var v = Placeholder;
				//	if (v != null)
				//	{
				//		PlaceholderLabel.AttributedText = new NSAttributedString(str: v, attributes: new UIStringAttributes()
				//		{
				//			ForegroundColor = PlaceholderNormalColor
				//		});
				//	}
				//}
			}
		}

		private UIColor mPlaceholderActiveColor = Color.Blue.Base;
		public UIColor PlaceholderActiveColor
		{
			get
			{
				return mPlaceholderActiveColor;
			}
			set
			{
				mPlaceholderActiveColor = value;
				TintColor = PlaceholderActiveColor;
				updatePlaceholderLabelColor();
				//if (IsEditing)
				//{
				//	var v = Placeholder;
				//	if (v != null)
				//	{
				//		PlaceholderLabel.AttributedText = new NSAttributedString(str: v, attributes: new UIStringAttributes()
				//		{
				//			ForegroundColor = PlaceholderActiveColor
				//		});
				//	}
				//	TintColor = PlaceholderActiveColor;
				//}
			}
		}

		public nfloat PlaceholderVerticalOffset { get; set; } = 0;

		public UILabel DetailLabel { 
			[Export("detailLabel", ArgumentSemantic.Retain)]
			get;
			[Export("setDetailLabel:", ArgumentSemantic.Retain)]
			set; 
		} = new UILabel(CGRect.Empty);

		public String Detail
		{
			get
			{
				return DetailLabel.Text;
			}
			set
			{
				DetailLabel.Text = value;
			}
		}

		private UIColor mDetailColor = Color.DarkText.Others;
		public UIColor DetailColor
		{
			get
			{
				return mDetailColor;
			}
			set
			{
				mDetailColor = value;
				updateDetailLabelColor();
			}
		}

		private nfloat mDetailVerticalOffset = 8f;
		public nfloat DetailVerticalOffset
		{
			get
			{
				return mDetailVerticalOffset;
			}
			set
			{
				mDetailVerticalOffset = value;
				LayoutDetailLabel();
			}
		}

		public override UITextAlignment TextAlignment
		{
			get
			{
				return base.TextAlignment;
			}
			set
			{
				base.TextAlignment = value;
				PlaceholderLabel.TextAlignment = value;
				DetailLabel.TextAlignment = value;
			}
		}

		/// A reference to the clearIconButton.
		public IconButton ClearIconButton { get; private set; }

		public bool IsClearIconButtonEnabled
		{
			get
			{
				return ClearIconButton != null;
			}
			set
			{
				if (value)
				{
					if (ClearIconButton == null)
					{
						ClearIconButton = new IconButton(Icon.CM.Clear, PlaceholderNormalColor);
						ClearIconButton.ContentEdgeInsetsPreset = EdgeInsetsPreset.None;
						ClearIconButton.PulseAnimation = PulseAnimation.None;
						ClearButtonMode = UITextFieldViewMode.Never;
						RightViewMode = UITextFieldViewMode.WhileEditing;
						RightView = ClearIconButton;
						ClearIconButtonAutoHandled = ClearIconButtonAutoHandled ? true : false;
						LayoutSubviews();
					}
				}
				else
				{
					ClearIconButton.RemoveTarget(this, new Selector("handleClearIconButton"), UIControlEvent.TouchUpInside);
					ClearIconButton = null;
				}
			}
		}

		/// Enables the automatic handling of the clearIconButton.
		private bool mClearIconButtonAutoHandled = true;
		public bool ClearIconButtonAutoHandled
		{
			get
			{
				return mClearIconButtonAutoHandled;
			}
			set
			{
				mClearIconButtonAutoHandled = value;
				if (ClearIconButton != null)
				{
					ClearIconButton.RemoveTarget(this, new Selector("handleClearIconButton"), UIControlEvent.TouchUpInside);
				}
				if (ClearIconButtonAutoHandled && ClearIconButton != null)
				{
					ClearIconButton.AddTarget(this, new Selector("handleClearIconButton"), UIControlEvent.TouchUpInside);
				}
			}
		}

		/// A reference to the visibilityIconButton.
		public IconButton VisibilityIconButton { get; private set; }

		public bool IsVisibilityIconButtonEnabled
		{
			get
			{
				return VisibilityIconButton != null;
			}
			set
			{
				if (value)
				{
					if (VisibilityIconButton == null)
					{
						VisibilityIconButton = new IconButton(Icon.Visibility, PlaceholderNormalColor.ColorWithAlpha(SecureTextEntry ? 0.38f : 0.54f));
						VisibilityIconButton.ContentEdgeInsetsPreset = EdgeInsetsPreset.None;
						VisibilityIconButton.PulseAnimation = PulseAnimation.None;
						SecureTextEntry = true;
						ClearButtonMode = UITextFieldViewMode.Never;
						RightViewMode = UITextFieldViewMode.WhileEditing;
						RightView = VisibilityIconButton;
						VisibilityIconButtonAutoHandled = VisibilityIconButtonAutoHandled ? true : false;

						LayoutSubviews();
					}
				}
				else
				{
					ClearIconButton.RemoveTarget(this, new Selector("handleClearIconButton"), UIControlEvent.TouchUpInside);
					ClearIconButton = null;
				}
			}
		}

		/// Enables the automatic handling of the visibilityIconButton.
		private bool mVisibilityIconButtonAutoHandle = true;
		public bool VisibilityIconButtonAutoHandled
		{
			get
			{
				return mVisibilityIconButtonAutoHandle;
			}
			set
			{
				mVisibilityIconButtonAutoHandle = value;
				if (VisibilityIconButton != null)
				{
					VisibilityIconButton.RemoveTarget(this, new Selector("handleVisibilityIconButton"), UIControlEvent.TouchUpInside);
				}
				if (VisibilityIconButtonAutoHandled && VisibilityIconButton != null)
				{
					VisibilityIconButton.AddTarget(this, new Selector("handleVisibilityIconButton"), UIControlEvent.TouchUpInside);
				}
			}
		}

		public override void ObserveValue(NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context)
		{
			if (keyPath.ToString() == "placeholderLabel.text")
			{
				updatePlaceholderLabelColor();
				return;
			}
			if (keyPath.ToString() == "detailLabel.text")
			{
				updateDetailLabelColor();
				return;
			}

			base.ObserveValue(keyPath, ofObject, change, context);
		}

		#endregion

		#region CONSTRUCTORS
		~TextField()
		{
			RemoveObserver(this, "placeholderLabel.text");
			RemoveObserver(this, "detailLabel.text");
		}

		protected TextField(IntPtr handle) : base(handle)
		{
			Prepare();
		}

		public TextField() : this(CGRect.Empty)
		{
		}

		public TextField(Foundation.NSCoder coder) : base(coder)
		{
			Prepare();
		}

		public TextField(CGRect frame) : base(frame)
		{
			Prepare();
		}

		#endregion

		#region FUNCTIONS

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			Reload();
		}
		public override void LayoutSublayersOfLayer(CALayer layer)
		{
			base.LayoutSublayersOfLayer(layer);
			if (this.Layer == layer)
			{
				this.LayoutShape();
			}
		}

		/// Handles the text editing did begin state.
		[Export("handleEditingDidBegin")]
		public void handleEditingDidBegin()
		{
			dividerEditingDidBeginAnimation();
			placeholderEditingDidBeginAnimation();
		}

		// Live updates the textField text.
		[Export("handleEditingChanged:")]
		public void handleEditingChanged(UITextField textField)
		{
			if (Delegate != null && Delegate is TextFieldDelegate)
			{
				(Delegate as TextFieldDelegate).DidChange(this, textField.Text);
			}
		}

		/// Handles the text editing did end state.
		[Export("handleEditingDidEnd")]
		public void handleEditingDidEnd()
		{
			dividerEditingDidEndAnimation();
			placeholderEditingDidEndAnimation();
		}

		/// Handles the clearIconButton TouchUpInside event.
		[Export("handleClearIconButton")]
		public void handleClearIconButton()
		{
			if (Delegate != null && !Delegate.ShouldClear(this))
			{
				return;
			}
			Text = null;
		}

		/// Handles the visibilityIconButton TouchUpInside event.
		[Export("handleVisibilityIconButton")]
		public void handleVisibilityIconButton()
		{
			SecureTextEntry = !SecureTextEntry;
			if (!SecureTextEntry) {
				base.Font = null;
				Font = PlaceholderLabel.Font;
			}
			if (VisibilityIconButton != null)
			{
				VisibilityIconButton.TintColor = VisibilityIconButton.TintColor.ColorWithAlpha(SecureTextEntry ? 0.38f : 0.54f);
			}
		}

		/**
		Prepares the view instance when intialized. When subclassing,
		it is recommended to override the prepareView method
		to initialize property values and other setup operations.
		The super.prepareView method should always be called immediately
		when subclassing.
		*/
		public virtual void Prepare()
		{
			ClipsToBounds = false;
			BorderStyle = UITextBorderStyle.None;
			BackgroundColor = null;
			ContentScaleFactor = Device.Scale;
			prepareDivider();
			preparePlaceholderLabel();
			prepareDetailLabel();
			prepareTargetHandlers();

			prepareTextAlignment();
		}

		/// Ensures that the components are sized correctly.
		public void Reload()
		{
			if (WillLayout && !IsAnimating)
			{
				LayoutPlaceholderLabel();
				LayoutDetailLabel();
				LayoutButton(ClearIconButton);
				LayoutButton(VisibilityIconButton);
				layoutDivider();
				layoutLeftView();
			}
		}

		public void LayoutPlaceholderLabel()
		{
			var w = LeftViewWidth;
			var h = this.Height() == 0 ? IntrinsicContentSize.Height : this.Height();

			if (IsEditing || !IsEmpty || !IsPlaceholderAnimated)
			{
				PlaceholderLabel.Transform = CGAffineTransform.MakeIdentity();
				PlaceholderLabel.Frame = new CGRect(w, 0, this.Width() - w, h);
				PlaceholderLabel.Transform = CGAffineTransform.MakeScale(0.75f, 0.75f);

				switch (TextAlignment)
				{
					case UITextAlignment.Left:
					case UITextAlignment.Natural:
						{
							PlaceholderLabel.SetX(w);
						}
						break;
					case UITextAlignment.Right:
						{
							PlaceholderLabel.SetX(this.Width() - PlaceholderLabel.Width());
						}
						break;
					default:
						break;
				}

				PlaceholderLabel.SetY(-PlaceholderLabel.Height() + PlaceholderVerticalOffset);
			}
			else
			{
				PlaceholderLabel.Frame = new CGRect(w, 0, this.Width() - w, h);
				return;
			}
		}

		public void LayoutDetailLabel()
		{
			var c = this.Divider().ContentEdgeInsets;
			DetailLabel.SizeToFit();
			DetailLabel.SetX(c.Left);
			DetailLabel.SetY(this.Height() + DetailVerticalOffset);
			DetailLabel.SetWidth(this.Width() - c.Left - c.Right);
		}

		public void LayoutButton(UIButton button)
		{
			if (0 < this.Width() && 0 < this.Height())
			{
				if (button != null)
				{
					button.Frame = new CGRect(this.Width() - this.Height(), 0, this.Height(), this.Height());
				}
			}
		}

		/// Layout the divider.
		public void layoutDivider()
		{
			this.Divider().Reload();
		}

		/// Layout the leftView.
		public void layoutLeftView()
		{
			if (LeftView != null)
			{
				var w = LeftViewWidth;
				LeftView.Frame = new CGRect(0, 0, w, this.Height());
				UIEdgeInsets edgeInsets = this.Divider().ContentEdgeInsets;
				edgeInsets.Left = w;
				this.Divider().ContentEdgeInsets = edgeInsets;
			}
		}

		private void dividerEditingDidBeginAnimation()
		{
			//placeholderEditingDidEndAnimation();
			//dividerEditingDidBeginAnimation();

			this.SetDividerThickness(DividerActiveHeight);
			this.SetDividerColor(DividerActiveColor);
		}

		private void dividerEditingDidEndAnimation()
		{
			//placeholderEditingDidEndAnimation();
			//dividerEditingDidEndAnimation();

			this.SetDividerThickness(DividerNormalHeight);
			this.SetDividerColor(DividerNormalColor);
		}

		private void placeholderEditingDidBeginAnimation()
		{
			if (IsPlaceholderAnimated && IsEmpty && !IsAnimating)
			{
				IsAnimating = true;
				UIView.Animate(duration: 0.15f,
					animation: () =>
					{
						var s = this;
						s.PlaceholderLabel.Transform = CGAffineTransform.MakeScale(0.75f, 0.75f);
						var frame = PlaceholderLabel.Frame;
						switch (s.TextAlignment)
						{
							case UITextAlignment.Left:
							case UITextAlignment.Natural:
								{
									s.PlaceholderLabel.SetX(s.LeftViewWidth);
								}
								break;
							case UITextAlignment.Right:
								{
								s.PlaceholderLabel.SetX(s.Width() - s.PlaceholderLabel.Width());
								}
								break;
							default:
								break;
						}

					s.PlaceholderLabel.SetY( -s.PlaceholderLabel.Height() + s.PlaceholderVerticalOffset);
					},
					completion: () =>
					{
						this.IsAnimating = false;
					});
			}
		}

		private void placeholderEditingDidEndAnimation()
		{
			if (!PlaceholderLabel.Transform.IsIdentity && string.IsNullOrEmpty(Text))
			{
				IsAnimating = true;
				UIView.Animate(duration: 0.15f,
					animation: () =>
					{
						var s = this;
						s.PlaceholderLabel.Transform = CGAffineTransform.MakeIdentity();
						s.PlaceholderLabel.SetX(s.LeftViewWidth);
						s.PlaceholderLabel.SetY(0);
						s.PlaceholderLabel.TextColor = s.PlaceholderNormalColor;
					},
	                completion: () =>
					{
						IsAnimating = false;
				 	});
			}
		}

		private void prepareDivider()
		{
			this.SetDividerColor(DividerNormalColor);
		}

		private void preparePlaceholderLabel()
		{
			Font = RobotoFont.RegularWithSize(16);
			PlaceholderNormalColor = Color.DarkText.Others;
			AddSubview(PlaceholderLabel);
			AddObserver(this, "placeholderLabel.text", default(NSKeyValueObservingOptions), TextFieldContext.Handle);
		}

		private void prepareDetailLabel()
		{
			DetailLabel.Font = RobotoFont.RegularWithSize(12f);
			DetailColor = Color.DarkText.Others;
			AddSubview(DetailLabel);
			AddObserver(this, "detailLabel.text", default(NSKeyValueObservingOptions), TextFieldContext.Handle);
		}

		private void prepareLeftView()
		{
			LeftView.ContentMode = UIViewContentMode.Left;
		}

		private void prepareTargetHandlers()
		{
			AddTarget(this, new Selector("handleEditingDidBegin"), UIControlEvent.EditingDidBegin);
			AddTarget(this, new Selector("handleEditingChanged:"), UIControlEvent.EditingDidEnd);
			AddTarget(this, new Selector("handleEditingDidEnd"), UIControlEvent.EditingDidEnd);
		}

		private void prepareTextAlignment()
		{
			TextAlignment = UIApplication.SharedApplication.UserInterfaceLayoutDirection == UIUserInterfaceLayoutDirection.RightToLeft ? UITextAlignment.Right : UITextAlignment.Left;
		}

		private void updatePlaceholderLabelColor()
		{
			if (Placeholder == null) return;
			PlaceholderLabel.AttributedText = new NSAttributedString(str: Placeholder, attributes: new UIStringAttributes()
			{
				ForegroundColor = PlaceholderActiveColor
			});
		}

		private void updateDetailLabelColor()
		{
			if (Detail == null) return;
			DetailLabel.AttributedText = new NSAttributedString(str: Detail, attributes: new UIStringAttributes()
			{
				ForegroundColor = DetailColor
			});
		}

		#endregion
	}
}
