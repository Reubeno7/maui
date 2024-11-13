namespace Maui.Controls.Sample.Issues
{
	[Issue(IssueTracker.None, 0, "ListView crashes when disposed on ItemSelected", PlatformAffected.iOS)]
	public class ListViewNRE : TestContentPage
	{
		const string Success = "Success";

		protected override void Init()
		{
			try
			{
				var listView = new ListView
				{
					ItemsSource = Enumerable.Range(0, 10),
					ItemTemplate = new DataTemplate(() =>
					{
						var label = new Label();
						label.SetBinding(Label.TextProperty, ".");
						// Manually set the AutomationId
						label.BindingContextChanged += (sender, args) =>
						{
							var lbl = (Label)sender;
							if (lbl.BindingContext != null)
							{
								lbl.AutomationId = lbl.BindingContext.ToString();
							}
						};
						return new ViewCell { View = label };
					})
				};

				listView.ItemSelected += ListView_ItemSelected;

				Content = listView;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Initialization error: {ex.Message}");
			}
		}

		void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			try //contains the code that might cause the exception or error
			{
				if (e.SelectedItem != null)
				{
					var label = new Label { Text = Success, AutomationId = Success };
					Content = label;
				}
			}
			catch (Exception ex) //contains the code that catches the exception and contains the code to fix the error
			{
				Console.WriteLine($"ItemSelected error: {ex.Message}");
			}
			// we can also add the finally block section so that the code runs whether we had an exception or not
		}
	}
}
