// MIT/X11 License
//
// Material+Obj-C.cs
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
using System.Runtime.InteropServices;
using Foundation;

namespace FPT.Framework.iOS.Material
{
	public static class MaterialObjC
	{
		public static IntPtr MaterialAssociatedObject(IntPtr receiver, IntPtr key, Func<IntPtr> initializer)
		{
			var v = Messaging.objc_getAssociatedObject(receiver, key);
			if (v != IntPtr.Zero)
			{
				return v;
			}
			v = initializer();
			return v;
		}

		public static void MaterialAssociatedObject(IntPtr receiver, IntPtr key, IntPtr value)
		{
			Messaging.objc_setAssociatedObject(receiver, key, value, Messaging.AssociationPolicy.RETAIN);
		}
	}

	public static class Messaging
	{
		internal enum AssociationPolicy
		{
			ASSIGN = 0,
			RETAIN_NONATOMIC = 1,
			COPY_NONATOMIC = 3,
			RETAIN = 01401,
			COPY = 01403,
		}

		[DllImport("/usr/lib/libobjc.dylib")]
		internal static extern IntPtr objc_getAssociatedObject(IntPtr receiver, IntPtr key);

		[DllImport("/usr/lib/libobjc.dylib")]
		internal static extern void objc_setAssociatedObject(IntPtr receiver, IntPtr key, IntPtr value, AssociationPolicy policy);
	}
}
