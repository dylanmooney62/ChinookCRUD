using System.Collections.Generic;
using System.Linq;
using Entities;

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
            throw new System.NotImplementedException();
        }

        public Artist Update(Track updatedTrack)
        {
            throw new System.NotImplementedException();
        }

        public Artist Add(Track newTrack)
        {
            throw new System.NotImplementedException();
        }

        public Artist Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Count()
        {
            throw new System.NotImplementedException();
        }

        public int Commit()
        {
            throw new System.NotImplementedException();
        }
    }
}