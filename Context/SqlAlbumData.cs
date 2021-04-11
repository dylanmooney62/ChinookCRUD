using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Context
{
    public class SqlAlbumData : IAlbumData
    {
        private readonly ChinookContext _db;

        public SqlAlbumData(ChinookContext db)
        {
            _db = db;
        }

        public Albums Add(Albums newAlbum)
        {
            _db.Add(newAlbum);

            return newAlbum;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public Albums Delete(int id)
        {
            Albums album = GetById(id);

            if (album != null)
            {
                _db.Albums.Remove(album);
            }

            return album;
        }

        public Albums GetById(int id)
        {
            return _db.Albums
                .Include(a => a.Artist)
                .SingleOrDefault(a => a.AlbumId == id);
        }

        public int Count()
        {
            return _db.Albums.Count();
        }

        public IEnumerable<Albums> Search(string search)
        {
            IEnumerable<Albums> albums = _db.Albums
                .Include(a => a.Artist).OrderBy(a => a.Title);

            if (search == null) return albums.ToList();
            
            return albums.Where(a =>
                a.Title.ToLower().StartsWith(search.ToLower()) ||
                a.Artist.Name.ToLower().StartsWith(search.ToLower())).ToList();
        }


        public Albums Update(Albums updatedRestaurant)
        {
            EntityEntry<Albums> entity = _db.Albums.Attach(updatedRestaurant);

            entity.State = EntityState.Modified;

            return updatedRestaurant;
        }
    }
}