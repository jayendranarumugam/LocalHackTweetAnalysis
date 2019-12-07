using LocalHackTweetAnalysis.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LocalHackTweetAnalysis
{
    public class SearchAPI
    {
        public static async Task<RootObject> GetDocListAsync(AzSearchModel azSearch)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("api-key", "C52E071F066CAE05B3941D94DAAE5AF5");

            var jsonstring = JsonConvert.SerializeObject(azSearch);
            var content = new StringContent(jsonstring, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://localhacksearch.search.windows.net/indexes/localhack-tweet-index/docs/search?api-version=2019-05-06", content);

            response.EnsureSuccessStatusCode();

            var results = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RootObject>(results);
        }
    }
}