using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_mimic.V1.Models {

    [Table("Words")]
    public class Word {
        public Guid id { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public int score { get; set; }
        public bool active { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public object? Words { get; internal set; }
    }
}
