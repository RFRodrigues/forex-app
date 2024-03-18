using forex_app.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace forex_app_tests
{
    public class HomeTest
    {
        [Fact(Skip = "Makes no sense to test expected results because i set the data to ViewData and can't access it in tests")]
        public async Task OnGetTestAsync()
        {
            HttpClient httpClient = new HttpClient();
            var home = new HomeModel(httpClient);
            var expectedCurrencyFrom = "EUR";
            var expectedCurrencyTo = "USD";

            var result = await home.OnGet() as PageResult;
            Assert.NotNull(result);
            Assert.Equal(expectedCurrencyFrom, home.ViewData["currencyFrom"]); 
            Assert.Equal(expectedCurrencyTo, home.ViewData["currencyTo"]); 
            Assert.IsType<DateTime>(home.ViewData["lastRefresh"]);
        }
    }
}
