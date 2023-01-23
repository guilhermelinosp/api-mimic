namespace api_mimic.Models;

public class Word
{
    public int id { get; set; }
    public string? name { get; set; }
    public int score { get; set; }
    public bool active { get; set; }
    public DateTime created { get; set; }
    public DateTime updated { get; set; }
}