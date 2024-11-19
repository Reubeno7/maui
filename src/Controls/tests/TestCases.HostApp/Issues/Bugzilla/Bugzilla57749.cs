namespace Maui.Controls.Sample.Issues
{
	[Issue(IssueTracker.Bugzilla, 57749, "After enabling a disabled button it is not clickable", PlatformAffected.UWP)]
	public class Bugzilla57749 : TestContentPage
	{
		protected override void Init()
		{
			button1.Text = "Click me";
			button1.AutomationId = "btnClick";
			button1.IsEnabled = false;
			button1.Clicked += Button1_Clicked1;
			this.Content = button1;
		}
		Button button1 = new Button();

		private async void Button1_Clicked1(object sender, EventArgs e)
		{
			var customAlert = new CustomAlertPage();
			await Navigation.PushModalAsync(customAlert);
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await Task.Delay(100);
			button1.IsEnabled = true;
		}
	}

	public class CustomAlertPage : ContentPage
	{
		public CustomAlertPage()
		{
			var stackLayout = new StackLayout
			{
				Padding = new Thickness(20),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			var titleLabel = new Label
			{
				Text = "Button test",
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center
			};

			var messageLabel = new Label
			{
				Text = "Button was clicked",
				FontSize = 16,
				HorizontalOptions = LayoutOptions.Center,
				AutomationId = "Button was clicked"
			};

			var okButton = new Button
			{
				Text = "Ok",
				HorizontalOptions = LayoutOptions.Center,
				AutomationId = "Ok"
			};
			okButton.Clicked += async (s, e) => await Navigation.PopModalAsync();

			stackLayout.Children.Add(titleLabel);
			stackLayout.Children.Add(messageLabel);
			stackLayout.Children.Add(okButton);

			Content = stackLayout;
		}
	}
}