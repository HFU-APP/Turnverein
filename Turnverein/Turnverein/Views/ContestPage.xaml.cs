using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnverein.Models;
using Turnverein.ViewModels;
using Turnverein.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Turnverein.Views
{
    public partial class ContestPage : ContentPage
    {
        ContestViewModel _viewModel;

        public ContestPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ContestViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}