using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        public int ArtistId { get; set; }
        
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
