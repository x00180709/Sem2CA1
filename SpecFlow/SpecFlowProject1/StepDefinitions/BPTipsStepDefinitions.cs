using SpecFlowProject1.Drivers;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class BPTipsStepDefinitions
    {
        private readonly Driver _driver;

        public BPTipsStepDefinitions(Driver driver)
        {
            _driver = driver;
        }

        [Given(regex: @"the user is on the Blood Pressure Calculator home page")]
        public void GivenTheUserIsOnTheBloodPressureCaculatorHomepage()
        {
            _driver.Page.GotoAsync(url: "http://bloodpressuredm.azurewebsites.net");
        }

        
        [Given(regex: @"the user clicks on the collapsible panel")]
        public void GivenTheUserClicksOnTheCollapsiblePanel()
        {
            _driver.Page.ClickAsync(selector: "text: How to take a reading?");
        }

        [When(@"the user clicks on the collapsible panel")]
        public void WhenTheUserClicksOnTheCollapsiblePanel()
        {
            _driver.Page.ClickAsync(selector: "text: How to take a reading?");
        }

        [Then(@"additional text is displayed to the user")]
        public void ThenAdditionalTextIsDisplayedToTheUser()
        {
              
        }

        [Given(@"the panel has been expanded")]
        public void GivenThePanelHasBeenExpanded()
        {
            _driver.Page.ClickAsync(selector: "text: How to take a reading?");
        }

        [Then(@"the panel will close")]
        public void ThenThePanelWillCloses()
        {
            _driver.Page.ClickAsync(selector: "text: How to take a reading?");
        }

    }
}