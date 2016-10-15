// MIT/X11 License
//
// Material+UIImage+Resize.cs
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
using CoreGraphics;
using UIKit;
namespace FPT.Framework.iOS.Material
{
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
			UIGraphics.BeginImageContextWithOptions(t.Size, false, MaterialDevice.Scale);
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
}
