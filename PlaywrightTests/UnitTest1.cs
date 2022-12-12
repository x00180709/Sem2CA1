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
        await Page.GotoAsync(url: "http://bloodpressuredm-staging.azurewebsites.net");
    }

    [Test]
    public async Task LowBloodPressure()
    {
        //User gets correct Low Blood Pressure message upon submit
        await Page.FillAsync(selector: "#BP_Systolic",value:"70");
        await Page.FillAsync(selector: "#BP_Diastolic", value: "40");
        await Page.ClickAsync(selector: "text=Submit");
        await Expect(Page.Locator(selector: "text=Low Blood Pressure")).ToBeVisibleAsync();
    }

    [Test]
    public async Task IdealBloodPressure()
    {
        //User gets correct Ideal Blood Pressure message upon submit
        await Page.FillAsync(selector: "#BP_Systolic",value:"90");
        await Page.FillAsync(selector: "#BP_Diastolic", value: "70");
        await Page.ClickAsync(selector: "text=Submit");
        await Expect(Page.Locator(selector: "text=Ideal Blood Pressure")).ToBeVisibleAsync();
    }

    [Test]
    public async Task PreHighBloodPressure()
    {
        //User gets correct Pre-High Blood Pressure message upon submit
        await Page.FillAsync(selector: "#BP_Systolic",value:"130");
        await Page.FillAsync(selector: "#BP_Diastolic", value: "80");
        await Page.ClickAsync(selector: "text=Submit");
        await Expect(Page.Locator(selector: "text=Pre-High Blood Pressure")).ToBeVisibleAsync();
    }

    [Test]
    public async Task HighBloodPressure()
    {
        //User gets correct High Blood Pressure message upon submit
        await Page.FillAsync(selector: "#BP_Systolic",value:"160");
        await Page.FillAsync(selector: "#BP_Diastolic", value: "60");
        await Page.ClickAsync(selector: "text=Submit");
        await Expect(Page.Locator(selector: "text=High Blood Pressure")).ToBeVisibleAsync();
    }

    [Test]
    public async Task InvalidDiastolic()
    {
        //Checking error message for invalid Diastolic input
        await Page.FillAsync(selector: "#BP_Systolic", value: "160");
        await Page.FillAsync(selector: "#BP_Diastolic", value: "-60");
        await Page.ClickAsync(selector: "text=Submit");
        await Expect(Page.Locator(selector: "text=Invalid Diastolic Value")).ToBeVisibleAsync();
    }

    [Test]
    public async Task InvalidSystolic()
    {
        //Checking error message for Systolic out of range
        await Page.FillAsync(selector: "#BP_Systolic", value: "60");
        await Page.FillAsync(selector: "#BP_Diastolic", value: "60");
        await Page.ClickAsync(selector: "text=Submit");
        await Expect(Page.Locator(selector: "text=Invalid Systolic Value")).ToBeVisibleAsync();
    }

    [Test]
    public async Task InvalidDiastolicGreaterThanSystolic()
    {
        //Checking error message where Diastolic > Systolic
        await Page.FillAsync(selector: "#BP_Systolic", value: "160");
        await Page.FillAsync(selector: "#BP_Diastolic", value: "161");
        await Page.ClickAsync(selector: "text=Submit");
        await Expect(Page.Locator(selector: "text=Systolic must be greater than Diastolic")).ToBeVisibleAsync();
    }

}