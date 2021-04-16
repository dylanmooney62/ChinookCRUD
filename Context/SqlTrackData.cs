using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Context
{
    public class SqlTrackData : ITrackData
    {
        private readonly ChinookContext _db;

        public SqlTrackData(ChinookContext db)
        {
            _db = db;
        }

        public Track Add(Track newTrack)
        {
            _db.Add(newTrack);

            return newTrack;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public Track Delete(int id)
        {
            Track track = GetById(id);

            if (track != null)
            {
                _db.Tracks.Remove(track);
            }

            return track;
        }

        public Track GetById(int id)
        {
            return _db.Tracks
                .Include(t => t.Genre)
                .SingleOrDefault(t => t.TrackId == id);
        }

        public int Count()
        {
            return _db.Albums.Count();
        }

        public IEnumerable<Track> Search(string search)
        {
            IEnumerable<Track> tracks = _db.Tracks
                .Include(t => t.Genre).Include(t => t.Album).OrderBy(t => t.Name);

            if (search == null) return tracks.ToList();

            return tracks.Where(t =>
                t.Name.ToLower().StartsWith(search.ToLower()) ||
                t.Composer != null && t.Composer.ToLower().StartsWith(search.ToLower()) ||
                t.Genre.Name != null && t.Genre.Name.ToLower().StartsWith(search.ToLower()) ||
                t.Album.Title != null && t.Album.Title.ToLower().StartsWith(search.ToLower())
            ).ToList();
        }


        public Track Update(Track updatedTrack)
        {
            EntityEntry<Track> entity = _db.Tracks.Attach(updatedTrack);

            entity.State = EntityState.Modified;

            return updatedTrack;
        }
    }
}