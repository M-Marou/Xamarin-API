using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamWebApiClient.Services;
using XamWebApiClient.Views;
using XamWebApiClient.ViewModels;
using XamWebApiClient.Models;


namespace XamWebApiClient.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private ObservableCollection<Product> products;
        private Product selectedProduct;
        private readonly IProductService _ServiceProduct;

        public ProductViewModel(IProductService ProductService)
        {
            _ServiceProduct = ProductService;

            Products = new ObservableCollection<Product>();

            DeleteProductCommand = new Command<Product>(async b => await DeleteProduct(b));

            AddNewProductCommand = new Command(async () => await GoToAddProductView());
        }

        private async Task DeleteProduct(Product b)
        {
            await _ServiceProduct.DeleteProduct(b);

            PopulateProduct();
        }

        private async Task GoToAddProductView()
            => await Shell.Current.GoToAsync(nameof(AddProduct));

        public async void PopulateProduct()
        {
            try
            {
                Products.Clear();

                var products = await _ServiceProduct.GetProducts();

                foreach (var Pro in products)
                {
                    Products.Add(Pro);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async void OnProductSelected(Product product)
        {
            if (product == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ProductDetails)}?{nameof(ProductDetailViewModel.Id)}={product.Id}");
        }

        public ObservableCollection<Product> Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                if (selectedProduct != value)
                {
                    selectedProduct = value;

                    OnProductSelected(SelectedProduct);
                }
            }
        }

        public ICommand DeleteProductCommand { get; }

        public ICommand AddNewProductCommand { get; }
    }
}
