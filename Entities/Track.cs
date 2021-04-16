﻿#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Track
    {
        public Track()
        {
            InvoiceItems = new HashSet<InvoiceItem>();
            PlaylistTrack = new HashSet<PlaylistTrack>();
        }

        public int TrackId { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "Album is required")]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Media Type is required")]
        public int MediaTypeId { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public int GenreId { get; set; }

        public string? Composer { get; set; }
        public int Milliseconds { get; set; }

        public long? Bytes { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal UnitPrice { get; set; }

        public virtual Album? Album { get; set; }
        public virtual Genre? Genre { get; set; }
        public virtual MediaType? MediaType { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
        public virtual ICollection<PlaylistTrack> PlaylistTrack { get; set; }
    }
}