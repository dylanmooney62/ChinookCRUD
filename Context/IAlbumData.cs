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
        Album UpdateAlbum(Album updatedAlbum);

        Album CreateAlbum(Album album);
        int Commit();
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
                where string.IsNullOrEmpty(search) ||
                      a.Title.StartsWith(search, StringComparison.CurrentCultureIgnoreCase)
                orderby a.AlbumId
                select a;
        }

        public Album GetAlbumById(int id)
        {
            return _albums.SingleOrDefault(a => a.AlbumId == id);
        }
        
        public Album CreateAlbum(Album newAlbum)
        {
            _albums.Add(newAlbum);

            newAlbum.AlbumId = _albums.Max(a => a.AlbumId + 1);

            return newAlbum;
        }


        public Album UpdateAlbum(Album updatedAlbum)
        {
            Album album = _albums.SingleOrDefault(a => a.AlbumId == updatedAlbum.AlbumId);

            if (album != null)
            {
                album.Title = updatedAlbum.Title;
            }

            return album;
        }

       
        public int Commit()
        {
            return 0;
        }
    }
}