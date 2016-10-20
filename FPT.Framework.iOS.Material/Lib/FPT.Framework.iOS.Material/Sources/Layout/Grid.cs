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
using System.Collections.Generic;
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

		private Grid Grid { get; set; }

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
				Grid.Reload();
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
				Grid.Reload();
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
				Grid.Reload();
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
				Grid.Reload();
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

		public bool Deferred { get; set; } = false;

		internal UIView Context { get; set; }

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
				Reload();
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
				Reload();
			}
		}

		public GridOffset Offset { get; private set; }

		public GridAxis Axis { get; private set; }

		private EdgeInsetsPreset mLayoutEdgeInsetsPreset = EdgeInsetsPreset.None;
		public EdgeInsetsPreset LayoutEdgeInsetsPreset
		{
			get
			{
				return mLayoutEdgeInsetsPreset;
			}
			set
			{
				mLayoutEdgeInsetsPreset = value;
				LayoutEdgeInsets = Convert.EdgeInsetsPresetToValue(mLayoutEdgeInsetsPreset);
			}
		}

		private UIEdgeInsets mLayoutEdgeInsets = Convert.EdgeInsetsPresetToValue(EdgeInsetsPreset.None);
		public UIEdgeInsets LayoutEdgeInsets
		{
			get
			{
				return mLayoutEdgeInsets;
			}
			set
			{
				mLayoutEdgeInsets = value;
				Reload();
			}
		}

		private EdgeInsetsPreset mContentEdgeInsetPreset = EdgeInsetsPreset.None;
		public EdgeInsetsPreset ContentEdgeInsetPreset
		{
			get
			{
				return mContentEdgeInsetPreset;
			}
			set
			{
				mContentEdgeInsetPreset = value;
				ContentEdgeInset = Convert.EdgeInsetsPresetToValue(mContentEdgeInsetPreset);
			}
		}

		private UIEdgeInsets mContentEdgeInset = Convert.EdgeInsetsPresetToValue(EdgeInsetsPreset.None);
		public UIEdgeInsets ContentEdgeInset
		{
			get
			{
				return mContentEdgeInset;
			}
			set
			{
				mContentEdgeInset = value;
				Reload();
			}
		}

		private InterimSpacePreset mInterimSpacePreset = InterimSpacePreset.None;
		public InterimSpacePreset InterimSpacePreset
		{
			get
			{
				return mInterimSpacePreset;
			}
			set
			{
				mInterimSpacePreset = value;
				InterimSpace = Convert.InterimSpacePresetToValue(mInterimSpacePreset);
			}
		}

		private nfloat mInterimSpace;
		public nfloat InterimSpace
		{
			get
			{
				return mInterimSpace;
			}
			set
			{
				mInterimSpace = value;
				Reload();
			}
		}

		private List<UIView> mViews = new List<UIView>();
		public List<UIView> Views
		{
			get
			{
				return mViews;
			}
			set
			{
				mViews = value;
				Reload();
			}
		}

		#endregion

		#region CONSTRUCTORS

		public Grid(UIView context, int rows = 0, int columns = 0, nfloat interimSpace = default(nfloat))
		{
			this.Context = context;
			this.Rows = rows;
			this.Columns = columns;
			this.InterimSpace = interimSpace;
			Offset = new GridOffset(this);
			Axis = new GridAxis(this);
		}

		protected Grid(IntPtr ptr) : base() { }

		#endregion

		#region FUNCTIONS

		public void Begin()
		{
			Deferred = true;
		}
		public void Commit()
		{
			Deferred = false;
			Reload();
		}

		public void Reload()
		{
			if (Deferred) return;

			var count = Views.Count;

			if (count <= 0) return;

			var n = 0;
			var i = 0;
			foreach (var v in Views)
			{
				var canvas = Context;
				if (canvas == null) return;

				if (canvas != v.Superview)
				{
					v.RemoveFromSuperview();
					canvas.AddSubview(v);
				}

				// Forces the views to adjust accordingly to size changes, ie: UILabel.
				if (v is UILabel)
				{
					(v as UILabel).SizeToFit();
				}
				switch (Axis.Direction)
				{
					case GridAxisDirection.Horizontal:
						{
							int c = v.Grid().Columns == 0 ? Axis.Columns / count : v.Grid().Columns;
							int co = v.Grid().Offset.Columns;
							nfloat w = (canvas.Bounds.Width - ContentEdgeInset.Left - ContentEdgeInset.Right - LayoutEdgeInsets.Left + InterimSpace) / ((nfloat)Axis.Columns);

							v.SetX(((nfloat)i + n + co) * w + ContentEdgeInset.Left + LayoutEdgeInsets.Left);
							v.SetY(ContentEdgeInset.Top + LayoutEdgeInsets.Top);
							v.SetWidth(w * ((nfloat)c) - InterimSpace);
							v.SetHeight(canvas.Bounds.Height - ContentEdgeInset.Top - ContentEdgeInset.Bottom - LayoutEdgeInsets.Top - LayoutEdgeInsets.Bottom);

							n += c + co - 1;
						}
						break;
					case GridAxisDirection.Vertical:
						{
							int r = v.Grid().Rows == 0 ? Axis.Rows / count : v.Grid().Rows;
							int ro = v.Grid().Offset.Rows;
							nfloat h = (canvas.Bounds.Height - ContentEdgeInset.Top - ContentEdgeInset.Bottom - LayoutEdgeInsets.Top - LayoutEdgeInsets.Bottom + InterimSpace) / ((nfloat)Axis.Rows);

							v.SetX(ContentEdgeInset.Left + LayoutEdgeInsets.Left);
							v.SetY(((nfloat)i + n + ro) * h + ContentEdgeInset.Top + LayoutEdgeInsets.Top);
							v.SetWidth(canvas.Bounds.Width - ContentEdgeInset.Left - ContentEdgeInset.Right - LayoutEdgeInsets.Left - LayoutEdgeInsets.Right);
							v.SetHeight(h * ((nfloat)r) - InterimSpace);

							n += r + ro - 1;
						}
						break;
					case GridAxisDirection.None:
						{
							int r = v.Grid().Rows == 0? Axis.Rows/count : v.Grid().Rows;
							int ro = v.Grid().Offset.Rows;

							int c = v.Grid().Columns == 0? Axis.Columns/count: v.Grid().Columns;
							int co = v.Grid().Offset.Columns;


							nfloat w = (canvas.Bounds.Width - ContentEdgeInset.Left - ContentEdgeInset.Right - LayoutEdgeInsets.Left - LayoutEdgeInsets.Right + InterimSpace) / ((nfloat)Axis.Columns);
							nfloat h = (canvas.Bounds.Height - ContentEdgeInset.Top - ContentEdgeInset.Bottom - LayoutEdgeInsets.Top - LayoutEdgeInsets.Bottom + InterimSpace) / ((nfloat)Axis.Rows);

							v.SetX(((nfloat)co) * w + ContentEdgeInset.Left + LayoutEdgeInsets.Left);
							v.SetY(((nfloat)ro) * h + ContentEdgeInset.Top + LayoutEdgeInsets.Top);
							v.SetWidth(w * ((nfloat)c) - InterimSpace);
							v.SetHeight(h * ((nfloat)r) - InterimSpace);
						}
						break;
					default:
						break;
				}

				i += 1;
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
				return new Grid(view).Handle;
			});

			return ObjCRuntime.Runtime.GetNSObject(v) as Grid;
		}

		public static EdgeInsetsPreset LayoutEdgeInsetsPreset(this UIView view)
		{
			return view.Grid().LayoutEdgeInsetsPreset;
		}
		public static void SetLayoutEdgeInsetsPreset(this UIView view, EdgeInsetsPreset value)
		{
			view.Grid().LayoutEdgeInsetsPreset = value;
		}

		public static UIEdgeInsets LayoutEdgeInsets(this UIView view)
		{
			return view.Grid().LayoutEdgeInsets;
		}
		public static void SetLayoutEdgeInsets(this UIView view, UIEdgeInsets value)
		{
			view.Grid().LayoutEdgeInsets = value;
		}
	}
}
