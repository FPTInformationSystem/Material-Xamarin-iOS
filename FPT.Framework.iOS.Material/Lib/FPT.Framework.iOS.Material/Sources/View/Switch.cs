// MIT/X11 License
//
// MaterialSwitch.cs
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
using UIKit;
using CoreGraphics;
using CoreAnimation;
using ObjCRuntime;
using Foundation;
using System.ComponentModel;

namespace FPT.Framework.iOS.Material
{
	public enum SwitchStyle
	{
		LightContent, Default
	}

	public enum SwitchState
	{
		On, Off
	}

	public enum SwitchSize
	{
		Small, Default, Large
	}

	public interface SwitchDelegate
	{
		void SwitchStateChanged(Switch control, SwitchState state);
	}

	[Register("Switch"), DesignTimeVisible(true)]
	public class Switch : UIControl
	{

		public bool WillLayout
		{
			get
			{
				return 0 < this.Width() && 0 < this.Height() && Superview != null;
			}
		}

		private SwitchState internalSwitchState { get; set; } = SwitchState.Off;

		private nfloat trackThickness { get; set; } = 0;

		private nfloat buttonDiameter { get; set; } = 0;

		private nfloat onPosition { get; set; } = 0;

		private nfloat offPosition { get; set; } = 0;

		private nfloat bounceOffset { get; set; } = 3;

		public SwitchDelegate Delegate { get; set; }

		private bool mBounceable = true;
		public bool Bounceable
		{
			get
			{
				return mBounceable;
			}
			set
			{
				mBounceable = value;
				bounceOffset = mBounceable ? 3 : 0;
			}
		}

		private UIColor mButtonOnColor = Color.Clear;
		public UIColor ButtonOnColor
		{
			get
			{
				return mButtonOnColor;
			}
			set
			{
				mButtonOnColor = value;
				styleForState(SwitchState);
			}
		}

		private UIColor mTrackOnColor = Color.Clear;
		public UIColor TrackOnColor
		{
			get
			{
				return mTrackOnColor;
			}
			set
			{
				mTrackOnColor = value;
				styleForState(SwitchState);
			}
		}

		private UIColor mButtonOffColor = Color.Clear;
		public UIColor ButtonOffColor
		{
			get
			{
				return mButtonOffColor;
			}
			set
			{
				mButtonOffColor = value;
				styleForState(SwitchState);
			}
		}

		private UIColor mTrackOffColor = Color.Clear;
		public UIColor TrackOffColor
		{
			get
			{
				return mTrackOffColor;
			}
			set
			{
				mTrackOffColor = value;
				styleForState(SwitchState);
			}
		}

		private UIColor mButtonOnDisabledColor = Color.Clear;
		public UIColor ButtonOnDisabledColor
		{
			get
			{
				return mButtonOnDisabledColor;
			}
			set
			{
				mButtonOnDisabledColor = value;
				styleForState(SwitchState);
			}
		}

		private UIColor mTrackOnDisabledColor = Color.Clear;
		public UIColor TrackOnDisabledColor
		{
			get
			{
				return mTrackOnDisabledColor;
			}
			set
			{
				mTrackOnDisabledColor = value;
				styleForState(SwitchState);
			}
		}

		private UIColor mButtonOffDisabledColor = Color.Clear;
		public UIColor ButtonOffDisabledColor
		{
			get
			{
				return mButtonOffDisabledColor;
			}
			set
			{
				mButtonOffDisabledColor = value;
				styleForState(SwitchState);
			}
		}

		private UIColor mTrackOffDisabledColor = Color.Clear;
		public UIColor TrackOffDisabledColor
		{
			get
			{
				return mTrackOffDisabledColor;
			}
			set
			{
				mTrackOffDisabledColor = value;
				styleForState(SwitchState);
			}
		}

		private CAShapeLayer mTrackLayer;
		public CAShapeLayer TrackLayer
		{
			get
			{
				return mTrackLayer;
			}
			set
			{
				mTrackLayer = value;
				//prepareTrack();
			}
		}

		private FabButton mButton;
		public FabButton Button

		{
			get
			{
				return mButton;
			}
			private set
			{
				mButton = value;
				//prepareButton();
			}
		}

