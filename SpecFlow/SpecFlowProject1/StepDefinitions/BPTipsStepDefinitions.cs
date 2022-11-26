namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class BPTipsStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public BPTipsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(regex: @"the user is on the Blood Pressure Calculator home page")]
        public void GivenTheUserIsOnTheBloodPressureCaculatorHomepage()
        {

        }

        
        [Given(regex: @"the user clicks on the collapsible panel")]
        public void GivenTheUserClicksOnTheCollapsiblePanel()
        {

        }
    }
}