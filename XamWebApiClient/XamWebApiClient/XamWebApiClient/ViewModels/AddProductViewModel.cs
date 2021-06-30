using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamWebApiClient.Models;
using XamWebApiClient.Services;
using XamWebApiClient.ViewModels;

namespace XamWebApiClient.ViewModels
{
    public class AddproductViewModel : BaseViewModel
    {
        private readonly IProductService _ProductService;
        private string title;
        private string prix;
        private string description;

        public AddproductViewModel(IProductService productService)
        {
            _ProductService = productService;

            SaveProductCommand = new Command(async () => await SaveProduct());
        }

        private async Task SaveProduct()
        {
            try
            {

                var product = new Product
                {
                    Title = title,
                    Prix = float.Parse(prix),
                    Description = description
                };

                await _ProductService.AddProduct(product);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
