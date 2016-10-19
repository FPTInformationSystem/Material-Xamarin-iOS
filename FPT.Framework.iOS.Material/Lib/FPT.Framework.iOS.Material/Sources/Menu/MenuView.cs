//// MIT/X11 License
////
//// MenuView.cs
////
//// Author:
////       Pham Quan <QuanP@fpt.com.vn, mr.pquan@gmail.com> at FPT Software Service Center.
////
//// Copyright (c) 2016 FPT Information System.
////
//// Permission is hereby granted, free of charge, to any person obtaining a copy
//// of this software and associated documentation files (the "Software"), to deal
//// in the Software without restriction, including without limitation the rights
//// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//// copies of the Software, and to permit persons to whom the Software is
//// furnished to do so, subject to the following conditions:
////
//// The above copyright notice and this permission notice shall be included in
//// all copies or substantial portions of the Software.
////
//// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//// THE SOFTWARE.
//using System;
//using CoreGraphics;
//using UIKit;

//namespace FPT.Framework.iOS.Material
//{

//	public abstract class MenuViewDelegate : MaterialDelegate
//	{
//		public virtual void menuViewDidTapOutside(MenuView menuView) { }
//	}

//	public class MenuView : MaterialPulseView
//	{

//		#region PROPERTIES

//		public Menu Menu { get; private set; } = new Menu();

//		#endregion

//		#region CONSTRUCTORS

//		public MenuView() : base(CoreGraphics.CGRect.Empty)
//		{
			
//		}

//		#endregion

//		#region FUNCTIONS

//		public override void PrepareView()
//		{
//			base.PrepareView();
//			PulseAnimation = PulseAnimation.None;
//			ClipsToBounds = false;
//			BackgroundColor = null;
//		}

//		/**
//		Opens the menu with a callback.
//		- Parameter completion: An Optional callback that is executed when
//		all menu items have been opened.
//		*/
//		public void Open(Action completion = null)
//		{
//			if (Menu.Views[0].UserInteractionEnabled)
//			{
//				Menu.Views[0].UserInteractionEnabled = false;
//				Menu.Open(completion: (UIView v) =>
//				{
//					if (Menu.Views[Menu.Views.Length - 1] == v)
//					{
//						Menu.Views[0].UserInteractionEnabled = true;
//						if (completion != null)
//						{
//							completion();
//						}
//					}
//				});
//			}
//		}

//		/**
//		Closes the menu with a callback.
//		- Parameter completion: An Optional callback that is executed when
//		all menu items have been closed.
//		*/
//		public void Close(Action completion = null)
//		{
//			if (Menu.Views[0].UserInteractionEnabled)
//			{
//				Menu.Views[0].UserInteractionEnabled = false;
//				Menu.Close(completion: (UIView v) =>
//				{
//					if (Menu.Views[Menu.Views.Length - 1] == v)
//					{
//						Menu.Views[0].UserInteractionEnabled = true;
//						if (completion != null)
//						{
//							completion();
//						}
//					}
//				});
//			}
//		}

//		public override UIKit.UIView HitTest(CGPoint point, UIEvent uievent)
//		{
//			/**
//			Since the subviews will be outside the bounds of this view,
//			we need to look at the subviews to see if we have a hit.
//			*/
//			if (Hidden)
//			{
//				return null;
//			}

//			foreach (var v in Subviews)
//			{
//				var p = v.ConvertPointFromView(point, this);
//				if (v.Bounds.Contains(p))
//				{
//					return v.HitTest(p, uievent);	
//				}
//			}

//			if (Menu.Opened && Delegate is MenuViewDelegate)
//			{
//				(Delegate as MenuViewDelegate).menuViewDidTapOutside(this);
//			}

//			return base.HitTest(point, uievent);
//		}

//		#endregion
//	}
//}
