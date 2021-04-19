using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Context
{
    public class SqlArtistData : IArtistData

    {
        private readonly ChinookContext _db;

        public SqlArtistData(ChinookContext db)
        {
            _db = db;
        }

        public IEnumerable<Artist> Search(string name)
        {
            IEnumerable<Artist> artists = _db.Artists;

            if (name == null) return artists.OrderByDescending(a => a.ArtistId);

            return artists.OrderBy(a => a.Name).Where(a => a.Name.ToLower().StartsWith(name.ToLower()));
        }

        public Artist GetById(int id)
        {
            return _db.Artists.SingleOrDefault(a => a.ArtistId == id);
        }

        public Artist Update(Artist updatedArtist)
        {
            EntityEntry<Artist> entity = _db.Artists.Attach(updatedArtist);

            entity.State = EntityState.Modified;

            return updatedArtist;
        }

        public Artist Add(Artist newArtist)
        {
            _db.Add(newArtist);

            return newArtist;
        }

        public Artist Delete(int id)
        {
            Artist artist = GetById(id);

            if (artist != null)
            {
                _db.Artists.Remove(artist);
            }

            return artist;
        }

        public int Count()
        {
            return _db.Artists.Count();
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}