using System.ComponentModel.DataAnnotations;

namespace AraneaArchives.Models
{
    public class Notes
    {
      
        public int NotesId { get; set; }

        [Required]
        public string NotesName { get; set; }
        public string NotesContents { get; set; }

        public int DirectoryId { get; set; }
        public Directory? Directorys { get; set; } = default;
    }
}
