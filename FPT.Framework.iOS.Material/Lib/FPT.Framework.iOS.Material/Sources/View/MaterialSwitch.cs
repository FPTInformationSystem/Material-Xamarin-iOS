//// MIT/X11 License
////
//// MaterialSwitch.cs
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
//using UIKit;
//using CoreGraphics;
//using CoreAnimation;
//using ObjCRuntime;
//using Foundation;

//namespace FPT.Framework.iOS.Material
//{
//	public enum MaterialSwitchStyle
//	{
//		LightContent, Default
//	}

//	public enum MaterialSwitchState
//	{
//		On, Off
//	}

//	public enum MaterialSwitchSize
//	{
//		Small, Default, Large
//	}

//	public interface MaterialSwitchDelegate
//	{
//		void MaterialSwitchStateChanged(MaterialSwitch control);
//	}

//	public class MaterialSwitch : UIControl
//	{

//		private MaterialSwitchState internalSwitchState { get; set; } = MaterialSwitchState.Off;

//		private nfloat trackThickness { get; set; } = 0;

//		private nfloat buttonDiameter { get; set; } = 0;

//		private nfloat onPosition { get; set; } = 0;

//		private nfloat offPosition { get; set; } = 0;

//		private nfloat bounceOffset { get; set; } = 3;

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

//		public MaterialSwitchDelegate Delegate { get; set; }

//		private bool mBounceable = true;
//		public bool Bounceable
//		{
//			get
//			{
//				return mBounceable;
//			}
//			set
//			{
//				mBounceable = value;
//				bounceOffset = mBounceable ? 3 : 0;
//			}
//		}

//		private UIColor mButtonOnColor = MaterialColor.Clear;
//		public UIColor ButtonOnColor
//		{
//			get
//			{
//				return mButtonOnColor;
//			}
//			set
//			{
//				mButtonOnColor = value;
//				styleForState(SwitchState);
//			}
//		}

//		private UIColor mTrackOnColor = MaterialColor.Clear;
//		public UIColor TrackOnColor
//		{
//			get
//			{
//				return mTrackOnColor;
//			}
//			set
//			{
//				mTrackOnColor = value;
//				styleForState(SwitchState);
//			}
//		}

//		private UIColor mButtonOffColor = MaterialColor.Clear;
//		public UIColor ButtonOffColor
//		{
//			get
//			{
//				return mButtonOffColor;
//			}
//			set
//			{
//				mButtonOffColor = value;
//				styleForState(SwitchState);
//			}
//		}

//		private UIColor mTrackOffColor = MaterialColor.Clear;
//		public UIColor TrackOffColor
//		{
//			get
//			{
//				return mTrackOffColor;
//			}
//			set
//			{
//				mTrackOffColor = value;
//				styleForState(SwitchState);
//			}
//		}

//		private UIColor mButtonOnDisabledColor = MaterialColor.Clear;
//		public UIColor ButtonOnDisabledColor
//		{
//			get
//			{
//				return mButtonOnDisabledColor;
//			}
//			set
//			{
//				mButtonOnDisabledColor = value;
//				styleForState(SwitchState);
//			}
//		}

//		private UIColor mTrackOnDisabledColor = MaterialColor.Clear;
//		public UIColor TrackOnDisabledColor
//		{
//			get
//			{
//				return mTrackOnDisabledColor;
//			}
//			set
//			{
//				mTrackOnDisabledColor = value;
//				styleForState(SwitchState);
//			}
//		}

//		private UIColor mButtonOffDisabledColor = MaterialColor.Clear;
//		public UIColor ButtonOffDisabledColor
//		{
//			get
//			{
//				return mButtonOffDisabledColor;
//			}
//			set
//			{
//				mButtonOffDisabledColor = value;
//				styleForState(SwitchState);
//			}
//		}

//		private UIColor mTrackOffDisabledColor = MaterialColor.Clear;
//		public UIColor TrackOffDisabledColor
//		{
//			get
//			{
//				return mTrackOffDisabledColor;
//			}
//			set
//			{
//				mTrackOffDisabledColor = value;
//				styleForState(SwitchState);
//			}
//		}

//		private CAShapeLayer mTrackLayer;
//		public CAShapeLayer TrackLayer
//		{
//			get
//			{
//				return mTrackLayer;
//			}
//			set
//			{
//				mTrackLayer = value;
//				//prepareTrack();
//			}
//		}

//		private FabButton mButton;
//		public FabButton Button

//		{
//			get
//			{
//				return mButton;
//			}
//			private set
//			{
//				mButton = value;
//				//prepareButton();
//			}
//		}

