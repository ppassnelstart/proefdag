using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace SnelStart.B2BClient.Web.Utilities
{
    internal class B2BApiUtility
    {
        internal static HttpClient GetB2BApiClient(AppSettings settings) {
            var token = GetBearerToken(settings.TokenRequestEndpoint, settings.B2BApiClientKey);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", settings.B2BApiSubscriptionKey);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            return client;
        }

        private static string GetBearerToken(string tokenRequestUriString, string clientkey)
        {
            using (var httpClient = new HttpClient())
            {
                var requestBody = new Dictionary<string, string>
                {
                    { "grant_type", "clientkey" },
                    { "clientkey", clientkey }
                };

                var tokenRequestUri = new Uri(tokenRequestUriString);
                var formUrlEncodedContent = new FormUrlEncodedContent(requestBody);
                var response = httpClient.PostAsync(tokenRequestUri, formUrlEncodedContent).Result;
                var responseContentJson = response.Content.ReadAsStringAsync().Result;

                dynamic responseParsed = JObject.Parse(responseContentJson);

                return responseParsed.access_token;
            }
        }
    }
}
