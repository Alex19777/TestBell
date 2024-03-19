﻿// <copyright file="NumberControlTestsSafari.cs" company="Automate The Planet Ltd.">
// Copyright 2024 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>https://bellatrix.solutions/</site>
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bellatrix.Web.Tests.Controls;

[TestClass]
[Browser(BrowserType.Safari, Lifecycle.ReuseIfStarted)]
[AllureSuite("Number Control")]
public class NumberControlTestsSafari : MSTest.WebTest
{
    public override void TestInit() => App.Navigation.NavigateToLocalPage(ConfigurationService.GetSection<TestPagesSettings>().NumberLocalPage);

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void DecimalNumberSet_When_UseSetNumberMethod_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber");

        numberElement.SetNumber(12.1);

        Assert.AreEqual(12.1, numberElement.GetNumber());
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void IntegerNumberSet_When_UseSetNumberMethod_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber");

        numberElement.SetNumber(12);

        Assert.AreEqual(12, numberElement.GetNumber());
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void GetNumberReturnsCorrectNumber_When_DefaultNumberIsSet_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber2");

        Assert.AreEqual(4, numberElement.GetNumber());
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void AutoCompleteReturnsFalse_When_NoAutoCompleteAttributeIsPresent_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber");

        Assert.IsFalse(numberElement.IsAutoComplete);
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void AutoCompleteReturnsFalse_When_AutoCompleteAttributeExistsAndIsSetToOff_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber4");

        Assert.IsFalse(numberElement.IsAutoComplete);
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void AutoCompleteReturnsTrue_When_AutoCompleteAttributeExistsAndIsSetToOn_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber3");

        Assert.IsTrue(numberElement.IsAutoComplete);
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void GetReadonlyReturnsFalse_When_ReadonlyAttributeIsNotPresent_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber4");

        Assert.AreEqual(false, numberElement.IsReadonly);
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void GetReadonlyReturnsTrue_When_ReadonlyAttributeIsPresent_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber5");

        Assert.AreEqual(true, numberElement.IsReadonly);
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void GetMaxReturnsNull_When_MaxAttributeIsNotPresent_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber");

        var max = numberElement.Max;

        Assert.IsNull(max);
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void GetMinReturnsNull_When_MinAttributeIsNotPresent_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber");

        Assert.IsNull(numberElement.Min);
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void GetStepReturnsNull_When_StepAttributeIsNotPresent_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber");

        Assert.IsNull(numberElement.Step);
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void GetMaxReturns80_When_MaxAttributeIsPresent_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber1");

        Assert.AreEqual(20, numberElement.Max);
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void GetMinReturns10_When_MinAttributeIsPresent_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber1");

        Assert.AreEqual(10, numberElement.Min);
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void GetStepReturns30_When_StepAttributeIsNotPresent_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber1");

        Assert.AreEqual(2, numberElement.Step);
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void GetRequiredReturnsFalse_When_RequiredAttributeIsNotPresent_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber4");

        Assert.AreEqual(false, numberElement.IsRequired);
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void GetRequiredReturnsTrue_When_RequiredAttributeIsPresent_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber6");

        Assert.IsTrue(numberElement.IsRequired);
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void GetPlaceholder_When_PlaceholderAttributeIsSet_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber");

        Assert.AreEqual("Multiple of 10", numberElement.Placeholder);
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void GetPlaceholderReturnsNull_When_PlaceholderAttributeIsNotPresent_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber1");

        Assert.IsNull(numberElement.Placeholder);
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void ReturnRed_When_Hover_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber7");

        numberElement.Hover();

        Assert.AreEqual("color: red;", numberElement.GetStyle());
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void ReturnBlue_When_Focus_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber8");

        numberElement.Focus();

        Assert.AreEqual("color: blue;", numberElement.GetStyle());
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void ReturnFalse_When_DisabledAttributeNotPresent_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber");

        bool isDisabled = numberElement.IsDisabled;

        Assert.IsFalse(isDisabled);
    }

    [TestMethod]
    [Ignore, TestCategory(Categories.Safari), TestCategory(Categories.OSX)]
    public void ReturnTrue_When_DisabledAttributePresent_Safari()
    {
        var numberElement = App.Components.CreateById<Number>("myNumber9");

        bool isDisabled = numberElement.IsDisabled;

        Assert.IsTrue(isDisabled);
    }
}