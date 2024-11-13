namespace Maui.Controls.Sample.Issues
{
	[Issue(IssueTracker.Github, 7240, "[Android] Shell content layout hides navigated to page", PlatformAffected.Android)]
	public class Issue7240 : TestShell
	{
		const string Success = "Success";
		const string ClickMe = "ClickMe";

		int pageCount = 1;

		protected override void Init()
		{
			Func<ContentPage> createNewPage = null;
			createNewPage = () =>
				new ContentPage
				{
					BindingContext = this,
					Content = new StackLayout
					{
						Children =
						{
							new Button
							{
								Text = "Click me and you should see a new page with this same button in the same place",
								AutomationId = ClickMe,
								Command = new Command(() =>
								{
									pageCount++;
									System.Diagnostics.Debug.WriteLine($"Page Count: {pageCount}");
									Navigation.PushAsync(createNewPage());
									OnPropertyChanged(nameof(IsSuccessVisible));
								})
							},
							new Label
							{
								Text = $"Page Count:{pageCount}",
								AutomationId = $"Page Count:{pageCount}" // Dynamic AutomationId
                            },
							new Label
							{
								Text = "Success",
								AutomationId = "Success",
								IsVisible = IsSuccessVisible // Bind visibility to IsSuccessVisible property
						    }
						}
					}
				};

			AddContentPage(createNewPage());
		}

		public bool IsSuccessVisible => pageCount > 2;
	}
}