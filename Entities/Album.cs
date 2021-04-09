using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Album
    {
        [Required] public int AlbumId { get; set; }

        [Required, MaxLength(160)] public string Title { get; set; }

        [Required] public int ArtistId { get; set; }
    }
}