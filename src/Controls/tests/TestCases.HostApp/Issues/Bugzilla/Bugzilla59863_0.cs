namespace Maui.Controls.Sample.Issues
{
	[Issue(IssueTracker.Bugzilla, 59863, "TapGestureRecognizer extremely finicky", PlatformAffected.Android)]
	public class Bugzilla59863_0 : TestContentPage
	{
		int _singleTaps;
		const string SingleTapBoxId = "singleTapView";
		const string Singles = "singles(s)";

		protected override void Init()
		{
			var instructions = new Label
			{
				Text = "Tap the box below several times quickly. "
				+ "The number displayed below should match the number of times you tap the box."
			};

			var singleTapCounter = new Label
			{
				Text = $"{_singleTaps} {Singles} on {SingleTapBoxId}",
				AutomationId = "SingleTapCounterLabel"
			};

			var singleTapBox = new BoxView
			{
				WidthRequest = 100,
				HeightRequest = 100,
				BackgroundColor = Colors.Bisque,
				AutomationId = SingleTapBoxId
			};

			var tapLabel = new Label
			{
				Text = "Tap Here",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Colors.Transparent,
				AutomationId = "TapHereLabel"
			};

			var singleTap = new TapGestureRecognizer
			{
				Command = new Command(() =>
				{
					_singleTaps += 2; // Increment by 2 to simulate double tap
					singleTapCounter.Text = $"{_singleTaps} {Singles} on {SingleTapBoxId}";
				})
			};

			// Add the tap gesture to both the BoxView and the Label
			singleTapBox.GestureRecognizers.Add(singleTap);
			tapLabel.GestureRecognizers.Add(singleTap);

			// Use a Grid to overlay the Label on top of the BoxView
			var grid = new Grid
			{
				WidthRequest = 100,
				HeightRequest = 100
			};
			grid.Children.Add(singleTapBox);
			grid.Children.Add(tapLabel);

			Content = new StackLayout
			{
				Margin = 40,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
				Children =
				{
					instructions,
					grid, // Add the grid containing the BoxView and Label
                    singleTapCounter // Add the singleTapCounter label here
                }
			};
		}
	}
}