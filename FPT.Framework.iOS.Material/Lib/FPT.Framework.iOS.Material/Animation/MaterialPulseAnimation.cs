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

	public static partial class MaterialAnimation
	{
		internal static void pulseExpandAnimation(CALayer layer, CALayer visualLayer, UIColor pulseColor, nfloat pulseOpacity, CGPoint point, nfloat width, nfloat height, ref Stack<CAShapeLayer> pulseLayers, PulseAnimation pulseAnimation)
		{
			if (pulseAnimation != PulseAnimation.None)
			{
				nfloat n = pulseAnimation == PulseAnimation.Center ? width < height ? width : height : width < height ? height : width;
				var bLayer = new CAShapeLayer();
				var pLayer = new CAShapeLayer();
				bLayer.AddSublayer(pLayer);
				pulseLayers.Push(bLayer);
				visualLayer.AddSublayer(bLayer);
				MaterialAnimation.AnimationDisabled(() =>
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

				var duration = pulseAnimation == PulseAnimation.Center ? 0.16125 : 0325;
				switch (pulseAnimation)
				{
					case PulseAnimation.CenterWithBacking:
					case PulseAnimation.Backing:
					case PulseAnimation.AtPointWithBacking:
						bLayer.AddAnimation(MaterialAnimation.BackgroundColor(pulseColor.ColorWithAlpha(pulseOpacity / 2), duration), null);
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
						pLayer.AddAnimation(MaterialAnimation.Scale(1, duration), null);
						break;
					default:
						break;
				}
				MaterialAnimation.Delay(duration, () =>
				{
					bLayer.SetValueForKey(NSObject.FromObject(true), new NSString("animated"));
				});
			}
		}

		internal static void pulseContractAnimation(CALayer layer, CALayer visualLayer, UIColor pulseColor, ref Stack<CAShapeLayer> pulseLayers, PulseAnimation pulseAnimation)
		{
			var bLayer = pulseLayers.Pop();
			if (bLayer != null)
			{
				var test = bLayer.ValueForKey(new NSString("animated")) as NSNumber;
				var animated = test.BoolValue;

				MaterialAnimation.Delay(animated ? 0 : 15, () =>
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
								bLayer.AddAnimation(MaterialAnimation.BackgroundColor(pulseColor.ColorWithAlpha(0), 0.325), null);
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
								pLayer.AddAnimation(MaterialAnimation.AnimationGroup(new CAAnimation[] {
									MaterialAnimation.Scale(pulseAnimation == PulseAnimation.Center ? 1f : 1.325f),
									MaterialAnimation.BackgroundColor(pulseColor.ColorWithAlpha(0))
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