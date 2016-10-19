//// MIT/X11 License
////
//// TextField.cs
////
//// Author:
////       Pham Quan <QuanP@fpt.com.vn, mr.pquan@gmail.com> at FPT Software Service Center.
////
//// Copyright (c) 2016 FPT Information System.
////
//// Permission is hereby granted, free of charge, to any person obtaining a copy
//// of this software and associated documentation files (the "Software"), to deal
//// in the Software without restriction, including without limitation the rights
//// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//// copies of the Software, and to permit persons to whom the Software is
//// furnished to do so, subject to the following conditions:
////
//// The above copyright notice and this permission notice shall be included in
//// all copies or substantial portions of the Software.
////
//// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//// THE SOFTWARE.
//using System;
//using CoreGraphics;
//using CoreAnimation;
//using UIKit;
//using Foundation;
//using ObjCRuntime;

//namespace FPT.Framework.iOS.Material
//{

//	public class TextFieldDelegate : UITextFieldDelegate { }

//	public class TextField : UITextField
//	{

//		public class TextFieldAnimationDelegate : CAAnimationDelegate
//		{
//			TextField mParent;

//			public TextFieldAnimationDelegate(TextField parent)
//			{
//				mParent = parent;
//			}

//			public override void AnimationStarted(CAAnimation anim)
//			{
//				if (mParent.Delegate is MaterialAnimationDelegate)
//				{
//					(mParent.Delegate as MaterialAnimationDelegate).materialAnimationDidStart(anim);
//				}
//			}

//			public override void AnimationStopped(CAAnimation anim, bool finished)
//			{
//				if (anim is CAPropertyAnimation)
//				{
//					if (anim is CABasicAnimation)
//					{
//						var b = (CABasicAnimation)anim;
//						var v = b.To;
//						if (v != null)
//						{
//							var k = b.KeyPath;
//							if (k != null)
//							{
//								mParent.Layer.SetValueForKey(v, new NSString(k));
//								mParent.Layer.RemoveAnimation(k);
//							}
//						}
//					}
//				}
//				else if (anim is CAAnimationGroup)
//				{
//					foreach (var x in ((CAAnimationGroup)anim).Animations)
//					{
//						AnimationStopped(anim: x, finished: true);
//					}
//				}
//			}
//		}

//		#region VARIABLES

//		//private TextFieldAnimationDelegate mAnimationDelegate;

//		#endregion


//		#region PROPERTIES

//		public bool Animating { get; private set; } = false;

//		public bool MasksToBounds
//		{
//			get
//			{
//				return Layer.MasksToBounds;
//			}
//			set
//			{
//				Layer.MasksToBounds = value;
//			}
//		}

//		public nfloat X
//		{
//			get
//			{
//				return Layer.Frame.X;
//			}
//			set
//			{
//				var frame = Layer.Frame;
//				frame.X = value;
//				Layer.Frame = frame;
//			}
//		}

//		public nfloat Y
//		{
//			get
//			{
//				return Layer.Frame.Y;
//			}
//			set
//			{
//				var frame = Layer.Frame;
//				frame.Y = value;
//				Layer.Frame = frame;
//			}
//		}

//		public nfloat Width
//		{
//			get
//			{
//				return Layer.Frame.Width;
//			}
//			set
//			{
//				var frame = Layer.Frame;
//				frame.Width = value;
//				Layer.Frame = frame;
//			}
//		}

//		public nfloat Height
//		{
//			get
//			{
//				return Layer.Frame.Height;
//			}
//			set
//			{
//				var frame = Layer.Frame;
//				frame.Height = value;
//				Layer.Frame = frame;
//			}
//		}

//		public CGPoint Position
//		{
//			get
//			{
//				return Layer.Position;
//			}
//			set
//			{
//				Layer.Position = value;
//			}
//		}

//		public nfloat ZPosition
//		{
//			get
//			{
//				return Layer.ZPosition;
//			}
//			set
//			{
//				Layer.ZPosition = value;
//			}
//		}

//		public CAShapeLayer Divider { get; private set; } = new CAShapeLayer();

