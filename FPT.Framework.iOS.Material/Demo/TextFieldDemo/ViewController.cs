using System;
using CoreGraphics;
using FPT.Framework.iOS.Material;
using UIKit;

namespace TextFieldDemo
{
	public partial class ViewController : UIViewController
	{

		private TextField nameField { get; set;}
		private ErrorTextField emailField { get; set;}
		private TextField passwordField { get; set;}

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			prepareView();
			prepareNameField();
			prepareEmailField();
			preparePasswordField();
			prepareResignResponderButton();
		}

		void prepareView()
		{
			View.BackgroundColor = Color.White;
		}

		void prepareNameField()
		{
			nameField = new TextField();
			nameField.Text = "Quan P";
			nameField.Placeholder = "Name";
			nameField.Detail = "Your given name";
			nameField.TextAlignment = UITextAlignment.Center;
			nameField.ClearButtonMode = UITextFieldViewMode.WhileEditing;

			View.Layout(nameField).Top(40).Horizontally(left: 40, right: 40);
		}

		void prepareEmailField()
		{
			emailField = new ErrorTextField(new CGRect(40, 120, View.Bounds.Width - 80, 32));
			emailField.Placeholder = "Email";
			emailField.Detail = "Error, incorrect email";
			emailField.EnableClearIconButton = true;
			emailField.Delegate = new ViewControllerTextFieldDelegate(this);

			emailField.PlaceholderNormalColor = Color.Amber.Darken4;
			emailField.PlaceholderActiveColor = Color.Pink.Base;
			emailField.DividerNormalColor = Color.Cyan.Base;

			View.AddSubview(emailField);
		}

		void preparePasswordField()
		{
			passwordField = new TextField();
			passwordField.Placeholder = "Password";
			passwordField.Detail = "At least 8 characters";
			passwordField.ClearButtonMode = UITextFieldViewMode.WhileEditing;
			passwordField.EnableVisibilityIconButton = true;

			// Setting the visibilityFlatButton color.
			passwordField.VisibilityIconButton.TintColor = Color.Green.Base.ColorWithAlpha(passwordField.SecureTextEntry ? 0.38f : 0.54f);

			View.Layout(passwordField).Top(200).Horizontally(left: 40, right: 40);
		}

		void prepareResignResponderButton()
		{
			nameField.ResignFirstResponder();
			emailField.ResignFirstResponder();
			passwordField.ResignFirstResponder();
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
}
