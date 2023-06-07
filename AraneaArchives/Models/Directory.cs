using System.ComponentModel.DataAnnotations;

namespace AraneaArchives.Models
{
    public class Directory
    {
        public int DirectoryId { get; set; }
        [Required]
        public string DirectoryName { get; set; }

        //1 Dir will in referece with a lot of notes
        public List<Notes>? Notes { get; set; } = default;

    }
}
