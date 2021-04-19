using System.Collections.Generic;
using Entities;

namespace Context
{
    public interface IArtistData
    {
        IEnumerable<Artist> Search(string name);
        Artist GetById(int id);
        Artist Update(Track updatedTrack);
        Artist Add(Track newTrack);
        Artist Delete(int id);
        int Count();
        int Commit();
    }
}