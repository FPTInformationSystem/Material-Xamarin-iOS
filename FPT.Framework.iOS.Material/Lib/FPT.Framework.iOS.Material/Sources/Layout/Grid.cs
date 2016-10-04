// MIT/X11 License
//
// EmptyClass.cs
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
using Foundation;
using UIKit;

namespace FPT.Framework.iOS.Material
{
	public enum GridAxisDirection
	{
		None, Horizontal, Vertical
	}

	public class GridAxis
	{

		#region PROPERTIES

		private Grid Grid { get; set;}

		public bool Inerited { get; set; } = false;

		public GridAxisDirection Direction { get; set; } = GridAxisDirection.Horizontal;

		private int mRows;
		public int Rows
		{
			get
			{
				return mRows;
			}
			set
			{
				mRows = value;
				Grid.ReloadLayout();
			}
		}

		private int mColumns;
		public int Columns
		{
			get
			{
				return mColumns;
			}
			set
			{
				mColumns = value;
				Grid.ReloadLayout();
			}
		}

		#endregion

		#region CONSTRUCTORS

		public GridAxis(Grid grid, int rows = 12, int columns = 12)
		{
			this.Grid = grid;
			this.Rows = rows;
			this.Columns = columns;
		}

		#endregion
	}

	public class GridOffset
	{

		#region PROPERTIES

		private Grid Grid { get; set; }

		public bool Inerited { get; set; } = false;

		private int mRows;
		public int Rows
		{
			get
			{
				return mRows;
			}
			set
			{
				mRows = value;
				Grid.ReloadLayout();
			}
		}

		private int mColumns;
		public int Columns
		{
			get
			{
				return mColumns;
			}
			set
			{
				mColumns = value;
				Grid.ReloadLayout();
			}
		}

		#endregion

		#region CONSTRUCTORS

		public GridOffset(Grid grid, int rows = 0, int columns = 0)
		{
			this.Grid = grid;
			this.Rows = rows;
			this.Columns = columns;
		}

		#endregion
	}

	public class Grid : NSObject
	{

		#region PROPERTIES

		private int mRows;
		public int Rows
		{
			get
			{
				return mRows;
			}
			set
			{
				mRows = value;
				ReloadLayout();
			}
		}

		private int mColumns;
		public int Columns
		{
			get
			{
				return mColumns;
			}
			set
			{
				mColumns = value;
				ReloadLayout();
			}
		}

		public GridOffset Offset { get; private set;}

		public GridAxis Axis { get; private set;}

		private MaterialEdgeInset mLayoutInsetPreset = MaterialEdgeInset.None;
		public MaterialEdgeInset LayoutInsetPreset
		{
			get
			{
				return mLayoutInsetPreset;
			}
			set
			{
				mLayoutInsetPreset = value;
				LayoutInset = Convert.MaterialEdgeInsetToValue(mLayoutInsetPreset);
			}
		}

		private UIEdgeInsets mLayoutInset = Convert.MaterialEdgeInsetToValue(MaterialEdgeInset.None);
		public UIEdgeInsets LayoutInset
		{
			get
			{
				return mLayoutInset;
			}
			set
			{
				mLayoutInset = value;
				ReloadLayout();
			}
		}

		private MaterialEdgeInset mContentInsetPreset = MaterialEdgeInset.None;
		public MaterialEdgeInset ContentInsetPreset
		{
			get
			{
				return mContentInsetPreset;
			}
			set
			{
				mContentInsetPreset = value;
				ContentInset = Convert.MaterialEdgeInsetToValue(mContentInsetPreset);
			}
		}

		private UIEdgeInsets mContentInset = Convert.MaterialEdgeInsetToValue(MaterialEdgeInset.None);
		public UIEdgeInsets ContentInset
		{
			get
			{
				return mContentInset;
			}
			set
			{
				mContentInset = value;
				ReloadLayout();
			}
		}

		private MaterialSpacing mSpacingPreset = MaterialSpacing.None;
		public MaterialSpacing SpacingPreset
		{
			get
			{
				return mSpacingPreset;
			}
			set
			{
				mSpacingPreset = value;
				Spacing = Convert.MaterialSpacingToValue(mSpacingPreset);

			}
		}

		private nfloat mSpacing;
		public nfloat Spacing
		{
			get
			{
				return mSpacing;
			}
			set
			{
				mSpacing = value;
				ReloadLayout();
			}
		}