		public override bool Enabled
		{
			get
			{
				return base.Enabled;
			}
			set
			{
				base.Enabled = value;
				styleForState(internalSwitchState);
			}
		}

		public bool On
		{
			get
			{
				return internalSwitchState == SwitchState.On;	
			}
			set
			{
				SetOn(value, true);
			}
		}

		public SwitchState SwitchState
		{
			get
			{
				return internalSwitchState;
			}
			set
			{
				if (internalSwitchState != value)
				{
					internalSwitchState = value;
				}
			}
		}

		private SwitchStyle mSwitchStyle = SwitchStyle.Default;
		public SwitchStyle SwitchStyle
		{
			get
			{
				return mSwitchStyle;
			}
			set
			{
				mSwitchStyle = value;
				switch (mSwitchStyle)
				{
					case SwitchStyle.LightContent:
						{
							ButtonOnColor = Color.Blue.Darken2;
							TrackOnColor = Color.Blue.Lighten3;
							ButtonOffColor = Color.BlueGrey.Lighten4;
							TrackOffColor = Color.BlueGrey.Lighten3;
							ButtonOnDisabledColor = Color.Grey.Lighten2;
							TrackOnDisabledColor = Color.Grey.Lighten3;
							ButtonOffDisabledColor = Color.Grey.Lighten2;
							TrackOffDisabledColor = Color.Grey.Lighten3;
						}
						break;
					case SwitchStyle.Default:
						{
							ButtonOnColor = Color.Blue.Lighten1;
							TrackOnColor = Color.Blue.Lighten2.ColorWithAlpha(0.5f);
							ButtonOffColor = Color.BlueGrey.Lighten3;
							TrackOffColor = Color.BlueGrey.Lighten4.ColorWithAlpha(0.5f);
							ButtonOnDisabledColor = Color.Grey.Darken3;
							TrackOnDisabledColor = Color.Grey.Lighten1.ColorWithAlpha(0.2f);
							ButtonOffDisabledColor = Color.Grey.Darken3;
							TrackOffDisabledColor = Color.Grey.Lighten1.ColorWithAlpha(0.2f);
						}
						break;
				}
			}
		}

		private SwitchSize mSwitchSize = SwitchSize.Default;
		public SwitchSize SwitchSize
		{
			get
			{
				return mSwitchSize;
			}
			set
			{
				mSwitchSize = value;
				switch (mSwitchSize)
				{
					case SwitchSize.Small:
						{
							trackThickness = 13;
							buttonDiameter = 18;
							Frame = new CGRect(0, 0, 30, 25);
						}
						break;
					case SwitchSize.Default:
						{
							trackThickness = 17;
							buttonDiameter = 24;
							Frame = new CGRect(0, 0, 40, 30);		
						}
						break;
					case SwitchSize.Large:
						{
							trackThickness = 23;
							buttonDiameter = 31;
							Frame = new CGRect(0, 0, 50, 40);
						}
						break;
				}
			}
		}

		public override CGRect Frame
		{
			get
			{
				return base.Frame;
			}
			set
			{
				base.Frame = value;
				layoutSwitch();
			}
		}

		public override CGRect Bounds
		{
			get
			{
				return base.Bounds;
			}
			set
			{
				base.Bounds = value;
				layoutSwitch();
			}
		}

		#region CONSTRUCTORS

		protected Switch(IntPtr handle) : base(handle)
		{
			TrackLayer = new CAShapeLayer();
			Button = new FabButton();
			prepareTrack();
			prepareButton();
			prepareSwitchSize(SwitchSize.Default);
			prepareSwitchStyle(SwitchStyle.LightContent);
			prepareSwitchState(SwitchState.Off);
		}

		public Switch(Foundation.NSCoder coder) : base(coder)
		{
			//TrackLayer = new CAShapeLayer();
			//Button = new FabButton();
			prepareTrack();
			prepareButton();
			prepareSwitchSize(SwitchSize.Default);
			prepareSwitchStyle(SwitchStyle.LightContent);
			prepareSwitchState(SwitchState.Off);
		}

