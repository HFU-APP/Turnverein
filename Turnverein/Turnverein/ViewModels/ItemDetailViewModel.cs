using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Turnverein.Models;
using Xamarin.Forms;

namespace Turnverein.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }


        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.ContestName;
                Title = Text;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load ContestItem");
            }
        }
    }
}