//		public nfloat DividerHeight { get; set; } = 1f;

//		public nfloat DividerActiveHeight { get; set; } = 2f;

//		private UIColor mDividerColor = MaterialColor.DarkText.Dividers;
//		public UIColor DividerColor
//		{
//			get
//			{
//				return mDividerColor;
//			}
//			set
//			{
//				mDividerColor = value;
//				if (!IsEditing)
//				{
//					Divider.BackgroundColor = DividerColor.CGColor;
//				}
//			}
//		}

//		private UIColor mDividerActiveColor;
//		public UIColor DividerActiveColor
//		{
//			get
//			{
//				return mDividerActiveColor;
//			}
//			set
//			{
//				mDividerActiveColor = value;
//				if (mDividerActiveColor != null)
//				{
//					if (IsEditing)
//					{
//						Divider.BackgroundColor = mDividerActiveColor.CGColor;
//					}
//				}
//			}
//		}

//		public override UIFont Font
//		{
//			get
//			{
//				return base.Font;
//			}
//			set
//			{
//				base.Font = value;
//				PlaceholderLabel.Font = value;
//			}
//		}

//		public override string Text
//		{
//			get
//			{
//				return base.Text;
//			}
//			set
//			{
//				base.Text = value;
//				if (string.IsNullOrEmpty(value) && !IsFirstResponder)
//				{
//					placeholderEditingDidEndAnimation();
//				}
//			}
//		}

//		public override string Placeholder
//		{
//			get
//			{
//				return PlaceholderLabel.Text;
//			}
//			set
//			{
//				PlaceholderLabel.Text = value;
//				if (value != null)
//				{
//					PlaceholderLabel.AttributedText = new NSAttributedString(str: value, attributes: new UIStringAttributes()
//					{
//						ForegroundColor = PlaceholderColor
//					});
//				}
//			}
//		}

//		public UILabel PlaceholderLabel { get; private set; } = new UILabel(CGRect.Empty);

//		private UIColor mPlaceholderColor = MaterialColor.DarkText.Others;
//		public UIColor PlaceholderColor
//		{
//			get
//			{
//				return mPlaceholderColor;
//			}
//			set
//			{
//				mPlaceholderColor = value;
//				if (IsEditing)
//				{
//					var v = Placeholder;
//					if (v != null)
//					{
//						PlaceholderLabel.AttributedText = new NSAttributedString(str: v, attributes: new UIStringAttributes()
//						{
//							ForegroundColor = PlaceholderColor
//						});
//					}
//				}
//			}
//		}

//		private UIColor mPlaceholderActiveColor = MaterialColor.Blue.Base;
//		public UIColor PlaceholderActiveColor
//		{
//			get
//			{
//				return mPlaceholderActiveColor;
//			}
//			set
//			{
//				mPlaceholderActiveColor = value;
//				if (IsEditing)
//				{
//					var v = Placeholder;
//					if (v != null)
//					{
//						PlaceholderLabel.AttributedText = new NSAttributedString(str: v, attributes: new UIStringAttributes()
//						{
//							ForegroundColor = PlaceholderActiveColor
//						});
//					}
//					TintColor = PlaceholderActiveColor;
//				}
//			}
//		}

//		public nfloat PlaceholderVerticalOffset { get; set; } = 0;

//		public UILabel DetailLabel { get; set; } = new UILabel(CGRect.Empty);

//		public String Detail
//		{
//			get
//			{
//				return DetailLabel.Text;
//			}
//			set
//			{
//				DetailLabel.Text = value;
//				if (value != null)
//				{
//					DetailLabel.AttributedText = new NSAttributedString(str: value, attributes: new UIStringAttributes()
//					{
//						ForegroundColor = DetailColor
//					});
//				}
//				layoutDetailLabel();
//			}
//		}

