namespace Maui.Controls.Sample.Issues
{
	[Issue(IssueTracker.Bugzilla, 45743, "[iOS] Calling DisplayAlert via BeginInvokeOnMainThread blocking other calls on iOS", PlatformAffected.iOS)]
	public class Bugzilla45743 : TestNavigationPage
	{
		protected override void Init()
		{
			PushAsync(new ContentPage
			{
				Content = new StackLayout
				{
					AutomationId = "Page1",
					Children =
					{
						new Label { Text = "Page 1" }
					}
				}
			});

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS0612 // Type or member is obsolete
			Device.BeginInvokeOnMainThread(async () =>
			{
				try
				{
					await DisplayAlert("Title", "Message", "Accept", "Cancel");
					// Navigate to Page 2 after accepting the first alert
					await PushAsync(new ContentPage
					{
						AutomationId = "Page2",
						Content = new StackLayout
						{
							Children =
							{
								new Label { Text = "Page 2", AutomationId = "Page2Label" }
							}
						}
					});
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception in DisplayAlert: {ex.Message}");
				}
			});
#pragma warning restore CS0612 // Type or member is obsolete
#pragma warning restore CS0618 // Type or member is obsolete

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS0612 // Type or member is obsolete
			Device.BeginInvokeOnMainThread(async () =>
			{
				try
				{
					await DisplayAlert("Title 2", "Message", "Accept", "Cancel");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception in DisplayAlert 2: {ex.Message}");
				}
			});
#pragma warning restore CS0612 // Type or member is obsolete
#pragma warning restore CS0618 // Type or member is obsolete

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS0612 // Type or member is obsolete
			Device.BeginInvokeOnMainThread(async () =>
			{
				try
				{
					// Adding a Label with AutomationId before DisplayActionSheet
					var actionSheetLabel = new Label { Text = "Title", AutomationId = "ActionSheet Title" };
					var page = new ContentPage
					{
						Content = new StackLayout
						{
							Children =
							{
								actionSheetLabel
							}
						}
					};
					await PushAsync(page);

					// Displaying the action sheet
					await DisplayActionSheet("ActionSheet Title", "Cancel", "Exit", new string[] { "Test", "Test 2" });
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception in DisplayActionSheet: {ex.Message}");
				}
			});
#pragma warning restore CS0612 // Type or member is obsolete
#pragma warning restore CS0618 // Type or member is obsolete
		}
	}
}