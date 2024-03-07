﻿using NUnit.Framework;
using UITest.Appium;

namespace UITests
{
    internal class Issue1219 : IssuesUITest
	{
		const string Success = "Success";

		public Issue1219(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "Setting ToolbarItems in ContentPage constructor crashes app";

		[Test]
		[Category(UITestCategories.ListView)]
		public void ViewCellInTableViewDoesNotCrash()
		{
			this.IgnoreIfPlatforms([TestDevice.Android, TestDevice.Mac, TestDevice.Windows]);

			RunningApp.WaitForNoElement(Success);
		}
	}
}