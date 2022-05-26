using System.ComponentModel;
using Turnverein.ViewModels;
using Xamarin.Forms;

namespace Turnverein.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}