		public Switch(CGRect frame) : base(frame)
		{
			////TrackLayer = new CAShapeLayer();
			////Button = new FabButton();
			prepareTrack();
			prepareButton();
			prepareSwitchSize(SwitchSize.Default);
			prepareSwitchStyle(SwitchStyle.LightContent);
			prepareSwitchState(SwitchState.Off);
		}

		public Switch(SwitchState state = SwitchState.Off, SwitchStyle style = SwitchStyle.Default, SwitchSize size = SwitchSize.Default) : base(CGRect.Empty)
		{
			//TrackLayer = new CAShapeLayer();
			//Button = new FabButton();
			prepareTrack();
			prepareButton();
			prepareSwitchSize(size);
			prepareSwitchStyle(style);
			prepareSwitchState(state);
		}

		#endregion

		#region FUNCTIONS

		public override void WillMoveToSuperview(UIView newsuper)
		{
			base.WillMoveToSuperview(newsuper);
			styleForState(internalSwitchState);
		}

		public override CGSize IntrinsicContentSize
		{
			get
			{
				switch (SwitchSize)
				{
					case SwitchSize.Small:
						return new CGSize(30, 25);
					case SwitchSize.Default:
						return new CGSize(40, 30);
					case SwitchSize.Large:
						return new CGSize(50, 40);
				}

				return base.IntrinsicContentSize;
			}
		}

		public void Toggle(Action<Switch> completion = null)
		{
			SetSwitchState(internalSwitchState == SwitchState.On ? SwitchState.Off : SwitchState.On, true, completion);
		}

		public void SetOn(bool on, bool animated, Action<Switch> completion = null)
		{
			SetSwitchState(on ? SwitchState.On : SwitchState.Off, animated, completion);
		}

		public void SetSwitchState(SwitchState state, bool animated = true, Action<Switch> completion = null)
		{
			if (Enabled && internalSwitchState != state)
			{
				internalSwitchState = state;
				if (animated)
				{
					animateToState(state, (Switch s) =>
					{
						s.SendActionForControlEvents(UIControlEvent.ValueChanged);
						if (completion != null)
						{
							completion(s);
						}
						if (s.Delegate != null)
						{
							s.Delegate.SwitchStateChanged(this, this.internalSwitchState);
						}
					});
				}
				else
				{
					Button.SetX( state == SwitchState.On ? onPosition : offPosition);
					styleForState(state);
					SendActionForControlEvents(UIControlEvent.ValueChanged);
					if (completion != null)
					{
						completion(this);
					}
					if (Delegate != null)
					{
						Delegate.SwitchStateChanged(this, this.internalSwitchState);
					}
				}
			}
		}

		void handleTouchUpInside(object sender, EventArgs e)
		{
			Toggle();
		}

		[Export("handleTouchDragInside:fromSender:ForEvent")]
		void handleTouchDragInside(FabButton sender, UIEvent e)
		{
			var touches = e.TouchesForView(sender).ToArray<UITouch>();
			if (touches == null)
				return;
			var v = touches[0];
			if (v != null)
			{
				nfloat q = NMath.Max(NMath.Min(sender.X() + v.LocationInView(sender).X - v.PreviousLocationInView(sender).X, onPosition), offPosition);
				if (q != sender.X())
				{
					sender.SetX(q);
				}
			}
		}

		[Export("handleTouchUpOutsideOrCanceled:fromSender:ForEvent")]
		void handleTouchUpOutsideOrCanceled(FabButton sender, UIEvent e)
		{
			var touches = e.TouchesForView(sender).ToArray<UITouch>();
			if (touches == null)
				return;
			var v = touches[0];
			if (v != null)
			{
				nfloat q = sender.X() + v.LocationInView(sender).X - v.PreviousLocationInView(sender).X;
				SetSwitchState(q > (this.Width() - Button.Width()) / 2f ? SwitchState.On : SwitchState.Off, true);
			}
		}

		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			if (TrackLayer.Frame.Contains(Layer.ConvertPointToLayer(touches.ToArray<UITouch>()[0].LocationInView(this), Layer)))
			{
				SetOn(internalSwitchState != SwitchState.On, true);
			}
		}

		private void prepareTrack()
		{
			Layer.AddSublayer(TrackLayer);
		}

