using ConsumeAPI.Models;
using ConsumeAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ConsumeAPI
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        #region Fields

        WebAPIService webAPIService;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<ProductsModel> items;

        #endregion

        #region Properties
        public ObservableCollection<ProductsModel> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                RaisepropertyChanged("Items");
            }
        }
        #endregion

        #region Constructor
        public ProductsViewModel()
        {
            webAPIService = new WebAPIService();
            Items = new ObservableCollection<ProductsModel>();
            GetDataFromWebAPI();
        }
        #endregion

        #region Methods 
        async void GetDataFromWebAPI()
        {
            Items = await webAPIService.RefreshDataAsync();
        }
        void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
