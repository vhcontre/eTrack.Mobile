using eTrack.Mobile.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace eTrack.Mobile
{
    public class AssetAuditModel : IEntity
    {
        public string Id { get; set; }

        public string AssetId { get; set; }

        public string Description { get; set; }

        public string GeoLocation { get; set; }

        public string AuditedBy { get; set; }

        public DateTime TimeStamp { get; set; }

        //Por ahora, es un solo archivo de imagen
        public string FilePath { get; set; }
        
    }

    
}
