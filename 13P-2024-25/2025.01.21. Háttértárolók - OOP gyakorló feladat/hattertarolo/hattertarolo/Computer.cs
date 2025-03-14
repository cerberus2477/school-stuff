using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace hattertarolo
{
    internal class Computer
    {
        private string name;
        private List<Storage> storages;

        public Computer(string name)
        {
            storages = new List<Storage>();
            this.name = name;
        }

        //felcsatol()
        public void AddStorage(Storage storage)
        {
            storages.Add(storage);
        }

        public int MaxCapacity() => storages.Sum(s => s.MaxCapacityGb);
        public int FreeCapacity() => storages.Sum(s => s.FreeCapacityGb);
        public int UsedCapacity() => storages.Sum(s => s.UsedCapacityGb);

        //nem használtam returnt foreach közepén pedig sokkal szebb lett volna szerintem
        //dehát így itt egy szép hátultesztelős ciklus :3
        public void Archive(string fileName, Storage targetStorage = null)
        {
            // Fájl keresése az összes háttértárolón
            bool isFileFound = false;
            int i = 0;
            List<File> files;
            Storage storage;
            do
            {
                storage = storages[i];

                files = storage.FindFilesByName(fileName);
                if (!files.Any()) i++;
                else isFileFound = true;
            } while (!isFileFound && i < storages.Count);

            if (!isFileFound) throw new FileNotFoundException($"{fileName} file not found on {name} computer");
            else
            {
                //tudjuk hogy egy tárolón nincs több azonos nevű file, így vehetjük az elsőt
                File fileToArchive = files.First();
                // Ha nincs megadva cél háttértároló, keresünk egy másikat
                if (targetStorage == null)
                {
                    targetStorage = storages.FirstOrDefault(s => s != storage && s.FreeCapacityGb >= fileToArchive.SizeMb * 1024);
                    if (targetStorage == null)
                    {
                        throw new InvalidOperationException($"Not enough space on any storage to archive {fileToArchive.Name} on {this.name} computer.");
                    }
                    else
                    {
                        targetStorage.AddFile(fileToArchive);
                        Console.WriteLine($"{fileName} file successfully archived on {targetStorage}.");
                    }
                }
            }

        }


    }
}
