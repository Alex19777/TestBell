﻿using NUnit.Framework;

namespace Bellatrix.Mobile.IOS.GettingStarted;

[TestFixture]

// 1. Sometimes it is useful to use your functional tests to measure performance. Or to just make sure that your app
// is not slow. To do that BELLATRIX libraries offer the ExecutionTimeUnder attribute. You specify a timeout and if the
// test is executed over it the test will fail.
//
// 1.1. You need to add the NuGet package- Bellatrix.TestExecutionExtensions.Common
// 1.2. After that you need to add a using statement to Bellatrix.TestExecutionExtensions.Common.ExecutionTime
[ExecutionTimeUnder(5000, TimeUnit.Milliseconds)]
[IOS(Constants.IOSNativeAppPath,
    Constants.AppleCalendarBundleId,
    Constants.IOSDefaultVersion,
    Constants.IOSDefaultDeviceName,
    Lifecycle.RestartEveryTime)]
public class MeasureTestExecutionTimesTests : NUnit.IOSTest
{
    [Test]
    [CancelAfter(180000)]
    [Category(Categories.CI)]
    public void ButtonClicked_When_CallClickMethod()
    {
        var button = App.Components.CreateByName<Button>("ComputeSumButton");

        button.Click();
    }
}