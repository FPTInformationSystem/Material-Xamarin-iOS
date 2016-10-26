// MIT/X11 License
//
// PulseView.cs
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
using Foundation;
using CoreGraphics;
using CoreAnimation;

namespace FPT.Framework.iOS.Material
{
	public class PulseView : View
	{

		#region PROPERTIES

		internal Pulse Pulse { get; private set; } = new Pulse();

		public PulseAnimation PulseAnimation
		{
			get
			{
				return Pulse.Animation;
			}
			set
			{
				Pulse.Animation = value;
			}
		}

		public UIColor PulseColor
		{
			get
			{
				return Pulse.Color;
			}
			set
			{
				Pulse.Color = value;
			}
		}

		public nfloat PulseOpacity
		{
			get
			{
				return Pulse.Opacity;
			}
			set
			{
				Pulse.Opacity = value;
			}
		}

		public void pulse(CGPoint? point = null)
		{
			var p = point == null ? new CGPoint(this.Width() / 2, this.Height() / 2) : point.Value;
			Animation.pulseExpandAnimation(layer: Layer, visualLayer: VisualLayer, point: p, width: this.Width(), height: this.Height(), pulse: Pulse);
			Animation.Delay(0.35f, () =>
			{
				Animation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulse: Pulse);
			});
		}

		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			base.TouchesBegan(touches, evt);
			UITouch touch = touches.AnyObject as UITouch;
			Animation.pulseExpandAnimation(layer: Layer, visualLayer: VisualLayer, point: Layer.ConvertPointToLayer(point: touch.LocationInView(this), layer: Layer), width: this.Width(), height: this.Height(), pulse: Pulse);
		}

		public override void TouchesEnded(NSSet touches, UIEvent evt)
		{
			base.TouchesEnded(touches, evt);
			Animation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulse: Pulse);
		}

		public override void TouchesCancelled(NSSet touches, UIEvent evt)
		{
			base.TouchesCancelled(touches, evt);
			Animation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulse: Pulse);
		}

		#endregion

		public PulseView(Foundation.NSCoder coder) : base(coder)
		{
		}

		public PulseView() : base()
		{
		}

		public PulseView(CGRect frame) : base(frame)
		{
		}
	}
}
