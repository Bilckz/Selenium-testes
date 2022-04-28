using SeleniumTeste.Drivers;
using SeleniumTeste.PageObjects;
using TechTalk.SpecFlow;

namespace SeleniumTeste.Steps
{
    [Binding]
    public class SearchStep
    {
        private readonly PageObject _search;
        private string _snippet;

        public SearchStep(BrowserDriver browserDriver)
        {
            _search = new PageObject(browserDriver);
        }

        #region Given

        [Given("I use the following snippet \"(.*)\"")]
        public void GivenIUseTheFollowingSnippet(string snippet)
        {
            _snippet = snippet;
            _search.InputSearch(snippet);
        }
        
        [Given("I don't enter anything in the search field")]
        public void GivenIDontEnterAnythingInTheSearchField()
        {
            _search.InputSearch("");
        }

        #endregion

        #region When

        [When("I search")]
        public void WhenISearch()
        {
            _search.SubmitSearch();
        }

        #endregion

        #region Then

        [Then("I verify that I found the article")]
        public void ThenIVerifyThatIFoundTheArticle()
        {
            _search.VerifyArticleWithSnippet(_snippet);
        }
        
        [Then("I verify that the search brought up articles")]
        public void ThenIVerifyThatTheSearchBroughtUpArticles()
        {
            _search.VerifyFoundArticles();
        }

        #endregion
        
    }
}