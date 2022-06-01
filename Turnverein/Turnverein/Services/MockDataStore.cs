using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turnverein.Models;

namespace Turnverein.Services
{
    public class MockDataStore : IDataStore<ContestItem>
    {
        readonly List<ContestItem> items;

        public MockDataStore()
        {
            items = new List<ContestItem>()
            {
                new ContestItem { Id = Guid.NewGuid().ToString(), ContestName = "Weitwurf" },
                new ContestItem { Id = Guid.NewGuid().ToString(), ContestName = "3-KM Lauf" },
                new ContestItem { Id = Guid.NewGuid().ToString(), ContestName = "Korbball" },
                new ContestItem { Id = Guid.NewGuid().ToString(), ContestName = "Disziplin 4" },
            };
        }

        public async Task<bool> AddItemAsync(ContestItem contestItem)
        {
            items.Add(contestItem);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ContestItem contestItem)
        {
            var oldItem = items.Where((ContestItem arg) => arg.Id == contestItem.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(contestItem);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ContestItem arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ContestItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ContestItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}