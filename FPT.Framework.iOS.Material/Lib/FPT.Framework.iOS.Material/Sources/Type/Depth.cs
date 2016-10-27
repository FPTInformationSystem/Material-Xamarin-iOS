using System;
using CoreGraphics;
using UIKit;
namespace FPT.Framework.iOS.Material
{
	public static partial class Convert
	{
		public static Depth DepthPresetToValue(DepthPreset depth)
		{
			switch (depth)
			{
				case DepthPreset.None:
					return null;
				case DepthPreset.Depth1:
				return new Depth(new UIOffset(0, 0.5f), 0.3f, 0.5f);
				case DepthPreset.Depth2:
					return new Depth(new UIOffset(0, 1), 0.3f, 1);
				case DepthPreset.Depth3:
					return new Depth(new UIOffset(0, 2), 0.3f, 2);
				case DepthPreset.Depth4:
					return new Depth(new UIOffset(0, 4), 0.3f, 4);
				case DepthPreset.Depth5:
					return new Depth(new UIOffset(0, 8), 0.3f, 8);
				default:
					return new Depth(UIOffset.Zero, 0, 0);
			}
		}
	}

	public class Depth
	{
		public UIOffset Offset { get; private set;}
		public float Opacity { get; private set;}
		public nfloat Radius { get; private set;}

		private DepthPreset mPreset = DepthPreset.None;
		public DepthPreset Preset
		{
			get
			{
				return mPreset;
			}
			set
			{
				mPreset = value;

				var depth = Convert.DepthPresetToValue(value);
				Offset = depth.Offset;
				Opacity = depth.Opacity;
				Radius = depth.Radius;
			}
		}

		public Depth(UIOffset offset = default(UIOffset), float opacity = 0, nfloat radius = default(nfloat))
		{
			Offset = offset;
			Opacity = opacity;
			Radius = radius;
		}

		public static readonly Depth Zero = new Depth();
	}

	public enum DepthPreset
	{
		None, Depth1, Depth2, Depth3, Depth4, Depth5
	}
}
