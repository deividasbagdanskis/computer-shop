using ComputerShop.Models;

namespace ComputerShop.ViewModels
{
    public class RecommendationViewModel
    {
        public Computer RequestedComputer { get; set; }
        public Computer RecommendedComputer { get; set; }
        public int ScreenSizePriority { get; set; }
        public int CorePriority { get; set; }
        public int ClockSpeedPriority { get; set; }
        public int RAMPriority { get; set; }
        public int StoragePriority { get; set; }
        public int PricePriority { get; set; }
        public bool ScreenSizeNotImportant { get; set; }
        public bool CoresNotImportant { get; set; }
        public bool ClockSpeedNotImportant { get; set; }
        public bool RAMNotImportant { get; set; }
        public bool StorageNotImportant { get; set; }
        public bool PriceNotImportant { get; set; }
    }
}
