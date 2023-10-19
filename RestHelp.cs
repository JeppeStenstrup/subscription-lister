using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Subscription_Listing
{
    /// <summary>
    /// to access e-conomic new REST api use: host + api + version + resource 
    /// Doc: https://apis.e-conomic.com
    /// </summary>
    public enum RestApi
    {
        /// <summary>
        /// Projects, employees and timeentries
        /// </summary>
        api,
        /// <summary>
        /// contacts
        /// </summary>
        customersapi,
        /// <summary>
        /// invoicelines
        /// </summary>
        q2capi,
        /// <summary>
        /// subscriptions and subscribers
        /// </summary>
        subscriptionsapi
    }

    class RestHelp
    {
        const string _openapi_url = "https://apis.e-conomic.com";
        string _privatekey = null;
        string _token = null;

        public RestHelp(string privatekey, string token)
        {
            _privatekey = privatekey;
            _token = token;
        }

        /// <summary>
        /// Format url for collection for OpenApi (new e-conomic)
        /// </summary>
        /// <param name="api"></param>
        /// <param name="version"></param>
        /// <param name="resource"></param>
        /// <param name="filter"></param>
        /// <param name="collection_cursor">Set 0 (zero) or cursor value for collection retrieval</param>
        /// <returns></returns>
        public string OpenApiMakeUrl(RestApi api, string version, string resource, string filter = null, string collection_cursor = null)
        {
            string url = $"{_openapi_url}/{api}/{version}/{resource}";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                url += "?" + filter;
                if (!string.IsNullOrEmpty(collection_cursor))
                    url += $"&cursor={collection_cursor}";
            }
            else
            {
                if (!string.IsNullOrEmpty(collection_cursor))
                    url += $"?cursor={collection_cursor}";
            }
            return url;
        }

        private class EconomicCollection<T>
        {
            public T[] items;
            public string cursor;
        }

        /// <summary>
        /// E-conomiconly. Uses new url and cursors
        /// </summary>
        /// <param name="api"></param>
        /// <param name="version"></param>
        /// <param name="resource"></param>
        /// <param name="filter"></param>
        /// <param name="cursor"></param>
        /// <returns>next page cursor -or- null</returns>
        public async Task<Tuple<string, T[]>> GetOpenApiCollectionAsync<T>(RestApi api, string version, string resource, string filter = null, string cursor = null)
        {
            string url = OpenApiMakeUrl(api, version, resource, filter, cursor);
            var data = await GetFromUrlAsync<EconomicCollection<T>>(url);
            if (data.Item2 != HttpStatusCode.OK)
                return Tuple.Create<string, T[]>(null, default);
            return Tuple.Create(data.Item1.cursor, data.Item1.items);
        }

        /// <summary>
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Data object T, Status object</returns>
        public async Task<Tuple<T, HttpStatusCode>> GetFromUrlAsync<T>(string url)
        {
            T data;
            HttpStatusCode s = HttpStatusCode.OK;
            using (WebClient client = new WebClient())
            {
                client.Headers["Content-type"] = "application/json";
                client.Headers["X-AgreementGrantToken"] = _token;
                client.Headers["X-AppSecretToken"] = _privatekey;
                client.Encoding = Encoding.UTF8;

                try
                {
                    string s_data = await client.DownloadStringTaskAsync(url);
                    data = JsonConvert.DeserializeObject<T>(s_data);
                }
                catch (WebException e)
                {
                    data = default;
                    if (e.Response != null)
                    {
                        s = ((HttpWebResponse)e.Response).StatusCode;
                    }
                    else
                    {
                        s = HttpStatusCode.NoContent;
                    }
                }
            }
            return Tuple.Create(data, s);
        }
    }
}
