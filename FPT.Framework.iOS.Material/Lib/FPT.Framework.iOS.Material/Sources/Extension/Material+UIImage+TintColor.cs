﻿// MIT/X11 License
//
// Material+UIImage+TintColor.cs
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

namespace FPT.Framework.iOS.Material
{
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
