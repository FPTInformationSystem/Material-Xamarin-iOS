// MIT/X11 License
//
// MenuItem.cs
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

namespace FPT.Framework.iOS.Material
{
	public class MenuItem : View
	{

		#region PROPERTIES

		public UILabel TitleLabel { get; private set; } = new UILabel();

		public FabButton Button { get; private set; } = new FabButton();

		public String Title
		{
			get
			{
				return TitleLabel.Text;
			}
			set
			{
				TitleLabel.Text = value;
				HideTitleLabel();
			}
		}

		#endregion

		#region CONSTRUCTORS

		public MenuItem()
		{
		}

		#endregion

		#region FUNCTIONS

		public override void Prepare()
		{
			base.Prepare();
			BackgroundColor = null;

			prepareButton();
			prepareTitleLabel();
		}

		public void ShowTitleLabel()
		{
		}

		public void HideTitleLabel()
		{
			TitleLabel.Hidden = true;
		}

		private void prepareButton()
		{
			this.Layout(Button).Edges();
		}

		private void prepareTitleLabel()
		{
			TitleLabel.Font = RobotoFont.RegularWithSize(14);
			TitleLabel.TextAlignment = UITextAlignment.Center;
			TitleLabel.BackgroundColor = Color.White;
			TitleLabel.SetDepthPreset(Button.DepthPreset());
			TitleLabel.SetCornerRadiusPreset(CornerRadiusPreset.Radius1);
			AddSubview(TitleLabel);
		}

		#endregion
	}
}
