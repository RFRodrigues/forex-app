using forex_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace forex_app.Pages
{
    public class HomeModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public HomeModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> OnGet()
        {
            string currencyFrom = "EUR";
            string currencyTo = "USD";

            // Set the default values when it is the first time it loads the page
            ViewData["lastRefresh"] = DateTime.Now;
            ViewData["currencyFrom"] = currencyFrom;
            ViewData["currencyTo"] = currencyTo;

            await MakeApiCallAsync(currencyFrom, currencyTo);

            return Page();
        }

        public async Task<IActionResult> OnPost(string currencyFrom = "", string currencyTo = "")
        {
            
            // Set the data to use on view
            ViewData["lastRefresh"] = DateTime.Now;
            ViewData["currencyFrom"] = currencyFrom;
            ViewData["currencyTo"] = currencyTo;

            await MakeApiCallAsync(currencyFrom, currencyTo);

            return Page();
        }

        public async Task MakeApiCallAsync(string currencyFrom, string currencyTo)
        {
            // Set received key to use in API
            string apiKey = "2QLHTTVTNUCCXX6C";
            try
            {

                string apiUrl = $"https://www.alphavantage.co/query?function=FX_DAILY&from_symbol={currencyFrom}&to_symbol={currencyTo}&apikey={apiKey}";

                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    JObject data = JObject.Parse(responseBody);

                    // Set the API response in ViewData to use it view
                    ViewData["ApiResponse"] = data;
                }
                else
                {
                    // Handle the error redirecting to the default error page
                    RedirectToPage("/Error");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions redirecting to the default error page
                RedirectToPage("/Error");
            }
        }
    }
}
