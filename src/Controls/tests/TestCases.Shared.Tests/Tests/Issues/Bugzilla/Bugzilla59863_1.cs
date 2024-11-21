using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
    [Category(UITestCategories.Gestures)]
    public class Bugzilla59863_1 : _IssuesUITest
    {
        const string DoubleTapBoxId = "doubleTapView";
        const string TapHereLabelId = "TapHereLabel";
        const string Doubles = "double(s)";

        public Bugzilla59863_1(TestDevice testDevice) : base(testDevice)
        {
        }

        public override string Issue => "TapGestureRecognizer extremely finicky1";

        [Test]
        public void SingleTapWithOnlyDoubleTapRecognizerShouldRegisterNothing()  
        {
            App.WaitForElement(TapHereLabelId);
            App.Tap(TapHereLabelId);
            App.WaitForNoElement($"0 {Doubles} on {DoubleTapBoxId}");
        }

        [Test]
        public void DoubleTapWithOnlyDoubleTapRecognizerShouldRegisterOneDoubleTap()
        {
            App.WaitForElement(TapHereLabelId);
            App.DoubleTap(TapHereLabelId);
            App.WaitForElement($"1 {Doubles} on {DoubleTapBoxId}");
        }
    }
}