//		private UIColor mDetailColor = MaterialColor.DarkText.Others;
//		public UIColor DetailColor
//		{
//			get
//			{
//				return mDetailColor;
//			}
//			set
//			{
//				mDetailColor = value;
//				if (IsEditing)
//				{
//					var v = Placeholder;
//					if (v != null)
//					{
//						DetailLabel.AttributedText = new NSAttributedString(str: v, attributes: new UIStringAttributes()
//						{
//							ForegroundColor = mDetailColor
//						});
//					}
//				}
//			}
//		}

//		private nfloat mDetailVerticalOffset = 8f;
//		public nfloat DetailVerticalOffset
//		{
//			get
//			{
//				return mDetailVerticalOffset;
//			}
//			set
//			{
//				mDetailVerticalOffset = value;
//				layoutDetailLabel();
//			}
//		}

//		public override UITextAlignment TextAlignment
//		{
//			get
//			{
//				return base.TextAlignment;
//			}
//			set
//			{
//				base.TextAlignment = value;
//				PlaceholderLabel.TextAlignment = value;
//				DetailLabel.TextAlignment = value;
//			}
//		}

//		public bool EnableClearIconButton
//		{
//			get
//			{
//				return ClearIconButton != null;
//			}
//			set
//			{
//				if (value)
//				{
//					if (ClearIconButton == null)
//					{
//						var image = MaterialIcon.CM.Clear;
//						ClearIconButton = new IconButton(CGRect.Empty);
//						ClearIconButton.ContentEdgeInsets = UIEdgeInsets.Zero;
//						ClearIconButton.PulseAnimation = PulseAnimation.Center;
//						ClearIconButton.TintColor = PlaceholderColor;
//						ClearIconButton.SetImage(image, UIControlState.Normal);
//						ClearIconButton.SetImage(image, UIControlState.Highlighted);
//						ClearButtonMode = UITextFieldViewMode.Never;
//						RightViewMode = UITextFieldViewMode.WhileEditing;
//						RightView = ClearIconButton;
//						ClearIconButtonAutoHandle = ClearIconButtonAutoHandle ? true : false;
//					}
//				}
//				else
//				{
//					ClearIconButton.RemoveTarget(this, new Selector("handleClearIconButton"), UIControlEvent.TouchUpInside);
//					ClearIconButton = null;
//				}
//			}
//		}

//		/// Enables the automatic handling of the clearIconButton.
//		private bool mClearIconButtonAutoHandle = true;
//		public bool ClearIconButtonAutoHandle
//		{
//			get
//			{
//				return mClearIconButtonAutoHandle;
//			}
//			set
//			{
//				mClearIconButtonAutoHandle = value;
//				if (ClearIconButton != null)
//				{
//					ClearIconButton.RemoveTarget(this, new Selector("handleClearIconButton"), UIControlEvent.TouchUpInside);
//				}
//				if (ClearIconButtonAutoHandle && ClearIconButton != null)
//				{
//					ClearIconButton.AddTarget(this, new Selector("handleClearIconButton"), UIControlEvent.TouchUpInside);
//				}
//			}
//		}

//		public bool EnableVisibilityIconButton
//		{
//			get
//			{
//				return VisibilityIconButton != null;
//			}
//			set
//			{
//				if (value)
//				{
//					if (VisibilityIconButton == null)
//					{
//						var image = MaterialIcon.Visibility;
//						VisibilityIconButton = new IconButton(CGRect.Empty);
//						VisibilityIconButton.ContentEdgeInsets = UIEdgeInsets.Zero;
//						VisibilityIconButton.PulseAnimation = PulseAnimation.Center;
//						VisibilityIconButton.TintColor = PlaceholderColor;
//						VisibilityIconButton.SetImage(image, UIControlState.Normal);
//						VisibilityIconButton.SetImage(image, UIControlState.Highlighted);
//						VisibilityIconButton.TintColor = PlaceholderColor.ColorWithAlpha(SecureTextEntry ? 0.38f : 0.54f);
//						SecureTextEntry = true;
//						ClearButtonMode = UITextFieldViewMode.Never;
//						RightViewMode = UITextFieldViewMode.WhileEditing;
//						RightView = VisibilityIconButton;
//						VisibilityIconButtonAutoHandle = VisibilityIconButtonAutoHandle ? true : false;
//					}
//				}
//				else
//				{
//					ClearIconButton.RemoveTarget(this, new Selector("handleClearIconButton"), UIControlEvent.TouchUpInside);
//					ClearIconButton = null;
//				}
//			}
//		}

