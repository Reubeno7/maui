using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
	public class Issue3019 : _IssuesUITest
	{
		public Issue3019(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "Grouped ListView Header empty for adding items";

		[Test]
		[Category(UITestCategories.ListView)]
		public void MakeSureListGroupShowsUpAndItemsAreClickable()
		{
			// Increase the timeout duration
			var timeout = TimeSpan.FromSeconds(30);

			// Wait for the group header to appear
			App.WaitForElement("Group1", timeout: timeout);

			// Tap on the first item in the group
			App.Tap("GroupedItem0");

			// Verify the item was clicked
			App.WaitForElement("GroupedItem0Clicked", timeout: timeout);

			// Tap on the second item in the group
			App.Tap("GroupedItem1");

			// Verify the item was clicked
			App.WaitForElement("GroupedItem1Clicked", timeout: timeout);
		}
	}
}
