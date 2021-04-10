using System.Collections.Generic;
using Entities;

namespace Context
{
    public interface IAlbumData
    {
        IEnumerable<Album> Search(string name);
        Album GetById(int id);
        Album Update(Album updatedRestaurant);
        Album Add(Album newRestaurant);
        Album Delete(int id);
        int Count();
        int Commit();
    }
}