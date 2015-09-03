using System;

using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace CrossPlatSample
{
    [Binding]
    public class ExampleSteps
    {
        [AfterScenario]
        public void After()
        {
            AppManager.CloseAppConnection();   
            PageContainer.DisposeContainer();
        }

        [Given("I am on the locations page")]
        public void GivenIAmOnTheLocationsPage()
        {
            var platform = Current.Platform;

            PageResolver.HomePage().ViewLocations();
        }

        [When("I select location '(.*)'")]
        public void WhenIPressAdd(string location)
        {
            PageResolver.LocationPage().SelectLoaction(location);
        }

        [Then("I should see information")]
        public void ThenTheResultShouldBe()
        {
            PageResolver.InformationPage();

            //DO SOME ASSERT
        }
    }
}
		