		private UIView[] mViews;
		public UIView[] Views
		{
			get
			{
				return mViews;
			}
			set
			{
				mViews = value;
				ReloadLayout();
			}
		}

		#region CONSTRUCTORS

		public Grid(int rows = 12, int columns = 12, nfloat spacing = default(nfloat))
		{
			this.Rows = rows;
			this.Columns = columns;
			this.Spacing = spacing;
			Offset = new GridOffset(this);
			Axis = new GridAxis(this);
		}

		protected Grid(IntPtr ptr) : base()
		{
		}

		#endregion

		#endregion

		#region FUNCTIONS

		public void ReloadLayout()
		{
			var v = Views;
			if (v != null)
			{
				var gc = Axis.Inerited ? Columns : Axis.Columns;
				var gr = Axis.Inerited ? Rows : Axis.Rows;
				var n = 0;
				for (var i = 0; i < v.Length; i++)
				{
					var view = v[i];
					var sv = (view as UIKit.UIView).Superview;
					if (sv != null)
					{
						sv.LayoutIfNeeded();
						switch (Axis.Direction)
						{
							case GridAxisDirection.Horizontal:
								{
									nfloat w = (sv.Bounds.Width - ContentInset.Left - ContentInset.Right - LayoutInset.Left + Spacing) / ((nfloat) gc);
									int c = view.Grid().Columns;
									int co = view.Grid().Offset.Columns;
									nfloat vh = sv.Bounds.Height - ContentInset.Top - ContentInset.Bottom - LayoutInset.Top - LayoutInset.Bottom;
									nfloat vl = ((nfloat)i + n + co) * w + ContentInset.Left + LayoutInset.Left;
									nfloat vw = w * ((nfloat)c) - Spacing;
									(view as UIKit.UIView).Frame = new CGRect(vl, ContentInset.Top + LayoutInset.Top, vw, vh);
									n += c + co - 1;
								}
								break;
							case GridAxisDirection.Vertical:
								{
									nfloat h = (sv.Bounds.Height - ContentInset.Top - ContentInset.Bottom - LayoutInset.Top - LayoutInset.Bottom + Spacing) / ((nfloat) gr);
									int r = view.Grid().Rows;
									int ro = view.Grid().Offset.Rows;
									nfloat vw = sv.Bounds.Width - ContentInset.Left - ContentInset.Right - LayoutInset.Left - LayoutInset.Right;
									nfloat vt = ((nfloat)i + n + ro) * h + ContentInset.Top + LayoutInset.Top;
									nfloat vh = h * ((nfloat)r) - Spacing;
									(view as UIKit.UIView).Frame = new CGRect(ContentInset.Left + LayoutInset.Left, vt, vw, vh);
									n += r + ro - 1;
								}
								break;
							case GridAxisDirection.None:
								{
									nfloat w = (sv.Bounds.Width - ContentInset.Left - ContentInset.Right - LayoutInset.Left - LayoutInset.Right + Spacing) / ((nfloat) gc);
									int c = view.Grid().Columns;
									int co = view.Grid().Offset.Columns;
									nfloat h = (sv.Bounds.Height - ContentInset.Top - ContentInset.Bottom - LayoutInset.Top - LayoutInset.Bottom + Spacing) / ((nfloat) gr);
									int r = view.Grid().Rows;
									int ro = view.Grid().Offset.Rows;
									nfloat vt = ((nfloat)ro) * h + ContentInset.Top + LayoutInset.Top;
									nfloat vl = ((nfloat)co) * w + ContentInset.Left + LayoutInset.Left;
									nfloat vh = h * ((nfloat)r) - Spacing;
									nfloat vw = w * ((nfloat)c) - Spacing;
									(view as UIKit.UIView).Frame = new CGRect(vl, vt, vw, vh);
								}
								break;
							default:
								break;
						}
					}
				}
			}
		}

		#endregion
	}

	public static partial class Extensions
	{
		static NSObject sGridKey = new NSObject();
		public static Grid Grid(this UIView view)
		{
			var v = MaterialObjC.MaterialAssociatedObject(view.Handle, sGridKey.Handle, () =>
			{
				return new Grid().Handle;
			});

			return ObjCRuntime.Runtime.GetNSObject(v) as Grid;

		}
	}
}
