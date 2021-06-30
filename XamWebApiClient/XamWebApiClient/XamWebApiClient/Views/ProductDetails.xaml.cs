
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamWebApiClient.ViewModels;

namespace XamWebApiClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetails : ContentPage
    {
        public ProductDetails()
        {
            InitializeComponent();

            BindingContext = Startup.Resolve<ProductDetailViewModel>();
        }
    }
}