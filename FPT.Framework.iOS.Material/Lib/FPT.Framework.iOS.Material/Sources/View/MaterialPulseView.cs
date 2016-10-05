// MIT/X11 License
//
// MaterialPulseView.cs
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
using CoreAnimation;
using CoreGraphics;
using UIKit;

namespace FPT.Framework.iOS.Material
{
	public class MaterialPulseView : MaterialView
	{

		#region VARIABLES

		private Queue<CAShapeLayer> mPulseLayers = new Queue<CAShapeLayer>();
		private nfloat mPulseOpacity = 0.25f;
		private UIColor mPulseColor = MaterialColor.Grey.Base;
		private PulseAnimation mPulseAnimation = PulseAnimation.AtPointWithBacking;

		#endregion

		#region PROPERTIES

		public Queue<CAShapeLayer> PulseLayers
		{
			get
			{
				return mPulseLayers;
			}
			private set
			{
				mPulseLayers = value;
			}
		}

		public nfloat PulseOpacity
		{
			get
			{
				return mPulseOpacity;
			}
			set
			{
				mPulseOpacity = value;
			}
		}

		public UIColor PulseColor
		{
			get
			{
				return mPulseColor;
			}
			set
			{
				mPulseColor = value;
			}
		}

		public PulseAnimation PulseAnimation
		{
			get
			{
				return mPulseAnimation;
			}
			set
			{
				mPulseAnimation = value;
				VisualLayer.MasksToBounds = mPulseAnimation != PulseAnimation.CenterRadialBeyondBounds;
			}
		}

		#endregion

		#region EVENTS

		public void pulse(CGPoint? point = null)
		{
			var p = point == null ? new CGPoint(Width / 2, Height / 2) : point.Value;
			MaterialAnimation.pulseExpandAnimation(layer: Layer, visualLayer: VisualLayer, pulseColor: PulseColor, pulseOpacity: PulseOpacity, point: p, width: Width, height: Height, pulseLayers: ref mPulseLayers, pulseAnimation: PulseAnimation);
			MaterialAnimation.Delay(0.35f, () =>
			{
				MaterialAnimation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulseColor: PulseColor, pulseLayers: ref mPulseLayers, pulseAnimation: PulseAnimation);
			});
		}

		public override void TouchesBegan(Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesBegan(touches, evt);
			UITouch touch = touches.AnyObject as UITouch;
			MaterialAnimation.pulseExpandAnimation(layer: Layer, visualLayer: VisualLayer, pulseColor: PulseColor, pulseOpacity: PulseOpacity, point: Layer.ConvertPointToLayer(point: touch.LocationInView(this), layer: Layer), width: Width, height: Height, pulseLayers: ref mPulseLayers, pulseAnimation: PulseAnimation);
		}

		public override void TouchesEnded(Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesEnded(touches, evt);
			MaterialAnimation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulseColor: PulseColor, pulseLayers: ref mPulseLayers, pulseAnimation: PulseAnimation);

		}

		public override void TouchesCancelled(Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesCancelled(touches, evt);
			MaterialAnimation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulseColor: PulseColor, pulseLayers: ref mPulseLayers, pulseAnimation: PulseAnimation);
		}

		#endregion

		#region CONSTRUCTORS

		public MaterialPulseView(Foundation.NSCoder coder) : base(coder) { }

		public MaterialPulseView(CGRect frame) : base(frame) { }

		#endregion
	}
}