//		public override bool Enabled
//		{
//			get
//			{
//				return base.Enabled;
//			}
//			set
//			{
//				base.Enabled = value;
//				styleForState(internalSwitchState);
//			}
//		}

//		public bool On
//		{
//			get
//			{
//				return internalSwitchState == MaterialSwitchState.On;	
//			}
//			set
//			{
//				SetOn(value, true);
//			}
//		}

//		public MaterialSwitchState SwitchState
//		{
//			get
//			{
//				return internalSwitchState;
//			}
//			set
//			{
//				if (internalSwitchState != value)
//				{
//					internalSwitchState = value;
//				}
//			}
//		}

//		private MaterialSwitchStyle mSwitchStyle = MaterialSwitchStyle.Default;
//		public MaterialSwitchStyle SwitchStyle
//		{
//			get
//			{
//				return mSwitchStyle;
//			}
//			set
//			{
//				mSwitchStyle = value;
//				switch (mSwitchStyle)
//				{
//					case MaterialSwitchStyle.LightContent:
//						{
//							ButtonOnColor = MaterialColor.Blue.Darken2;
//							TrackOnColor = MaterialColor.Blue.Lighten3;
//							ButtonOffColor = MaterialColor.BlueGrey.Lighten4;
//							TrackOffColor = MaterialColor.BlueGrey.Lighten3;
//							ButtonOnDisabledColor = MaterialColor.Grey.Lighten2;
//							TrackOnDisabledColor = MaterialColor.Grey.Lighten3;
//							ButtonOffDisabledColor = MaterialColor.Grey.Lighten2;
//							TrackOffDisabledColor = MaterialColor.Grey.Lighten3;
//						}
//						break;
//					case MaterialSwitchStyle.Default:
//						{
//							ButtonOnColor = MaterialColor.Blue.Lighten1;
//							TrackOnColor = MaterialColor.Blue.Lighten2.ColorWithAlpha(0.5f);
//							ButtonOffColor = MaterialColor.BlueGrey.Lighten3;
//							TrackOffColor = MaterialColor.BlueGrey.Lighten4.ColorWithAlpha(0.5f);
//							ButtonOnDisabledColor = MaterialColor.Grey.Darken3;
//							TrackOnDisabledColor = MaterialColor.Grey.Lighten1.ColorWithAlpha(0.2f);
//						}
//						break;
//				}
//			}
//		}

//		private MaterialSwitchSize mSwitchSize = MaterialSwitchSize.Default;
//		public MaterialSwitchSize SwitchSize
//		{
//			get
//			{
//				return mSwitchSize;
//			}
//			set
//			{
//				mSwitchSize = value;
//				switch (mSwitchSize)
//				{
//					case MaterialSwitchSize.Small:
//						{
//							trackThickness = 13;
//							buttonDiameter = 18;
//							Frame = new CGRect(0, 0, 30, 25);
//						}
//						break;
//					case MaterialSwitchSize.Default:
//						{
//							trackThickness = 17;
//							buttonDiameter = 24;
//							Frame = new CGRect(0, 0, 40, 30);		
//						}
//						break;
//					case MaterialSwitchSize.Large:
//						{
//							trackThickness = 23;
//							buttonDiameter = 31;
//							Frame = new CGRect(0, 0, 50, 40);
//						}
//						break;
//				}
//			}
//		}

//		public override CGRect Frame
//		{
//			get
//			{
//				return base.Frame;
//			}
//			set
//			{
//				base.Frame = value;
//				layoutSwitch();
//			}
//		}

//		public override CGRect Bounds
//		{
//			get
//			{
//				return base.Bounds;
//			}
//			set
//			{
//				base.Bounds = value;
//				layoutSwitch();
//			}
//		}

//		#region CONSTRUCTORS

//		public MaterialSwitch(Foundation.NSCoder coder) : base(coder)
//		{
//			//TrackLayer = new CAShapeLayer();
//			//Button = new FabButton();
//			prepareTrack();
//			prepareButton();
//			prepareSwitchSize(MaterialSwitchSize.Default);
//			prepareSwitchStyle(MaterialSwitchStyle.LightContent);
//			prepareSwitchState(MaterialSwitchState.Off);
//		}

//		public MaterialSwitch(CGRect frame) : base(frame)
//		{
//			////TrackLayer = new CAShapeLayer();
//			////Button = new FabButton();
//			prepareTrack();
//			prepareButton();
//			prepareSwitchSize(MaterialSwitchSize.Default);
//			prepareSwitchStyle(MaterialSwitchStyle.LightContent);
//			prepareSwitchState(MaterialSwitchState.Off);
//		}

