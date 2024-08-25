namespace dotNetPlayground.Models;

public class Computer
{
    public string Motherboard { get; set; } = string.Empty;
    public int CPUCores { get; set; } = 0;
    public bool HasWifi { set; get; } = false;
    public bool HasLTE { get; set; } = false;
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public string VideoCard { get; set; } = string.Empty;
}
