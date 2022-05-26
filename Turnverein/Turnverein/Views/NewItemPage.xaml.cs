using System;
using System.Collections.Generic;
using System.ComponentModel;
using Turnverein.Models;
using Turnverein.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Turnverein.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}