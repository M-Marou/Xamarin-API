using ConsumeAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ConsumeAPI
{
    public class WebAPIService
    {
        #region Fields 

        System.Net.Http.HttpClient client;

        #endregion

        #region Properties 

        public ObservableCollection<ProductsModel> Items
        {
            get; private set;
        }

        public string WebAPIUrl
        {
            get; private set;
        }

        #endregion

        #region Constructor
        public WebAPIService()
        {
            client = new System.Net.Http.HttpClient();
        }

        #endregion

        #region Methods
        public async System.Threading.Tasks.Task<ObservableCollection<ProductsModel>> RefreshDataAsync()
        {
            WebAPIUrl = "https://productapiccc.herokuapp.com/api/product"; 
            var uri = new Uri(WebAPIUrl);
            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<ObservableCollection<ProductsModel>>(content);
                    return Items;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        #endregion
    }
}
