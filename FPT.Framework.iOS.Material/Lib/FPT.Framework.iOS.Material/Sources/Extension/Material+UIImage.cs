// MIT/X11 License
//
// Material+UIImage.cs
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
using System.Linq;
using Accelerate;
using CoreGraphics;
using UIKit;

namespace FPT.Framework.iOS.Material
{
	public static partial class Extensions
	{
		public static UIImage ClearImage(this UIImage self)
		{
			UIGraphics.BeginImageContextWithOptions(new CoreGraphics.CGSize(36, 36), false, 0);
			var image = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();
			return image;
		}
	}

	public static partial class Extensions
	{
		public static UIImage ImageWithColor(UIColor color, CGSize size)
		{
			var rect = new CGRect(0, 0, size.Width, size.Height);
			UIGraphics.BeginImageContextWithOptions(size, false, 0);
			color.SetFill();
			UIGraphics.RectFill(rect);
			var image = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();
			return image;
		}
	}

	public static partial class Extensions
	{
		private static vImageBuffer createEffectBuffer(CGContext context)
		{
			return new vImageBuffer()
			{
				Data = context.AsBitmapContext().Data,
				Width = (int)context.AsBitmapContext().Width,
				Height = (int)context.AsBitmapContext().Height,
				BytesPerRow = (int)context.AsBitmapContext().BytesPerRow
			};
		}

		public static UIImage FilterBlur(this UIImage self, nfloat blurRadius = default(nfloat), UIColor tintColor = null, nfloat saturationDeltaFactor = default(nfloat))
		{
			var effectImage = self;

			nfloat screenScale = Device.Scale;
			var imageRect = new CGRect(CGPoint.Empty, self.Size);
			var hasBlur = blurRadius > nfloat.Epsilon;
			var hasSaturationChange = NMath.Abs(saturationDeltaFactor - 1f) > nfloat.Epsilon;

			if (hasBlur || hasSaturationChange)
			{
				UIGraphics.BeginImageContextWithOptions(self.Size, false, screenScale);
				var effectInContext = UIGraphics.GetCurrentContext();
				effectInContext.ScaleCTM(1f, -1f);
				effectInContext.TranslateCTM(0, -self.Size.Height);
				effectInContext.DrawImage(imageRect, self.CGImage);
				var effectInBuffer = createEffectBuffer(effectInContext);

				UIGraphics.BeginImageContextWithOptions(self.Size, false, screenScale);
				var effectOutContext = UIGraphics.GetCurrentContext();
				var effectOutBuffer = createEffectBuffer(effectOutContext);

				if (hasBlur)
				{
					nfloat inputRadius = blurRadius * screenScale;
					UInt32 radius = System.Convert.ToUInt32(NMath.Floor(inputRadius * 3f * NMath.Sqrt(2 * NMath.PI) / 4f + 0.5f));
					if (radius % 2 != 1)
					{
						radius += 1;
					}

					var imageEdgeExtendFlags = vImageFlags.EdgeExtend;

					vImage.BoxConvolveARGB8888(ref effectInBuffer, ref effectOutBuffer, IntPtr.Zero, 0, 0, radius, radius, Pixel8888.Zero, imageEdgeExtendFlags);
					vImage.BoxConvolveARGB8888(ref effectInBuffer, ref effectOutBuffer, IntPtr.Zero, 0, 0, radius, radius, Pixel8888.Zero, imageEdgeExtendFlags);
					vImage.BoxConvolveARGB8888(ref effectInBuffer, ref effectOutBuffer, IntPtr.Zero, 0, 0, radius, radius, Pixel8888.Zero, imageEdgeExtendFlags);
				}

				var effectImageBuffersAreSwapped = false;

				if (hasSaturationChange)
				{
					nfloat s = saturationDeltaFactor;
					var floatingPointSaturationMatrix = new nfloat[] {
						0.0722f + 0.9278f * s,  0.0722f - 0.0722f * s,  0.0722f - 0.0722f * s,  0,
						0.7152f - 0.7152f * s,  0.7152f + 0.2848f * s,  0.7152f - 0.7152f * s,  0,
						0.2126f - 0.2126f * s,  0.2126f - 0.2126f * s,  0.2126f + 0.7873f * s,  0,
						0,                    0,                    0,                          1
					};

					nfloat divisor = 256f;
					var matrixSize = floatingPointSaturationMatrix.Length;
					var saturationMatrix = Enumerable.Repeat<Int16>(0, matrixSize).ToArray();

					for (var i = 0; i < matrixSize; i++)
					{
						saturationMatrix[i] = (Int16)NMath.Round(floatingPointSaturationMatrix[i] * divisor);
					}

					if (hasBlur)
					{
						vImage.MatrixMultiplyARGB8888(ref effectOutBuffer, ref effectInBuffer, saturationMatrix, (int)divisor, null, null, vImageFlags.NoFlags);
						effectImageBuffersAreSwapped = true;
					}
					else
					{
						vImage.MatrixMultiplyARGB8888(ref effectOutBuffer, ref effectInBuffer, saturationMatrix, (int)divisor, null, null, vImageFlags.NoFlags);
					}
				}

				if (!effectImageBuffersAreSwapped)
				{
					effectImage = UIGraphics.GetImageFromCurrentImageContext();
				}

				UIGraphics.EndImageContext();

				if (effectImageBuffersAreSwapped)
				{
					effectImage = UIGraphics.GetImageFromCurrentImageContext();
				}

				UIGraphics.EndImageContext();
			}

			UIGraphics.BeginImageContextWithOptions(self.Size, false, screenScale);
			var outputContext = UIGraphics.GetCurrentContext();
			outputContext.ScaleCTM(1f, -1f);
			outputContext.TranslateCTM(0, self.Size.Height);

			outputContext.DrawImage(imageRect, effectImage.CGImage);

			if (hasBlur)
			{
				outputContext.SaveState();
				outputContext.DrawImage(imageRect, effectImage.CGImage);
				outputContext.RestoreState();
			}

			if (tintColor != null)
			{
				outputContext.SaveState();
				outputContext.SetFillColor(tintColor.CGColor);
				outputContext.FillRect(imageRect);
				outputContext.RestoreState();
			}

			var outputImage = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();

			return outputImage;
		}
	}

