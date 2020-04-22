using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTrack.Mobile.Models;

namespace eTrack.Mobile.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = "ABM", Text = "ABM", Description="Gestión de Asset." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Asociar TAG", Description="Asociar TAG" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Inventariar", Description="Administrar inventario." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Localizar", Description="Localizar." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Auditar", Description="Auditar." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Reportes", Description="Gestión de reportes." }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}