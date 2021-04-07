using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace Context
{
    public interface IAlbumData
    {
        IEnumerable<Album> GetAlbums(string search);
        Album GetAlbumById(int id);
    }

    public class InMemoryAlbumData : IAlbumData
    {
        readonly List<Album> _albums;

        public InMemoryAlbumData()
        {
            _albums = new List<Album>()
            {
                new Album {AlbumId = 1, Title = "Back In Black", ArtistId = 3},
                new Album {AlbumId = 2, Title = "Black Sabbath", ArtistId = 4},
                new Album {AlbumId = 3, Title = "American Idiot", ArtistId = 5}
            };
        }

        public IEnumerable<Album> GetAlbums(string search = null)
        {
            return from a in _albums
                where string.IsNullOrEmpty(search) || a.Title.StartsWith(search, StringComparison.CurrentCultureIgnoreCase)
                orderby a.AlbumId
                select a;
        }

        public Album GetAlbumById(int id)
        {
            return _albums.SingleOrDefault(a => a.AlbumId == id);
        }
    }
}