using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

public class Tests : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        //Opens browser to specified URI
        await Page.GotoAsync(url: "boodpressuredm.azurewebsites.net");
    }

    [Test]
    public async Task HighBloodPressure()
    {
        //Enter values in Systolic and Diastolic fields, submit and verify output
        await Page.FillAsync(selector: "#BP_Systolic",value:"160");
        await Page.FillAsync(selector: "#BP_Diastolic", value: "60");
        await Page.ClickAsync(selector: "text=Submit");
        await Expect(Page.Locator(selector: "text=High Blood Pressure")).ToBeVisibleAsync();
    }

    [Test]
    public async Task InvalidDiastolic()
    {
        //Enter values in Systolic and Diastolic fields, submit and verify output
        await Page.FillAsync(selector: "#BP_Systolic", value: "160");
        await Page.FillAsync(selector: "#BP_Diastolic", value: "-60");
        await Page.ClickAsync(selector: "text=Submit");
        await Expect(Page.Locator(selector: "text=Invalid Diastolic Value")).ToBeVisibleAsync();
    }

    [Test]
    public async Task InvalidSystolic()
    {
        //Enter values in Systolic and Diastolic fields, submit and verify output
        await Page.FillAsync(selector: "#BP_Systolic", value: "60");
        await Page.FillAsync(selector: "#BP_Diastolic", value: "60");
        await Page.ClickAsync(selector: "text=Submit");
        await Expect(Page.Locator(selector: "text=Invalid Systolic Value")).ToBeVisibleAsync();
    }

    [Test]
    public async Task InvalidDiastolicGreaterThanSystolic()
    {
        //Enter values in Systolic and Diastolic fields, submit and verify output
        await Page.FillAsync(selector: "#BP_Systolic", value: "160");
        await Page.FillAsync(selector: "#BP_Diastolic", value: "161");
        await Page.ClickAsync(selector: "text=Submit");
        await Expect(Page.Locator(selector: "text=Systolic must be greater than Diastolic")).ToBeVisibleAsync();
    }

}