using System.ComponentModel.DataAnnotations;

namespace AraneaArchives.Models
{
    public class Notes
    {
        public int NotesId { get; set; }
       
        [Required]
        public string NoteName { get; set; }
        public string NoteContents { get; set; }

        public int DirectoryId { get; set; }
        public Directory? Directorys { get; set; } = default;
    }
}
