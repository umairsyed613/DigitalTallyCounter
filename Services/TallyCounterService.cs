using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using DigitalTallyCounter.Models;

namespace DigitalTallyCounter.Services
{
    public interface ITallyCounterService
    {
        Task<List<TallyCounterItem>> GetTallyCounterItems();

        Task<TallyCounterItem> GetTallyCounterItem(string id);

        Task Upsert(TallyCounterItem item);

        Task RemoveCounter(string id);
    }

    public class TallyCounterService : ITallyCounterService
    {
        private static string _key = "A8D2DAD930EA4D039E5794627BE6BE4D";

        private readonly ILocalStorageService _localStorageService;

        public TallyCounterService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task<TallyCounterItem> GetTallyCounterItem(string id)
        {
            var allItems = await GetAllTallyCounterItemData() ?? new List<TallyCounterItem>();

            return allItems.FirstOrDefault(f => f.Id == id);
        }

        public async Task<List<TallyCounterItem>> GetTallyCounterItems()
        {
            return await GetAllTallyCounterItemData();
        }

        public async Task Upsert(TallyCounterItem item)
        {
            var allItems = await GetAllTallyCounterItemData() ?? new List<TallyCounterItem>();

            if (await _localStorageService.ContainKeyAsync(_key)) { await _localStorageService.RemoveItemAsync(_key); }

            var existing = allItems.FirstOrDefault(f => f.Id == item.Id);

            if (existing != null)
            {
                existing.Name = item.Name;
                existing.CountValue = item.CountValue;
            }
            else { allItems.Add(item); }

            await _localStorageService.SetItemAsync(_key, allItems);
        }

        public async Task RemoveCounter(string id)
        {
            var allItems = await GetAllTallyCounterItemData() ?? new List<TallyCounterItem>();

            if (await _localStorageService.ContainKeyAsync(_key)) { await _localStorageService.RemoveItemAsync(_key); }

            var existing = allItems.FirstOrDefault(f => f.Id == id);

            if (existing != null)
            {
                allItems.Remove(existing);
            }

            await _localStorageService.SetItemAsync(_key, allItems);
        }

        private async Task<List<TallyCounterItem>> GetAllTallyCounterItemData() => await _localStorageService.GetItemAsync<List<TallyCounterItem>>(_key);
    }
}
