using System.Collections.Generic;
using Entities;

namespace Context
{
    public interface ITrackData
    {
        IEnumerable<Track> Search(string name);
        Track GetById(int id);
        Track Update(Track updatedTrack);
        Track Add(Track newTrack);
        Track Delete(int id);
        int Count();
        int Commit();
    }
}