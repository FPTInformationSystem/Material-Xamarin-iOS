using System;
using System.Collections.Generic;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Foundation;

namespace FPT.Framework.iOS.Material
{

	public enum PulseAnimation
	{
		None,
		Center,
		CenterWithBacking,
		CenterRadialBeyondBounds,
		Backing,
		AtPoint,
		AtPointWithBacking
	}

	public static partial class Animation
	{
		internal static void pulseExpandAnimation(CALayer layer, CALayer visualLayer, CGPoint point, nfloat width, nfloat height, Pulse pulse)
		{
			if (pulse.Animation != PulseAnimation.None)
			{
				nfloat n = pulse.Animation == PulseAnimation.Center ? width < height ? width : height : width < height ? height : width;
				var bLayer = new CAShapeLayer();
				var pLayer = new CAShapeLayer();
				bLayer.AddSublayer(pLayer);
				pulse.Layers.Enqueue(bLayer);
				visualLayer.AddSublayer(bLayer);
				Animation.AnimationDisabled(() =>
				{
					bLayer.Frame = visualLayer.Bounds;
					pLayer.Bounds = new CGRect(0, 0, n, n);
					switch (pulse.Animation)
					{
						case PulseAnimation.Center:
						case PulseAnimation.CenterWithBacking:
						case PulseAnimation.CenterRadialBeyondBounds:
							pLayer.Position = new CGPoint(width / 2, height / 2);
							break;
						default:
							pLayer.Position = point;
							break;
					}
					pLayer.CornerRadius = n / 2;
					pLayer.BackgroundColor = pulse.Color.ColorWithAlpha(pulse.Opacity).CGColor;
					pLayer.Transform = CATransform3D.MakeFromAffine(CGAffineTransform.MakeScale(0, 0));
				});
				bLayer.SetValueForKey(NSObject.FromObject(false), new NSString("animated"));

				var duration = pulse.Animation == PulseAnimation.Center ? 0.16125 : 0.325;
				switch (pulse.Animation)
				{
					case PulseAnimation.CenterWithBacking:
					case PulseAnimation.Backing:
					case PulseAnimation.AtPointWithBacking:
						bLayer.AddAnimation(Animation.BackgroundColor(pulse.Color.ColorWithAlpha(pulse.Opacity / 2), duration), null);
						break;
					default:
						break;
				}
				switch (pulse.Animation)
				{
					case PulseAnimation.Center:
					case PulseAnimation.CenterWithBacking:
					case PulseAnimation.CenterRadialBeyondBounds:
					case PulseAnimation.AtPoint:
					case PulseAnimation.AtPointWithBacking:
						pLayer.AddAnimation(Animation.Scale(1, duration), null);
						break;
					default:
						break;
				}
				Animation.Delay(duration, () =>
				{
					bLayer.SetValueForKey(NSObject.FromObject(true), new NSString("animated"));
				});
			}
		}

		internal static void pulseContractAnimation(CALayer layer, CALayer visualLayer, Pulse pulse)
		{
			CAShapeLayer bLayer = null;
			try
			{
				bLayer = pulse.Layers.Dequeue();
			}
			catch (Exception) {
				return;
			}
			if (bLayer != null)
			{
				var test = bLayer.ValueForKey(new NSString("animated")) as NSNumber;
				var animated = test.BoolValue;

				Animation.Delay(animated ? 0 : 0.15, () =>
				{
					var pLayer = bLayer.Sublayers[0] as CAShapeLayer;
					if (pLayer != null)
					{
						var duration = 0.3125;
						switch (pulse.Animation)
						{
							case PulseAnimation.CenterWithBacking:
							case PulseAnimation.Backing:
							case PulseAnimation.AtPointWithBacking:
								bLayer.AddAnimation(Animation.BackgroundColor(pulse.Color.ColorWithAlpha(0), 0.325), null);
								break;
							default:
								break;
						}

						switch (pulse.Animation)
						{
							case PulseAnimation.Center:
							case PulseAnimation.CenterWithBacking:
							case PulseAnimation.CenterRadialBeyondBounds:
							case PulseAnimation.AtPoint:
							case PulseAnimation.AtPointWithBacking:
								pLayer.AddAnimation(Animation.AnimationGroup(new CAAnimation[] {
									Animation.Scale(pulse.Animation == PulseAnimation.Center ? 1f : 1.325f),
									Animation.BackgroundColor(pulse.Color.ColorWithAlpha(0))
								}, duration), null);
								break;
							default:
								break;
						}

						Animation.Delay(duration, () =>
						{
							pLayer.RemoveFromSuperLayer();
							bLayer.RemoveFromSuperLayer();
						});
					}
				});
			}
		}
	}
}