using System;
using System.Collections.Generic;
using Foundation;
using FPT.Framework.iOS.Material;
using UIKit;

namespace TableCardViewDemo
{
	public partial class ViewController : UIViewController
	{
		private struct Item
		{
			public string Text { get; set;}
			public string Detail { get; set; }
			public UIImage Image { get; set; }

			public Item (string text, string detail, UIImage image)
			{
				Text = text;
				Detail = detail;
				Image = image;
			}
		}

		private class ViewControllerSource : UITableViewSource
		{
			private ViewController mParent;

			public ViewControllerSource(ViewController parent)
			{
				mParent = parent;
			}

			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = new MaterialTableViewCell(UITableViewCellStyle.Subtitle, "Cell");
				var item = mParent.items[indexPath.Row];

				cell.SelectionStyle = UITableViewCellSelectionStyle.None;
				cell.TextLabel.Text = item.Text;
				cell.TextLabel.Font = RobotoFont.Regular;
				cell.DetailTextLabel.Text = item.Detail;
				cell.DetailTextLabel.Font = RobotoFont.Regular;
				cell.DetailTextLabel.TextColor = MaterialColor.Grey.Darken1;
				cell.ImageView.Image = item.Image.ResizeToWidth(40f);
				cell.ImageView.Layer.CornerRadius = 5;
				cell.ImageView.Layer.MasksToBounds = true;

				return cell;
			}

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return mParent.items.Count;
			}

			public override nint NumberOfSections(UITableView tableView)
			{
				return 1;
			}

			public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
				return 80f;
			}
		}

		private UITableView tableView {get; set;} = new UITableView();

		private List<Item> items = new List<Item>();

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			prepareView();
			prepareItems();
			prepareTableView();
			prepareCardView();
		}

		void prepareView()
		{
			View.BackgroundColor = MaterialColor.White;
		}

		void prepareItems()
		{
			items.Add(new Item(text: "Summer BBQ", detail: "Wish I could come, but I am out of town this weekend.", image: UIImage.FromBundle(name: "Profile1")));
			items.Add(new Item(text: "Birthday gift", detail: "Have any ideas about what we should get Heidi for her birthday?", image: UIImage.FromBundle(name: "Profile2")));
			items.Add(new Item(text: "Brunch this weekend?", detail: "I'll be in your neighborhood doing errands this weekend.", image: UIImage.FromBundle(name: "Profile3")));
			items.Add(new Item(text: "Giants game", detail: "Are we on this weekend for the game?", image: UIImage.FromBundle(name: "Profile4")));
			items.Add(new Item(text: "Recipe to try", detail: "We should eat this: Squash, Corn and tomatillo Tacos.", image: UIImage.FromBundle(name: "Profile5")));
			items.Add(new Item(text: "Interview", detail: "The candidate will be arriving at 11:30, are you free?", image: UIImage.FromBundle(name: "Profile6")));
			items.Add(new Item(text: "Book recommendation", detail: "I found the book title, Surely You’re Joking, Mr. Feynman!", image: UIImage.FromBundle(name: "Profile7")));
			items.Add(new Item(text: "Oui oui", detail: "Do you have Paris recommendations? Have you ever been?", image: UIImage.FromBundle(name: "Profile8")));
		}

		void prepareTableView()
		{
			tableView.RegisterClassForCellReuse(typeof(MaterialTableViewCell), "Cell");
			tableView.Source = new ViewControllerSource(this);
		}

		void prepareCardView()
		{
			var cardView = new CardView();
			cardView.BackgroundColor = MaterialColor.Grey.Lighten5;
			cardView.CornerRadiusPreset = MaterialRadius.Radius1;
			cardView.Divider = false;
			cardView.ContentInsetPreset = MaterialEdgeInset.None;
			cardView.LeftButtonsInsetPreset = MaterialEdgeInset.Square2;
			cardView.RightButtonsInsetPreset = MaterialEdgeInset.Square2;
			cardView.ContentViewInsetPreset = MaterialEdgeInset.None;

			var titleLabel = new UILabel();
			titleLabel.Font = RobotoFont.MediumWithSize(20);
			titleLabel.Text = "Messages";
			titleLabel.TextAlignment = UITextAlignment.Center;
			titleLabel.TextColor = MaterialColor.BlueGrey.Darken4;

			var v = new UIView();
			v.BackgroundColor = MaterialColor.Blue.Accent1;

			var closeButton = new FlatButton();
			closeButton.SetTitle("Close", UIControlState.Normal);
			closeButton.SetTitleColor(MaterialColor.Blue.Accent3, UIControlState.Normal);

			var image = MaterialIcon.CM.Settings;
			var settingButton = new IconButton();
			settingButton.TintColor = MaterialColor.Blue.Accent3;
			settingButton.SetImage(image, UIControlState.Normal);
			settingButton.SetImage(image, UIControlState.Highlighted);

			cardView.TitleLabel = titleLabel;
			cardView.ContentView = tableView;
			cardView.LeftButtons = new UIButton[] { closeButton};
			cardView.RightButtons = new UIButton[] { settingButton };

			View.Layout(cardView).Edges(left: 10f, right: 10f, top: 100f, bottom: 100f);
		}
}
}