	public static partial class Extensions
	{

		private static UIImage internalResize(this UIImage self, nfloat tw = default(nfloat), nfloat th = default(nfloat))
		{
			nfloat? w = null, h = null;

			if (tw > 0)
			{
				h = self.Size.Height * tw / self.Size.Width;
			}
			else if (th > 0)
			{
				w = self.Size.Width * th / self.Size.Height;
			}

			UIImage g;
			var t = new CGRect(0, 0, w ?? tw, h ?? th);
			UIGraphics.BeginImageContextWithOptions(t.Size, false, Device.Scale);
			self.Draw(t, CGBlendMode.Normal, 1f);
			g = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();

			return g;
		}

		public static UIImage ResizeToWidth(this UIImage self, nfloat width)
		{
			return self.internalResize(width, 0);
		}

		public static UIImage ResizeToHeight(this UIImage self, nfloat height)
		{
			return self.internalResize(0, height);
		}
	}

	public static partial class Extensions
	{
		public static UIImage TintWithColor(this UIImage image, UIColor color)
		{
			UIGraphics.BeginImageContextWithOptions(image.Size, false, Device.Scale);
			var context = UIGraphics.GetCurrentContext();

			context.ScaleCTM(1f, -1f);
			context.TranslateCTM(0, -image.Size.Height);

			context.SetBlendMode(CGBlendMode.Multiply);

			var rect = new CGRect(0, 0, image.Size.Width, image.Size.Height);
			context.ClipToMask(rect, image.CGImage);
			color.SetFill();
			context.FillRect(rect);

			var result = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();
			return result.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
		}
	}
}
