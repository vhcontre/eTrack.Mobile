using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace eTrack.Mobile.Services
{
    public class AssetAuditService : IDataStore<AssetAuditModel>
    {
        public ObservableCollection<AssetAuditModel>  AssetAuditModels;
        public Task<bool> AddItemAsync(AssetAuditModel item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<AssetAuditModel> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AssetAuditModel>> GetItemsAsync(bool forceRefresh = false)
        {
            AssetAuditModels = new ObservableCollection<AssetAuditModel>();

            for (int i = 1; i < 20; i++)
            {
                AssetAuditModels.Add(new AssetAuditModel() { Id = i.ToString(), AssetId = "Asset-" + Guid.NewGuid().ToString().Substring(0,5), Description = "Description-" + i.ToString() });
            }
            return await Task.FromResult(AssetAuditModels);
        }

        public Task<bool> UpdateItemAsync(AssetAuditModel item)
        {
            throw new NotImplementedException();
        }
    }
}