//		public MaterialSwitch(MaterialSwitchState state = MaterialSwitchState.Off, MaterialSwitchStyle style = MaterialSwitchStyle.Default, MaterialSwitchSize size = MaterialSwitchSize.Default) : base(CGRect.Empty)
//		{
//			//TrackLayer = new CAShapeLayer();
//			//Button = new FabButton();
//			prepareTrack();
//			prepareButton();
//			prepareSwitchSize(size);
//			prepareSwitchStyle(style);
//			prepareSwitchState(state);
//		}

//		#endregion

//		#region FUNCTIONS

//		public override void WillMoveToSuperview(UIView newsuper)
//		{
//			base.WillMoveToSuperview(newsuper);
//			styleForState(internalSwitchState);
//		}

//		public override CGSize IntrinsicContentSize
//		{
//			get
//			{
//				switch (SwitchSize)
//				{
//					case MaterialSwitchSize.Small:
//						return new CGSize(30, 25);
//					case MaterialSwitchSize.Default:
//						return new CGSize(40, 30);
//					case MaterialSwitchSize.Large:
//						return new CGSize(50, 40);
//				}

//				return base.IntrinsicContentSize;
//			}
//		}

//		public void Toggle(Action<MaterialSwitch> completion = null)
//		{
//			SetSwitchState(internalSwitchState == MaterialSwitchState.On ? MaterialSwitchState.Off : MaterialSwitchState.On, true, completion);
//		}

//		public void SetOn(bool on, bool animated, Action<MaterialSwitch> completion = null)
//		{
//			SetSwitchState(on ? MaterialSwitchState.On : MaterialSwitchState.Off, animated, completion);
//		}

//		public void SetSwitchState(MaterialSwitchState state, bool animated = true, Action<MaterialSwitch> completion = null)
//		{
//			if (Enabled && internalSwitchState != state)
//			{
//				internalSwitchState = state;
//				if (animated)
//				{
//					animateToState(state, (MaterialSwitch s) =>
//					{
//						s.SendActionForControlEvents(UIControlEvent.ValueChanged);
//						if (completion != null)
//						{
//							completion(s);
//						}
//						if (s.Delegate != null)
//						{
//							s.Delegate.MaterialSwitchStateChanged(this);
//						}
//					});
//				}
//				else
//				{
//					Button.X = state == MaterialSwitchState.On ? onPosition : offPosition;
//					styleForState(state);
//					SendActionForControlEvents(UIControlEvent.ValueChanged);
//					if (completion != null)
//					{
//						completion(this);
//					}
//					if (Delegate != null)
//					{
//						Delegate.MaterialSwitchStateChanged(this);
//					}
//				}
//			}
//		}

//		void handleTouchUpInside(object sender, EventArgs e)
//		{
//			Toggle();
//		}

//		[Export("handleTouchDragInside:fromSender:ForEvent")]
//		void handleTouchDragInside(FabButton sender, UIEvent e)
//		{
//			var touches = e.TouchesForView(sender).ToArray<UITouch>();
//			if (touches == null)
//				return;
//			var v = touches[0];
//			if (v != null)
//			{
//				nfloat q = NMath.Max(NMath.Min(sender.X + v.LocationInView(sender).X - v.PreviousLocationInView(sender).X, onPosition), offPosition);
//				if (q != sender.X)
//				{
//					sender.X = q;
//				}
//			}
//		}

//		[Export("handleTouchUpOutsideOrCanceled:fromSender:ForEvent")]
//		void handleTouchUpOutsideOrCanceled(FabButton sender, UIEvent e)
//		{
//			var touches = e.TouchesForView(sender).ToArray<UITouch>();
//			if (touches == null)
//				return;
//			var v = touches[0];
//			if (v != null)
//			{
//				nfloat q = sender.X + v.LocationInView(sender).X - v.PreviousLocationInView(sender).X;
//				SetSwitchState(q > (Width - Button.Width) / 2f ? MaterialSwitchState.On : MaterialSwitchState.Off, true);
//			}
//		}

//		public override void TouchesBegan(NSSet touches, UIEvent evt)
//		{
//			if (TrackLayer.Frame.Contains(Layer.ConvertPointToLayer(touches.ToArray<UITouch>()[0].LocationInView(this), Layer)))
//			{
//				SetOn(internalSwitchState != MaterialSwitchState.On, true);
//			}
//		}

//		private void prepareTrack()
//		{
//			Layer.AddSublayer(TrackLayer);
//		}