		private void prepareButton()
		{
			Button.PulseAnimation = PulseAnimation.None;
			Button.TouchUpInside += handleTouchUpInside;
			Button.AddTarget(this, new Selector("handleTouchDragInside:fromSender:ForEvent"), UIControlEvent.TouchDragInside);
			//Button.TouchDragInside += handleTouchDragInside;
			//Button.TouchCancel += handleTouchUpOutsideOrCanceled;
			//Button.TouchUpOutside += handleTouchUpOutsideOrCanceled;
			Button.AddTarget(this, new Selector("handleTouchUpOutsideOrCanceled:fromSender:ForEvent"), UIControlEvent.TouchCancel);
			Button.AddTarget(this, new Selector("handleTouchUpOutsideOrCanceled:fromSender:ForEvent"), UIControlEvent.TouchUpOutside);
			AddSubview(Button);
		}

		private void prepareSwitchState(SwitchState state)
		{
			SetSwitchState(state, false);
		}

		private void prepareSwitchStyle(SwitchStyle style)
		{
			SwitchStyle = style;
		}

		private void prepareSwitchSize(SwitchSize size)
		{
			SwitchSize = size;
		}

		private void styleForState(SwitchState state)
		{
			if (Enabled)
			{
				updateColorForState(state);
			}
			else
			{
				updateColorForDisabledState(state);
			}
		}

		private void updateColorForState(SwitchState state)
		{
			if (state == SwitchState.On)
			{
				Button.BackgroundColor = ButtonOnColor;
				TrackLayer.BackgroundColor = TrackOnColor.CGColor;
			}
			else
			{
				Button.BackgroundColor = ButtonOffColor;
				TrackLayer.BackgroundColor = TrackOffColor.CGColor;
			}
		}

		private void updateColorForDisabledState(SwitchState state)
		{
			if (state == SwitchState.On)
			{
				Button.BackgroundColor = ButtonOnDisabledColor;
				TrackLayer.BackgroundColor = TrackOnDisabledColor.CGColor;
			}
			else
			{
				Button.BackgroundColor = ButtonOffDisabledColor;
				TrackLayer.BackgroundColor = TrackOffDisabledColor.CGColor;
			}
		}

		private void layoutSwitch()
		{
			if (TrackLayer == null)
			{
				TrackLayer = new CAShapeLayer();
			}
			if (Button == null)
			{
				Button = new FabButton();
			}

			nfloat w = 0;
			switch (SwitchSize)
			{
				case SwitchSize.Small:
					{
						w = 30;
					}
					break;
				case SwitchSize.Default:
					{
						w = 40;
					}
					break;
				case SwitchSize.Large:
					{
						w = 50;
					}
					break;
			}

			nfloat px = (this.Width() - w) / 2f;

			TrackLayer.Frame = new CGRect(px, (this.Height() - trackThickness) / 2f, w, trackThickness);
			TrackLayer.CornerRadius = NMath.Min(TrackLayer.Frame.Height, TrackLayer.Frame.Width) / 2f;

			Button.Frame = new CGRect(px, (this.Height() - buttonDiameter) / 2f, buttonDiameter, buttonDiameter);
			onPosition = this.Width() - px - buttonDiameter;
			offPosition = px;

			if (internalSwitchState == SwitchState.On)
			{
				Button.SetX (onPosition);
			}
		}

		private void animateToState(SwitchState state, Action<Switch> completion = null)
		{
			UserInteractionEnabled = false;
			UIView.Animate(duration: 0.15f,
				delay: 0.05,
				options: UIViewAnimationOptions.CurveEaseInOut,
				animation: () =>
				{
					var s = this;
					s.Button.SetX( state == SwitchState.On ? s.onPosition + s.bounceOffset : s.offPosition - s.bounceOffset);
					s.styleForState(state);
				},
				completion: () =>
				{
					UIView.Animate(duration: 0.15f,
						animation: () =>
						{
							var s = this;
							s.Button.SetX( state == SwitchState.On ? s.onPosition : s.offPosition);
						},
						completion: () =>
						{
							var s = this;
							s.UserInteractionEnabled = true;
							if (completion != null)
							{
								completion(s);
							}
						});
				});
		}

		#endregion

	}
}
