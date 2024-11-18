using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
	public class Bugzilla26501 : _IssuesUITest
	{
		public Bugzilla26501(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "BindingSource / Context action issue";

		[Test]
		[Category(UITestCategories.InputTransparent)]
		public void TestCellsShowAfterRefresh()
		{
			// Tap the refresh button
			App.Tap("Refresh");

			// Wait for the element to disappear
			App.WaitForNoElement("ZOOMER robothund 2");

		}
	}
}