//		private void prepareButton()
//		{
//			Button.PulseAnimation = PulseAnimation.None;
//			Button.TouchUpInside += handleTouchUpInside;
//			Button.AddTarget(this, new Selector("handleTouchDragInside:fromSender:ForEvent"), UIControlEvent.TouchDragInside);
//			//Button.TouchDragInside += handleTouchDragInside;
//			//Button.TouchCancel += handleTouchUpOutsideOrCanceled;
//			//Button.TouchUpOutside += handleTouchUpOutsideOrCanceled;
//			Button.AddTarget(this, new Selector("handleTouchUpOutsideOrCanceled:fromSender:ForEvent"), UIControlEvent.TouchCancel | UIControlEvent.TouchUpOutside);
//			AddSubview(Button);
//		}

//		private void prepareSwitchState(MaterialSwitchState state)
//		{
//			SetSwitchState(state, false);
//		}

//		private void prepareSwitchStyle(MaterialSwitchStyle style)
//		{
//			SwitchStyle = style;
//		}

//		private void prepareSwitchSize(MaterialSwitchSize size)
//		{
//			SwitchSize = size;
//		}

//		private void styleForState(MaterialSwitchState state)
//		{
//			if (Enabled)
//			{
//				updateColorForState(state);
//			}
//			else
//			{
//				updateColorForDisabledState(state);
//			}
//		}

//		private void updateColorForState(MaterialSwitchState state)
//		{
//			if (state == MaterialSwitchState.On)
//			{
//				Button.BackgroundColor = ButtonOnColor;
//				TrackLayer.BackgroundColor = TrackOnColor.CGColor;
//			}
//			else
//			{
//				Button.BackgroundColor = ButtonOffColor;
//				TrackLayer.BackgroundColor = TrackOffColor.CGColor;
//			}
//		}

//		private void updateColorForDisabledState(MaterialSwitchState state)
//		{
//			if (state == MaterialSwitchState.On)
//			{
//				Button.BackgroundColor = ButtonOnDisabledColor;
//				TrackLayer.BackgroundColor = TrackOnDisabledColor.CGColor;
//			}
//			else
//			{
//				Button.BackgroundColor = ButtonOffDisabledColor;
//				TrackLayer.BackgroundColor = TrackOffDisabledColor.CGColor;
//			}
//		}

//		private void layoutSwitch()
//		{
//			if (TrackLayer == null)
//			{
//				TrackLayer = new CAShapeLayer();
//			}
//			if (Button == null)
//			{
//				Button = new FabButton();
//			}

//			nfloat w = 0;
//			switch (SwitchSize)
//			{
//				case MaterialSwitchSize.Small:
//					{
//						w = 30;
//					}
//					break;
//				case MaterialSwitchSize.Default:
//					{
//						w = 40;
//					}
//					break;
//				case MaterialSwitchSize.Large:
//					{
//						w = 50;
//					}
//					break;
//			}

//			nfloat px = (Width - w) / 2f;

//			TrackLayer.Frame = new CGRect(px, (Height - trackThickness) / 2f, w, trackThickness);
//			TrackLayer.CornerRadius = NMath.Min(TrackLayer.Frame.Height, TrackLayer.Frame.Width) / 2f;

//			Button.Frame = new CGRect(px, (Height - buttonDiameter) / 2f, buttonDiameter, buttonDiameter);
//			onPosition = Width - px - buttonDiameter;
//			offPosition = px;

//			if (internalSwitchState == MaterialSwitchState.On)
//			{
//				Button.X = onPosition;
//			}
//		}

//		private void animateToState(MaterialSwitchState state, Action<MaterialSwitch> completion = null)
//		{
//			UserInteractionEnabled = false;
//			UIView.Animate(duration: 0.15f,
//				delay: 0.05,
//				options: UIViewAnimationOptions.CurveEaseInOut,
//				animation: () =>
//				{
//					var s = this;
//					s.Button.X = state == MaterialSwitchState.On ? s.onPosition + s.bounceOffset : s.offPosition - s.bounceOffset;
//					s.styleForState(state);
//				},
//				completion: () =>
//				{
//					UIView.Animate(duration: 0.15f,
//						animation: () =>
//						{
//							var s = this;
//							s.Button.X = state == MaterialSwitchState.On ? s.onPosition : s.offPosition;
//						},
//						completion: () =>
//						{
//							var s = this;
//							s.UserInteractionEnabled = true;
//							if (completion != null)
//							{
//								completion(s);
//							}
//						});
//				});
//		}

//		#endregion

//	}
//}
