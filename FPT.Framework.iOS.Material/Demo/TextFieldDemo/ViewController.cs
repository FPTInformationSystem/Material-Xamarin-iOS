using System;
using CoreGraphics;
using FPT.Framework.iOS.Material;
using UIKit;

namespace TextFieldDemo
{
	public partial class ViewController : UIViewController
	{

		private TextField nameField { get; set; }
		private ErrorTextField emailField { get; set; }
		private TextField passwordField { get; set; }

		nfloat constant = 32;

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			View.BackgroundColor = Color.Grey.Lighten5;
			prepareNameField();
			prepareEmailField();
			preparePasswordField();
			prepareResignResponderButton();
		}

		public override void WillRotate(UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			emailField.SetWidth(View.Height() - 2 * constant);
		}

		void prepareNameField()
		{
			nameField = new TextField();
			nameField.Text = "Quan P";
			nameField.Placeholder = "Name";
			nameField.Detail = "Your given name";
			nameField.IsClearIconButtonEnabled = true;

			var leftView = new UIImageView();
			leftView.Image = Icon.Phone.TintWithColor(Color.Blue.Base);

			nameField.LeftView = leftView;
			nameField.LeftViewMode = UITextFieldViewMode.Always;

			View.Layout(nameField).Top(4 * constant).Horizontally(left: constant, right: constant);
		}

		void prepareEmailField()
		{
			emailField = new ErrorTextField(new CGRect(constant, 7*constant, View.Width() - 2*constant, constant));
			emailField.Placeholder = "Email";
			emailField.Detail = "Error, incorrect email";
			emailField.IsClearIconButtonEnabled = true;
			emailField.Delegate = new ViewControllerTextFieldDelegate(this);

			var leftView = new UIImageView();
			leftView.Image = Icon.Email.TintWithColor(Color.Blue.Base);

			emailField.LeftView = leftView;
			emailField.LeftViewMode = UITextFieldViewMode.Always;

			//emailField.PlaceholderNormalColor = Color.Amber.Darken4;
			//emailField.PlaceholderActiveColor = Color.Pink.Base;
			//emailField.DividerNormalColor = Color.Cyan.Base;

			View.AddSubview(emailField);
		}

		void preparePasswordField()
		{
			passwordField = new TextField();
			passwordField.Placeholder = "Password";
			passwordField.Detail = "At least 8 characters";
			passwordField.ClearButtonMode = UITextFieldViewMode.WhileEditing;
			passwordField.IsClearIconButtonEnabled = true;
			passwordField.IsVisibilityIconButtonEnabled = true;

			// Setting the visibilityFlatButton color.
			passwordField.VisibilityIconButton.TintColor = Color.Green.Base.ColorWithAlpha(passwordField.SecureTextEntry ? 0.38f : 0.54f);

			View.Layout(passwordField).Top(10*constant).Horizontally(left: constant, right: constant);
		}

		void prepareResignResponderButton()
		{
			var btn = new RaisedButton("Resign", Color.Blue.Base);
			btn.TouchUpInside += (sender, e) =>
			{
				nameField.ResignFirstResponder();
				emailField.ResignFirstResponder();
				passwordField.ResignFirstResponder();
			};
			View.Layout(btn).Width(100).Height(constant).Top(24).Right(24);
		}
	}

	public class ViewControllerTextFieldDelegate : TextFieldDelegate
	{
		ViewController mParent;

		public ViewControllerTextFieldDelegate(ViewController parent) : base()
		{
			mParent = parent;
		}

		public override bool ShouldReturn(UITextField textField)
		{
			if (textField is ErrorTextField)
			{
				(textField as ErrorTextField).IsErrorRevealed = true;
			}
			return true;
		}

		public override bool ShouldBeginEditing(UITextField textField)
		{
			return true;
		}

		public override bool ShouldEndEditing(UITextField textField)
		{
			return true;
		}

		public override void EditingEnded(UITextField textField)
		{
			if (textField is ErrorTextField)
			{
				(textField as ErrorTextField).IsErrorRevealed = false;
			}
		}

		public override bool ShouldClear(UITextField textField)
		{
			if (textField is ErrorTextField)
			{
				(textField as ErrorTextField).IsErrorRevealed = false;
			}
			return true;
		}

		public override bool ShouldChangeCharacters(UITextField textField, Foundation.NSRange range, string replacementString)
		{
			if (textField is ErrorTextField)
			{
				(textField as ErrorTextField).IsErrorRevealed = false;
			}
			return true;
		}
	}
}
