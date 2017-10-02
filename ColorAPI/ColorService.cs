using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColorAPI
{
    public class ColorService : IColorService
    {
        List<ColorItem> listColors;  // This will only work for a single instance of the service

        public ColorService()
        {
            listColors = new List<ColorItem>
            {
                new ColorItem {Id = 1, Name = "Red" },
                new ColorItem {Id = 2, Name = "Yellow" },
                new ColorItem {Id = 3, Name = "Black" },
            };
        }

        public IEnumerable<ColorItem> GetAll()
        {
            return listColors;
        }

        public ColorItem GetById(int id)
        {
            foreach (ColorItem item in listColors)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public bool AddItem(ColorItem item)
        {
            int idxName = listColors.FindIndex(a => a.Name.ToLower() == item.Name.ToLower());
            if (idxName >= 0)
                listColors.RemoveAt(idxName);

            int idxId = listColors.FindIndex(a => a.Id == item.Id);
            if (idxId >= 0)
                listColors.RemoveAt(idxId);

            listColors.Add(item);

            return true;
        }

        public bool DeleteById(int id)
        {
            int idxId = listColors.FindIndex(a => a.Id == id);
            if (idxId == -1)
                return false;

            listColors.RemoveAt(idxId);
            return true;
        }
    }

    public interface IColorService
    {
        IEnumerable<ColorItem> GetAll();

        ColorItem GetById(int id);

        bool AddItem(ColorItem item);

        bool DeleteById(int id);

    }

    public class ColorItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
