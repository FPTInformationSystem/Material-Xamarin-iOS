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
		internal static void pulseExpandAnimation(CALayer layer, CALayer visualLayer, UIColor pulseColor, nfloat pulseOpacity, CGPoint point, nfloat width, nfloat height, ref Queue<CAShapeLayer> pulseLayers, PulseAnimation pulseAnimation)
		{
			if (pulseAnimation != PulseAnimation.None)
			{
				nfloat n = pulseAnimation == PulseAnimation.Center ? width < height ? width : height : width < height ? height : width;
				var bLayer = new CAShapeLayer();
				var pLayer = new CAShapeLayer();
				bLayer.AddSublayer(pLayer);
				pulseLayers.Enqueue(bLayer);
				visualLayer.AddSublayer(bLayer);
				Animation.AnimationDisabled(() =>
				{
					bLayer.Frame = visualLayer.Bounds;
					pLayer.Bounds = new CGRect(0, 0, n, n);
					switch (pulseAnimation)
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
					pLayer.BackgroundColor = pulseColor.ColorWithAlpha(pulseOpacity).CGColor;
					pLayer.Transform = CATransform3D.MakeFromAffine(CGAffineTransform.MakeScale(0, 0));
				});
				bLayer.SetValueForKey(NSObject.FromObject(false), new NSString("animated"));

				var duration = pulseAnimation == PulseAnimation.Center ? 0.16125 : 0.325;
				switch (pulseAnimation)
				{
					case PulseAnimation.CenterWithBacking:
					case PulseAnimation.Backing:
					case PulseAnimation.AtPointWithBacking:
						bLayer.AddAnimation(Animation.BackgroundColor(pulseColor.ColorWithAlpha(pulseOpacity / 2), duration), null);
						break;
					default:
						break;
				}
				switch (pulseAnimation)
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

		internal static void pulseContractAnimation(CALayer layer, CALayer visualLayer, UIColor pulseColor, ref Queue<CAShapeLayer> pulseLayers, PulseAnimation pulseAnimation)
		{
			CAShapeLayer bLayer = null;
			try
			{
				bLayer = pulseLayers.Dequeue();
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
						switch (pulseAnimation)
						{
							case PulseAnimation.CenterWithBacking:
							case PulseAnimation.Backing:
							case PulseAnimation.AtPointWithBacking:
								bLayer.AddAnimation(Animation.BackgroundColor(pulseColor.ColorWithAlpha(0), 0.325), null);
								break;
							default:
								break;
						}

						switch (pulseAnimation)
						{
							case PulseAnimation.Center:
							case PulseAnimation.CenterWithBacking:
							case PulseAnimation.CenterRadialBeyondBounds:
							case PulseAnimation.AtPoint:
							case PulseAnimation.AtPointWithBacking:
								pLayer.AddAnimation(Animation.AnimationGroup(new CAAnimation[] {
									Animation.Scale(pulseAnimation == PulseAnimation.Center ? 1f : 1.325f),
									Animation.BackgroundColor(pulseColor.ColorWithAlpha(0))
								}, duration), null);
								break;
							default:
								break;
						}
					}
				});
			}
		}
	}
}