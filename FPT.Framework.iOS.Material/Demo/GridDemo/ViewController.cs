using System;
using System.Collections.Generic;
using CoreGraphics;
using FPT.Framework.iOS.Material;
using UIKit;

namespace GridDemo
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			ViewController.ViewDidLoad(base);
			// Perform any additional setup after loading the view, typically from a nib.
			prepareLargeCardViewExample();
		}

		private void prepareLargeCardViewExample()
		{
			var image = UIImage.FromBundle(name: "CosmicMindInverted");


			var cardView = new MaterialPulseView(frame: new CGRect(16, 100, View.Bounds.Width - 32, 400));
			cardView.PulseColor = MaterialColor.BlueGrey.Base;
			cardView.Depth = MaterialDepth.Depth1;
			View.AddSubview(cardView);


			var leftImageView = new MaterialView();
			leftImageView.Image = image;
			leftImageView.ContentsGravityPreset = MaterialGravity.ResizeAspectFill;
			cardView.AddSubview(leftImageView);

			var topImageView = new MaterialView();
			topImageView.Image = image;
			topImageView.ContentsGravityPreset = MaterialGravity.ResizeAspectFill;
			cardView.AddSubview(topImageView);

			var bottomImageView = new MaterialView();
			bottomImageView.Image = image;
			bottomImageView.ContentsGravityPreset = MaterialGravity.ResizeAspectFill;
			cardView.AddSubview(bottomImageView);

			var contentView = new MaterialView();
			contentView.BackgroundColor = MaterialColor.Clear;
			cardView.AddSubview(contentView);


			var titleLabel = new UILabel();
			titleLabel.Text = "Material";
			titleLabel.TextColor = MaterialColor.BlueGrey.Darken4;
			titleLabel.BackgroundColor = MaterialColor.Clear;
			contentView.AddSubview(titleLabel);


			image = MaterialIcon.CM.Add;
			var moreButton = new IconButton();
			moreButton.ContentEdgeInsetsPreset = MaterialEdgeInset.None;
			moreButton.PulseColor = MaterialColor.BlueGrey.Darken4;
			moreButton.TintColor = MaterialColor.BlueGrey.Darken4;
			moreButton.SetImage(image:image, forState: UIControlState.Normal);
			moreButton.SetImage(image:image, forState: UIControlState.Highlighted);
			contentView.AddSubview(moreButton);

			var detailLabel = new UILabel();
			detailLabel.Lines = 0;
			detailLabel.LineBreakMode = UILineBreakMode.TailTruncation;
			detailLabel.Font = RobotoFont.RegularWithSize(12);
			detailLabel.Text = "Express your creativity with Material, an animation and graphics framework for Google's Material Design and Apple's Flat UI in Swift.";
			detailLabel.TextColor = MaterialColor.BlueGrey.Darken4;
			detailLabel.BackgroundColor = MaterialColor.Clear;
			contentView.AddSubview(detailLabel);

			var alarmLabel = new UILabel();
			alarmLabel.Font = RobotoFont.RegularWithSize(12);
			alarmLabel.Text = "34 min";
			alarmLabel.TextColor = MaterialColor.BlueGrey.Darken4;
			alarmLabel.BackgroundColor = MaterialColor.Clear;
			contentView.AddSubview(alarmLabel);


			image = UIImage.FromBundle(name: "ic_alarm_white").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
			var alarmButton = new IconButton();
			alarmButton.ContentEdgeInsetsPreset = MaterialEdgeInset.None;
			alarmButton.PulseColor = MaterialColor.BlueGrey.Darken4;
			alarmButton.TintColor = MaterialColor.Red.Base;
			alarmButton.SetImage(image: image, forState: UIControlState.Normal);
			alarmButton.SetImage(image: image, forState: UIControlState.Highlighted);
			contentView.AddSubview(alarmButton);

			leftImageView.Grid().Rows = 7;
			leftImageView.Grid().Columns = 6;


			topImageView.Grid().Rows = 4;
			topImageView.Grid().Columns = 6;
			topImageView.Grid().Offset.Columns = 6;


			bottomImageView.Grid().Rows = 3;
			bottomImageView.Grid().Offset.Rows = 4;
			bottomImageView.Grid().Columns = 6;
			bottomImageView.Grid().Offset.Columns = 6;


			contentView.Grid().Rows = 5;
			contentView.Grid().Offset.Rows = 7;


			cardView.Grid().Axis.Direction = GridAxisDirection.None;
			cardView.Grid().Spacing = 4;
			cardView.Grid().Views = new List<UIView> {
				leftImageView,
				topImageView,
				bottomImageView,
				contentView
			};


			titleLabel.Grid().Rows = 3;
			titleLabel.Grid().Columns = 8;


			moreButton.Grid().Rows = 3;
			moreButton.Grid().Columns = 2;
			moreButton.Grid().Offset.Columns = 10;


			detailLabel.Grid().Rows = 6;
			detailLabel.Grid().Offset.Rows = 3;


			alarmLabel.Grid().Rows = 3;
			alarmLabel.Grid().Columns = 8;
			alarmLabel.Grid().Offset.Rows = 9;


			alarmButton.Grid().Rows = 3;
			alarmButton.Grid().Offset.Rows = 9;
			alarmButton.Grid().Columns = 2;
			alarmButton.Grid().Offset.Columns = 10;


			contentView.Grid().Spacing = 8;
			contentView.Grid().Axis.Direction = GridAxisDirection.None;
			contentView.Grid().ContentInsetPreset = MaterialEdgeInset.Square3;
			contentView.Grid().Views = new List<UIView> {
				titleLabel,
				moreButton,
				detailLabel,
				alarmLabel,
				alarmButton
			};

		}
}
}
