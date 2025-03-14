using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hattertarolo
{
    internal abstract class Storage
    {
        protected List<File> files;
        protected int maxCapacityGb;
        protected int freeCapacityGb;
        protected int usedCapacityGb;

        public Storage(int maxcapgb)
        {
            files = new List<File>();
            maxCapacityGb = maxcapgb;
            freeCapacityGb = maxcapgb;
        }

        private int convertGbToMb(int Gb) => Gb * 1024;


        //getterek
        public int MaxCapacityGb => maxCapacityGb;
        public int FreeCapacityGb => freeCapacityGb;
        public int UsedCapacityGb => usedCapacityGb;

        // (összes fájl visszaadása kiíráshoz) - nem kellett
        public virtual List<File> GetAllFiles()
        {
            return new List<File>(files);
        }


        // todo: megnezni hogy van e ilyen nevű file, elfér e
        public virtual void AddFile(File file)
        {
            if (file.SizeMb > convertGbToMb(freeCapacityGb))
                throw new InvalidOperationException("Not enough free capacity to add the file.");
            files.Add(file);
            freeCapacityGb -= file.SizeMb;
        }


        // törlés ha van ilyen nevű file
        public virtual void RemoveFile(string name)
        {
            var file = files.FirstOrDefault(f => f.Name == name);
            if (file.Equals(default(File))) throw new InvalidOperationException("Not enough free capacity to add the file.");
            files.Remove(file);
            freeCapacityGb += file.SizeMb;
        }


        public virtual void Format()
        {
            files.Clear();
            freeCapacityGb = maxCapacityGb;
        }

        //lehetséges a körülbelüli keresés
        public List<File> FindFilesByName(string name, bool partialMatching = false)
        {
            if (partialMatching)
            {
                return files.Where(file => file.Name.ToLower().Contains(name.ToLower())).ToList();
            }
            //a stringcomparision.ordinalignorecase által nem kell kisbetűsség tenni a keresett szöveget és amiben kereünk, hanem ignorálja a nagy és kidbetűs eltéréseket
            return files.Where(file => file.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }








        // ez a függvény nem kellett, de nagyon menő
        // megadott feltétellel lehet meghivni, pl:
        //    FindFiles(file => file.IsHidden) 
        //    FindFiles(file => file.SizeInMb > 20)
        public List<File> FindFiles(Func<File, bool> predicate)
        {
            return files.Where(predicate).ToList();
        }
    }
}
