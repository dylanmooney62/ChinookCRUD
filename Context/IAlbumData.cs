using System.Collections.Generic;
using Entities;

namespace Context
{
    public interface IAlbumData
    {
        IEnumerable<Albums> Search(string name);
        Albums GetById(int id);
        Albums Update(Albums updatedRestaurant);
        Albums Add(Albums newRestaurant);
        Albums Delete(int id);
        int Count();
        int Commit();
    }
}