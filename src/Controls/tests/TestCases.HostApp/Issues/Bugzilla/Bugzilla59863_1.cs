namespace Maui.Controls.Sample.Issues
{
	[Issue(IssueTracker.Bugzilla, 59863, "TapGestureRecognizer extremely finicky1", PlatformAffected.Android, issueTestNumber: 1)]
	public class Bugzilla59863_1 : TestContentPage
	{
		int _doubleTaps;
		const string DoubleTapBoxId = "doubleTapView";
		const string Doubles = "double(s)";
		Label doubleTapCounter; // Declare at the class level

		protected override void Init()
		{
			doubleTapCounter = new Label
			{
				Text = $"{_doubleTaps} {Doubles} on {DoubleTapBoxId}",
				AutomationId = "1 double(s) on doubleTapView"
			};

			var instructions = new Label
			{
				Text = "Tap the box below once. The counter should not increment. "
						+ "Double tap the box. The counter should increment."
			};

			var doubleTapBox = new BoxView
			{
				WidthRequest = 100,
				HeightRequest = 100,
				BackgroundColor = Colors.Chocolate,
				AutomationId = DoubleTapBoxId
			};

			var tapLabel = new Label
			{
				Text = "Tap Here",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Colors.Transparent,
				AutomationId = "TapHereLabel"
			};

			var doubleTap = new TapGestureRecognizer
			{
				NumberOfTapsRequired = 2,
				Command = new Command(() =>
				{
					_doubleTaps += 1;
					doubleTapCounter.Text = $"{_doubleTaps} {Doubles} on {DoubleTapBoxId}";
				})
			};

			var singleTap = new TapGestureRecognizer
			{
				NumberOfTapsRequired = 1,
				Command = new Command(() =>
				{
					// No action needed for single taps
				})
			};

			// Add the double tap and single tap gestures to both the BoxView and the Label
			doubleTapBox.GestureRecognizers.Add(doubleTap);
			doubleTapBox.GestureRecognizers.Add(singleTap);
			tapLabel.GestureRecognizers.Add(doubleTap);
			tapLabel.GestureRecognizers.Add(singleTap);

			// Use a Grid to overlay the Label on top of the BoxView
			var grid = new Grid
			{
				WidthRequest = 100,
				HeightRequest = 100
			};
			grid.Children.Add(doubleTapBox);
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
                    doubleTapCounter // Add the doubleTapCounter label here
                }
			};
		}
	}
}