namespace dotNetPlayground.Models
{
    public class Computer
    {
        // Properties
        public int ComputerId { get; set; }
        public string? Motherboard { get; set; }
        public int CPUCores { get; set; } = 0;
        public bool HasWifi { get; set; } = false;
        public bool HasLTE { get; set; } = false;
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string? VideoCard { get; set; }

        // Constructor
        public Computer() { }

        public Computer(
            string motherboard,
            int cpuCores,
            bool hasWifi,
            bool hasLTE,
            DateTime releaseDate,
            decimal price,
            string videoCard
        )
        {
            Motherboard = motherboard;
            CPUCores = cpuCores;
            HasWifi = hasWifi;
            HasLTE = hasLTE;
            ReleaseDate = releaseDate;
            Price = price;
            VideoCard = videoCard;
        }
    }
}
