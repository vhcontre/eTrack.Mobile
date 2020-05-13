using eTrack.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace eTrack.Mobile.Services
{
    public class AssetService : IDataStore<AssetModel>
    {
        public ObservableCollection<AssetModel> AssetModels;
        public async Task<IEnumerable<AssetModel>> GetItemsAsync(bool forceRefresh = false)
        {
            AssetModels = new ObservableCollection<AssetModel>();

            AssetModels.Add(new AssetModel()
            {
                Id = "1",
                Code = "Código - " + Guid.NewGuid().ToString().Substring(0, 5),
                FilePath = "icon_auditar.png",
                Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam. -"
            });
            AssetModels.Add(new AssetModel()
            {
                Id = "2",
                Code = "Código - " + Guid.NewGuid().ToString().Substring(0, 5),
                FilePath = "icon_reporte.png",
                Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam. -"
            });
            AssetModels.Add(new AssetModel()
            {
                Id = "3",
                Code = "Código - " + Guid.NewGuid().ToString().Substring(0, 5),
                FilePath = "icon_inventario.png",
                Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam. -"
            });
            AssetModels.Add(new AssetModel()
            {
                Id = "4",
                Code = "Código - " + Guid.NewGuid().ToString().Substring(0, 5),
                FilePath = "icon_tag.png",
                Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam. -"
            });
            for (int i = 5; i < 10; i++)
            {
                AssetModels.Add(new AssetModel()
                {
                    Id = i.ToString(),
                    Code = "Código - " + Guid.NewGuid().ToString().Substring(0, 5),
                    FilePath = "icon_auditar.png",
                    Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam. -"
                });
            }
            return await Task.FromResult(AssetModels);
        }
        public Task<bool> AddItemAsync(AssetModel item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<AssetModel> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        

        public Task<bool> UpdateItemAsync(AssetModel item)
        {
            throw new NotImplementedException();
        }
    }
    public class AssetAuditService : IDataStore<AssetAuditModel>
    {
        public ObservableCollection<AssetAuditModel> AssetAuditModels;
        public async Task<IEnumerable<AssetAuditModel>> GetItemsAsync(bool forceRefresh = false)
        {
            AssetAuditModels = new ObservableCollection<AssetAuditModel>();

            for (int i = 1; i < 10; i++)
            {
                AssetAuditModels.Add(new AssetAuditModel()
                {
                    Id = i.ToString(),
                    AssetId = "Asset-" + Guid.NewGuid().ToString().Substring(0, 5),
                    FilePath = "icon.png",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. -" + i.ToString()
                });
            }
            return await Task.FromResult(AssetAuditModels);
        }
        
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

        

        public Task<bool> UpdateItemAsync(AssetAuditModel item)
        {
            throw new NotImplementedException();
        }
    }
}