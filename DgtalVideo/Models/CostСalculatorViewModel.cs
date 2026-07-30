using DgtalVideo.Data.Enums;

namespace DgtalVideo.Models
{
    public class CostСalculatorViewModel
    {
        public decimal TotalCost { get; set; }
        public ServiceType SelectedServices { get; set; }
        public VolumeOfSourceFiles VolumeOfSourceFiles { get; set; }
        public Subtitles Subtitles { get; set; }
        public Urgency Urgency { get; set; }
        public Format FormatMovie { get; set; }
    }
}
