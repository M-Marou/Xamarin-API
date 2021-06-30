using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamWebApiClient.Models;
using XamWebApiClient.Services;
using XamWebApiClient.ViewModels;

namespace XamWebApiClient.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class ProductDetailViewModel : BaseViewModel
    {
        private string id;
        private string title;
        private string prix;
        private string description;
        private readonly IProductService _ProductService;

        public ProductDetailViewModel(IProductService ProductService)
        {
            _ProductService = ProductService;

            SaveProductCommand = new Command(async () => await SaveProduct());
        }

        private async Task SaveProduct()
        {
            try
            {
                var Product = new Product
                {
                    Id = int.Parse(id),
                    Title = Title,
                    Prix = float.Parse(prix),
                    Description = description
                };

                await _ProductService.SaveProduct(Product);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void LoadProduct(string ProductId)
        {
            try
            {
                var product = await _ProductService.GetProduct(int.Parse(Id));
                if (Id != null)
                {
                    Title = product.Title;
                    Prix = product.Prix.ToString();
                    Description = product.Description;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string Id
        {
            get => id;
            set
            {
                id = value;
                LoadProduct(Id);

            }
        }

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }


        public string Prix
        {
            get => prix;
            set
            {
                prix = value;
                OnPropertyChanged(nameof(Prix));
            }
        }
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public ICommand SaveProductCommand { get; }
    }
}