//		/// Enables the automatic handling of the visibilityIconButton.
//		private bool mVisibilityIconButtonAutoHandle = true;
//		public bool VisibilityIconButtonAutoHandle
//		{
//			get
//			{
//				return mVisibilityIconButtonAutoHandle;
//			}
//			set
//			{
//				mVisibilityIconButtonAutoHandle = value;
//				if (VisibilityIconButton != null)
//				{
//					VisibilityIconButton.RemoveTarget(this, new Selector("handleVisibilityIconButton"), UIControlEvent.TouchUpInside);
//				}
//				if (VisibilityIconButtonAutoHandle && VisibilityIconButton != null)
//				{
//					VisibilityIconButton.AddTarget(this, new Selector("handleVisibilityIconButton"), UIControlEvent.TouchUpInside);
//				}
//			}
//		}

//		public IconButton ClearIconButton { get; private set;}

//		public IconButton VisibilityIconButton { get; private set; }

//		#endregion

//		#region CONSTRUCTORS

//		public TextField() : this(CGRect.Empty)
//		{
//		}

//		public TextField(Foundation.NSCoder coder) : base(coder)
//		{
//			PrepareView();
//		}

//		public TextField(CGRect frame) : base(frame)
//		{
//			PrepareView();
//		}

//		#endregion

//		#region FUNCTIONS

//		public override void LayoutSubviews()
//		{
//			base.LayoutSubviews();
//			layoutToSize();
//		}
//		public override void LayoutSublayersOfLayer(CALayer layer)
//		{
//			base.LayoutSublayersOfLayer(layer);
//			if (this.Layer == layer)
//			{
//				layoutDivider();
//			}
//		}

//		public override CGSize IntrinsicContentSize
//		{
//			get
//			{
//				return new CGSize(Width, 32f);
//			}
//		}

//		public void Animate(CAAnimation animation)
//		{
//			animation.WeakDelegate = new TextFieldAnimationDelegate
//				(this);
//			if (animation is CABasicAnimation)
//			{
//				var a = (CABasicAnimation)animation;
//				a.From = (Layer.PresentationLayer == null ? Layer : Layer.PresentationLayer).ValueForKey(new NSString(a.KeyPath));
//			}
//			if (animation is CAPropertyAnimation)
//			{
//				var a = (CAPropertyAnimation)animation;
//				Layer.AddAnimation(a, a.KeyPath);
//			}
//			else if (animation is CAAnimationGroup)
//			{
//				var a = (CAAnimationGroup)animation;
//				Layer.AddAnimation(a, null);
//			}
//			else if (animation is CATransition)
//			{
//				var a = (CATransition)animation;
//				Layer.AddAnimation(a, CALayer.Transition);
//			}

//		}

//		/// Handles the text editing did begin state.
//		[Export("handleEditingDidBegin")]
//		public void handleEditingDidBegin()
//		{
//			dividerEditingDidBeginAnimation();
//			placeholderEditingDidBeginAnimation();
//		}

//		/// Handles the text editing did end state.
//		[Export("handleEditingDidEnd")]
//		public void handleEditingDidEnd()
//		{
//			dividerEditingDidEndAnimation();
//			placeholderEditingDidEndAnimation();
//		}

//		/// Handles the clearIconButton TouchUpInside event.
//		[Export("handleClearIconButton")]
//		public void handleClearIconButton()
//		{
//			if (Delegate != null && !Delegate.ShouldClear(this))
//			{
//				return;
//			}
//			Text = null;
//		}

