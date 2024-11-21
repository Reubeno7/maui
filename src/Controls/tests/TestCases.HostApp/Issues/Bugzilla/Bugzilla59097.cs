namespace Maui.Controls.Sample.Issues
{
	[Issue(IssueTracker.Bugzilla, 59097, "[Android] Calling PopAsync via TapGestureRecognizer causes an application crash", PlatformAffected.Android)]
	public class Bugzilla59097 : NavigationPage
	{
		public Bugzilla59097() : base(new MainPage())
		{
		}

		public class MainPage : ContentPage
		{
			public MainPage()
			{
				Navigation.PushAsync(new ContentPage
				{
					Content = new Label
					{
						Text = "previous page",
						AutomationId = "PreviousPageLabel" // Added AutomationId
					}
				});
				Navigation.PushAsync(new ToPopPage());
			}

			public class ToPopPage : ContentPage
			{
				public ToPopPage()
				{
					var boxView = new BoxView
					{
						WidthRequest = 100,
						HeightRequest = 100,
						Color = Colors.Red,
						AutomationId = "BoxView"
					};

					var label = new Label
					{
						Text = "BoxView",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						AutomationId = "LabelInsideBoxView" // Unique AutomationId for the Label
					};

					var tapGesture = new TapGestureRecognizer
					{
						NumberOfTapsRequired = 1,
						Command = new Command(PopPageBack)
					};
					boxView.GestureRecognizers.Add(tapGesture);

					// Add the same tap gesture to the label
					var labelTapGesture = new TapGestureRecognizer
					{
						NumberOfTapsRequired = 1,
						Command = new Command(PopPageBack)
					};
					label.GestureRecognizers.Add(labelTapGesture);

					var grid = new Grid
					{
						WidthRequest = 100,
						HeightRequest = 100
					};
					grid.Children.Add(boxView);
					grid.Children.Add(label);

					var layout = new StackLayout();
					layout.Children.Add(grid);

					Content = layout;
				}

				async void PopPageBack(object obj)
				{
					await Navigation.PopAsync(true);
				}
			}
		}
	}
}