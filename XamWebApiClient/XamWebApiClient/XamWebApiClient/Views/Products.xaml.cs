

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamWebApiClient.ViewModels;

namespace XamWebApiClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Products : ContentPage
    {
        private readonly ProductViewModel _productViewModel;

        public Products()
        {
            InitializeComponent();

            _productViewModel = Startup.Resolve<ProductViewModel>();
            BindingContext = _productViewModel;
        }

        protected override void OnAppearing()
        {
            _productViewModel?.PopulateProduct();
            
        }
    }
}