//		/// Handles the visibilityIconButton TouchUpInside event.
//		[Export("handleVisibilityIconButton")]
//		public void handleVisibilityIconButton()
//		{
//			SecureTextEntry = !SecureTextEntry;
//			if (!SecureTextEntry) {
//				base.Font = null;
//				Font = PlaceholderLabel.Font;
//			}
//			if (VisibilityIconButton != null)
//			{
//				VisibilityIconButton.TintColor = VisibilityIconButton.TintColor.ColorWithAlpha(SecureTextEntry ? 0.38f : 0.54f);
//			}
//		}

//		/**
//		Prepares the view instance when intialized. When subclassing,
//		it is recommended to override the prepareView method
//		to initialize property values and other setup operations.
//		The super.prepareView method should always be called immediately
//		when subclassing.
//		*/
//		public virtual void PrepareView()
//		{
//			base.Placeholder = null;
//			MasksToBounds = false;
//			BorderStyle = UITextBorderStyle.None;
//			BackgroundColor = null;
//			Font = RobotoFont.RegularWithSize(16f);
//			ContentScaleFactor = MaterialDevice.Scale;
//			prepareDivider();
//			preparePlaceholderLabel();
//			prepareDetailLabel();
//			prepareTargetHandlers();

//			prepareTextAlignment();
//		}

//		/// Layout the divider.
//		private void layoutDivider()
//		{
//			Divider.Frame = new CGRect(0, Height, Width, IsEditing ? DividerActiveHeight : DividerHeight);
//		}

//		/// Ensures that the components are sized correctly.
//		public void layoutToSize()
//		{
//			if (!Animating) {
//				layoutPlaceholderLabel();
//				layoutDetailLabel();
//				layoutClearIconButton();
//				layoutVisibilityIconButton();
//			}
//		}

//		private void layoutPlaceholderLabel()
//		{
//			if (!IsEditing && string.IsNullOrEmpty(Text))
//			{
//				PlaceholderLabel.Frame = Bounds;
//			}
//			else if (PlaceholderLabel.Transform.IsIdentity)
//			{
//				PlaceholderLabel.Frame = Bounds;
//				PlaceholderLabel.Transform = CGAffineTransform.MakeScale(0.75f, 0.75f);
//				var frame = PlaceholderLabel.Frame;
//				switch (TextAlignment)
//				{
//					case UITextAlignment.Left:
//					case UITextAlignment.Natural:
//						{
//							frame.X = 0;
//						}
//						break;
//					case UITextAlignment.Right:
//						{
//							frame.X = Width - frame.Width;
//						}
//						break;
//					default:
//						break;

//				}
//				frame.Y = -frame.Height + PlaceholderVerticalOffset;
//				PlaceholderLabel.Frame = frame;
//				PlaceholderLabel.TextColor = PlaceholderColor;
//			}
//			else
//			{
//				var frame = PlaceholderLabel.Frame;
//				switch (TextAlignment)
//				{
//					case UITextAlignment.Left:
//					case UITextAlignment.Natural:
//						{
//							frame.X = 0;
//						}
//						break;
//					case UITextAlignment.Right:
//						{
//							frame.X = Width - frame.Width;
//						}
//						break;
//					case UITextAlignment.Center:
//						{
//							CGPoint center = PlaceholderLabel.Center;
//							center.X = Width / 2f;
//							PlaceholderLabel.Center = center;
//						}
//						break;
//					default:
//						break;

//				}
//				frame.Width = Width * 0.75f;
//				PlaceholderLabel.Frame = frame;
//			}
//		}

//		private void layoutDetailLabel()
//		{
//			nfloat h = Detail == null ? 12f : DetailLabel.Font.StringSize(Detail, Width).Height;
//			DetailLabel.Frame = new CGRect(0, Divider.Frame.Y + DetailVerticalOffset, Width, h);
//		}

//		/// Layout the clearIconButton.
//		public void layoutClearIconButton()
//		{
//			var v = ClearIconButton;
//			if (v != null) {
//				if (0 < Width && 0 < Height) {
//					v.Frame = new CGRect(Width - Height, 0, Height, Height);
//				}
//			}
//		}

