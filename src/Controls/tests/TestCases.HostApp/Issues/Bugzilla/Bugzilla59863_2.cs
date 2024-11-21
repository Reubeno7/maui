namespace Maui.Controls.Sample.Issues
{
	[Issue(IssueTracker.Bugzilla, 59863, "TapGestureRecognizer extremely finicky2", PlatformAffected.Android, issueTestNumber: 2)]
	public class Bugzilla59863_2 : TestContentPage
	{
		int _mixedSingleTaps;
		int _mixedDoubleTaps;
		const string MixedTapBoxId = "mixedTapView";

		const string Singles = "single(s)";
		const string Doubles = "double(s)";

		Label mixedSingleTapCounter;
		Label mixedDoubleTapCounter;

		protected override void Init()
		{
			mixedSingleTapCounter = new Label
			{
				Text = $"{_mixedSingleTaps} {Singles} on {MixedTapBoxId}",
				//AutomationId = "singleTapCounter"
				AutomationId = "1 single(s) on mixedTapView"  
			};

			mixedDoubleTapCounter = new Label
			{
				Text = $"{_mixedDoubleTaps} {Doubles} on {MixedTapBoxId}",
				//AutomationId = "doubleTapCounter"
				AutomationId = "2 double(s) on mixedTapView"
			};

			var instructions = new Label
			{
				Text = "Tap the box below once. The single tap counter should increment. "
				+ "Double tap the box. The double tap counter should increment by 2, "
				+ "but the single tap counter should not."
			};

			var mixedTapBox = new BoxView
			{
				WidthRequest = 100,
				HeightRequest = 100,
				BackgroundColor = Colors.Coral,
				//AutomationId = MixedTapBoxId
			};

			var tapLabel = new Label
			{
				Text = "Tap Here",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Colors.Transparent,
				AutomationId = "TapHereLabel"
			};

			var mixedDoubleTap = new TapGestureRecognizer
			{
				NumberOfTapsRequired = 2,
				Command = new Command(() =>
				{
					_mixedDoubleTaps += 2;
					mixedDoubleTapCounter.Text = $"{_mixedDoubleTaps} {Doubles} on {MixedTapBoxId}";
				})
			};

			var mixedSingleTap = new TapGestureRecognizer
			{
				NumberOfTapsRequired = 1,
				Command = new Command(() =>
				{
					_mixedSingleTaps += 1;
					mixedSingleTapCounter.Text = $"{_mixedSingleTaps} {Singles} on {MixedTapBoxId}";
					
				})
			};

			// Add the double tap and single tap gestures to both the BoxView and the Label
			mixedTapBox.GestureRecognizers.Add(mixedDoubleTap);
			mixedTapBox.GestureRecognizers.Add(mixedSingleTap);
			tapLabel.GestureRecognizers.Add(mixedDoubleTap);
			tapLabel.GestureRecognizers.Add(mixedSingleTap);

			// Use a Grid to overlay the Label on top of the BoxView
			var grid = new Grid
			{
				WidthRequest = 100,
				HeightRequest = 100
			};
			grid.Children.Add(mixedTapBox);
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
					mixedSingleTapCounter, // Add the single tap counter label here
					mixedDoubleTapCounter // Add the double tap counter label here
				}
			};
		}
	}
}