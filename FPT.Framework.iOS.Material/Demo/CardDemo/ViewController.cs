using System;
using FPT.Framework.iOS.Material;
using UIKit;
using CoreFoundation;
using System.Collections.Generic;

namespace CardDemo
{
	public partial class ViewController : UIViewController
	{

		private Card card { get; set; }
		private UILabel contentView { get; set; }
		private Bar bottomBar { get; set; }
		private UILabel dateLabel { get; set; }
		private IconButton favoriteButton { get; set; }

		private Toolbar toolbar { get; set; }
		private IconButton moreButton { get; set; }

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			View.BackgroundColor = Color.Grey.Lighten5;

			prepareDateFormatter();
			prepareDateLabel();
			prepareFavoriteButton();
			prepareMoreButton();
			prepareToolbar();
			prepareContentView();
			prepareBottomBar();
			prepareImageCard();
		}

		private void prepareDateFormatter()
		{

			//dateFormatter = DateFormatter()

			//dateFormatter.dateStyle = .medium

			//dateFormatter.timeStyle = .none

		}

		private void prepareDateLabel()
		{
			dateLabel = new UILabel();
			dateLabel.Font = RobotoFont.RegularWithSize(12f);
			dateLabel.TextColor = Color.BlueGrey.Base;
			dateLabel.Text = DateTime.Now.ToLongTimeString();
		}

		private void prepareFavoriteButton()
		{
			favoriteButton = new IconButton(image: Icon.Favorite, tintColor: Color.Red.Base);
		}

		private void prepareMoreButton()
		{
			moreButton = new IconButton(image: Icon.MoreVertical, tintColor: Color.BlueGrey.Base);
		}

		private void prepareToolbar()
		{
			toolbar = new Toolbar(rightViews: new List<UIView> { moreButton });
			toolbar.Title = "Material";
			toolbar.TitleLabel.TextAlignment = UITextAlignment.Left;
			toolbar.Detail = "Build Beautiful Software";
			toolbar.DetailLabel.TextAlignment = UITextAlignment.Left;
			toolbar.DetailLabel.TextColor = Color.BlueGrey.Base;
		}

		private void prepareContentView()
		{
			contentView = new UILabel();
			contentView.Lines = 0;
			contentView.Text = "Material is an animation and graphics framework that is used to create beautiful applications.";
			contentView.Font = RobotoFont.RegularWithSize(14);
		}

		private void prepareBottomBar()
		{
			bottomBar = new Bar();


			bottomBar.LeftViews = new List<UIView> { dateLabel };

			bottomBar.RightViews = new List<UIView> { favoriteButton };

		}

		private void prepareImageCard()
		{
			card = new Card();
			card.Toolbar = toolbar;
			card.ToolbarEdgeInsetsPreset = EdgeInsetsPreset.Square3;

			var edgeInset = card.ToolbarEdgeInsets;
			edgeInset.Bottom = 0;
			edgeInset.Right = 8;
			card.ToolbarEdgeInsets = edgeInset;

			card.ContentView = contentView;
			card.ContentViewEdgeInsetPreset = EdgeInsetsPreset.WideRectangle3;


			card.BottomBar = bottomBar;
			card.BottomBarEdgeInsetsPreset = EdgeInsetsPreset.WideRectangle2;
			View.Layout(card).Horizontally(left: 20, right: 20).Center();
		}
	}
}
