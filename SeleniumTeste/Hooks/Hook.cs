using BoDi;
using SeleniumTeste.Drivers;
using SeleniumTeste.PageObjects;
using TechTalk.SpecFlow;

namespace SeleniumTeste.Hooks
{
    [Binding]
    public class SharedBrowserHooks
    {
        [BeforeScenario]
        public static void BeforeScenario(ObjectContainer testThreadContainer, BrowserDriver browserDriver)
        {
            //Initialize a shared BrowserDriver in the global container
            testThreadContainer.BaseContainer.Resolve<BrowserDriver>();
            
            var pageObject = new PageObject(browserDriver);
            pageObject.PreSettings();
            
        }

        [AfterScenario]
        public void AfterScenario(BrowserDriver browserDriver)
        {
            var pageObject = new PageObject(browserDriver);
            pageObject.FinishSettings();
        }
    }
}