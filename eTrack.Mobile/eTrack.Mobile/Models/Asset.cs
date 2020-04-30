using eTrack.Mobile.Services;
using System.ComponentModel.DataAnnotations;

namespace eTrack.Mobile.Models
{
    public class Asset : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Tag { get; set; }
        public string SapId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int CostCenterId { get; set; }
        public string CostCenterName { get; set; }
        public string CreatedBy { get; set; }
        public bool Enabled { get; set; }
        public string LastModifiedBy { get; set; }

        //Por ahora, es un solo archivo de imagen
        public string FilePath { get; set; }

        
    }
}
