using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hattertarolo
{
    internal struct File
    {
        private string name;
        private int sizeMb;
        private bool isReadonly;
        private bool isSystemfile;
        private bool isHidden;

        public File(string name, int sizeInMb, bool isReadonly, bool isSystemfile, bool isHidden)
        {
            this.name = name;
            this.sizeMb = sizeInMb;
            this.isReadonly = isReadonly;
            this.isSystemfile = isSystemfile;
            this.isHidden = isHidden;
        }

        //getterek
        public string Name => name;
        public int SizeMb => sizeMb;
        public bool IsReadonly => isReadonly;
        public bool IsSystemfile => isSystemfile;
        public bool IsHidden => isHidden;

        //nem tudom még hogy használom-e
        public override string ToString()
        {
            return $"File: {name}, Size: {sizeMb} MB, Readonly: {isReadonly}, System: {isSystemfile}, Hidden: {isHidden}";
        }
    }
}
