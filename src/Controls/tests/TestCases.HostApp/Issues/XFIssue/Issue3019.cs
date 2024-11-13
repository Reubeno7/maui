using System.Collections.ObjectModel;

namespace Maui.Controls.Sample.Issues
{
	[Issue(IssueTracker.Github, 3019, "Grouped ListView Header empty for adding items", PlatformAffected.UWP)]
	public class Issue3019 : TestContentPage
	{
		StackLayout _contentLayout;
		int itemCounter = 0;

		void AddData()
		{
			var groupLabel = new Label
			{
				Text = "Group 1",
				AutomationId = "Group1"
			};

			var itemLabel0 = new Label
			{
				Text = "Grouped Item: 0",
				AutomationId = "GroupedItem0"
			};

			var itemClickedLabel0 = new Label
			{
				Text = "Grouped Item: 0 Clicked",
				AutomationId = "GroupedItem0Clicked",
				IsVisible = false
			};

			var itemLabel1 = new Label
			{
				Text = "Grouped Item: 1",
				AutomationId = "GroupedItem1"
			};

			var itemClickedLabel1 = new Label
			{
				Text = "Grouped Item: 1 Clicked",
				AutomationId = "GroupedItem1Clicked",
				IsVisible = false
			};

			itemLabel0.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() =>
				{
					itemClickedLabel0.IsVisible = true;
				})
			});

			itemLabel1.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() =>
				{
					itemClickedLabel1.IsVisible = true;
				})
			});

			_contentLayout.Children.Add(groupLabel);
			_contentLayout.Children.Add(itemLabel0);
			_contentLayout.Children.Add(itemClickedLabel0);
			_contentLayout.Children.Add(itemLabel1);
			_contentLayout.Children.Add(itemClickedLabel1);

			itemCounter += 2;
		}

		protected override void Init()
		{
			Label label = new Label() { Text = "If you see group headers and can click on each row without crashing, the test has passed" };

			_contentLayout = new StackLayout
			{
				Children =
				{
					label,
					new Button()
					{
						Text = "Click to add more rows",
						Command = new Command(() =>
						{
							AddData();
						}),
						AutomationId = "AddRowsButton" // Add AutomationId
                    }
				},
			};

			Content = _contentLayout;

			// Initial data load
			AddData();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}
	}
}