//		/// Layout the visibilityIconButton.
//		public void layoutVisibilityIconButton()
//		{
//			var v = VisibilityIconButton;
//			if (v != null)
//			{
//				if (0 < Width && 0 < Height)
//				{
//					v.Frame = new CGRect(Width - Height, 0, Height, Height);
//				}
//			}
//		}

//		private void dividerEditingDidBeginAnimation()
//		{
//			var frame = Divider.Frame;
//			frame.Height = DividerActiveHeight;
//			Divider.Frame = frame;

//			Divider.BackgroundColor = DividerActiveColor == null ? PlaceholderActiveColor.CGColor : DividerActiveColor.CGColor;
//		}

//		private void dividerEditingDidEndAnimation()
//		{
//			var frame = Divider.Frame;
//			frame.Height = DividerHeight;
//			Divider.Frame = frame;

//			Divider.BackgroundColor = DividerColor.CGColor;
//		}

//		private void placeholderEditingDidBeginAnimation()
//		{
//			if (PlaceholderLabel.Transform.IsIdentity)
//			{
//				Animating = true;
//				UIView.Animate(duration: 0.15f,
//					animation: () =>
//					{
//						var v = this;
//						v.PlaceholderLabel.Transform = CGAffineTransform.MakeScale(0.75f, 0.75f);
//						var frame = PlaceholderLabel.Frame;
//						switch (v.TextAlignment)
//						{
//							case UITextAlignment.Left:
//							case UITextAlignment.Natural:
//								{
//									frame.X = 0;
//								}
//								break;
//							case UITextAlignment.Right:
//								{
//									frame.X = v.Width - frame.Width;
//								}
//								break;
//							default:
//								break;
//						}

//						frame.Y = -frame.Height + v.PlaceholderVerticalOffset;
//						v.PlaceholderLabel.Frame = frame;

//						v.PlaceholderLabel.TextColor = v.PlaceholderActiveColor;
//					},
//					completion: () =>
//					{
//						this.Animating = false;
//					});
//			}
//			else if (IsEditing)
//			{
//				PlaceholderLabel.TextColor = PlaceholderActiveColor;
//			}
//		}

//		private void placeholderEditingDidEndAnimation()
//		{
//			if (!PlaceholderLabel.Transform.IsIdentity && string.IsNullOrEmpty(Text))
//			{
//				Animating = true;
//				UIView.Animate(duration: 0.15f,
//					animation: () =>
//					{
//						var v = this;
//						v.PlaceholderLabel.Transform = CGAffineTransform.MakeIdentity();
//						var frame = v.PlaceholderLabel.Frame;
//						frame.X = 0;
//						frame.Y = 0;
//						v.PlaceholderLabel.Frame = frame;
//						v.PlaceholderLabel.TextColor = v.PlaceholderColor;
//					},
//	                completion: () =>
//					{
//						Animating = false;
//				 	});
//			}
//			else if (!IsEditing)
//			{
//				PlaceholderLabel.TextColor = PlaceholderColor;
//			}
//		}

//		private void prepareDivider()
//		{
//			DividerColor = MaterialColor.DarkText.Dividers;
//			Layer.AddSublayer(Divider);
//		}

//		private void preparePlaceholderLabel()
//		{
//			PlaceholderColor = MaterialColor.DarkText.Others;
//			AddSubview(PlaceholderLabel);
//		}

//		private void prepareDetailLabel()
//		{
//			DetailLabel.Font = RobotoFont.RegularWithSize(12f);
//			DetailColor = MaterialColor.DarkText.Others;
//			AddSubview(DetailLabel);
//		}

//		private void prepareTargetHandlers()
//		{
//			AddTarget(this, new Selector("handleEditingDidBegin"), UIControlEvent.EditingDidBegin);
//			AddTarget(this, new Selector("handleEditingDidEnd"), UIControlEvent.EditingDidEnd);
//		}

//		private void prepareTextAlignment()
//		{
//			TextAlignment = UIApplication.SharedApplication.UserInterfaceLayoutDirection == UIUserInterfaceLayoutDirection.RightToLeft ? UITextAlignment.Right : UITextAlignment.Left;
//		}

//		#endregion
//	}
//}
