using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Turnverein.Models;
using Turnverein.Views;
using Xamarin.Forms;

namespace Turnverein.ViewModels
{
    public class ContestViewModel : BaseViewModel
    {
        private ContestItem selectedContestItem;
        public Command Onpushed { get; }

        public ObservableCollection<ContestItem> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<ContestItem> ItemTapped { get; }

        public ContestViewModel()
        {
            Title = "Disziplin auswählen";
            Items = new ObservableCollection<ContestItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<ContestItem>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedContestItem = null;
        }

        public ContestItem SelectedContestItem
        {
            get => selectedContestItem;
            set
            {
                SetProperty(ref selectedContestItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(ContestItem contestItem)
        {
            if (contestItem == null)
                return;

            Debug.WriteLine("SelectedContestItem:" + contestItem.Id);
            Debug.WriteLine("SelectedContestItem:" + contestItem.ContestName);

            string action = await Application.Current.MainPage.DisplayActionSheet("Bitte wählen Sie Ihren Verein aus!", "Cancel", null, "Verein 1", "Verein2",
                "Verein 3", "Verein 4");
            Debug.WriteLine("Action: " + action);
        }
    }
}