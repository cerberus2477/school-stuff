using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hattertarolo
{
    internal class DVD : Storage
    {
        protected bool isLocked;

        public DVD() : base(4700) // 4700 MB DVD kapacitásnak
        {
            isLocked = false;
        }

        public void Lock()
        {
            isLocked = true;
            freeCapacityGb = 0; // ha zárolt, nincs szabad kapacitás
        }

        public override void AddFile(File file)
        {
            if (isLocked)
                throw new InvalidOperationException("Cannot add files to a locked DVD.");
            base.AddFile(file);
        }

        public override void RemoveFile(string name)
        {
            if (isLocked)
                throw new InvalidOperationException("Cannot delete files from a locked DVD.");
            base.RemoveFile(name);
        }

        public override void Format()
        {
            if (isLocked)
                throw new InvalidOperationException("Cannot format a locked DVD. - \"egyszer írható DVD\"");
            base.Format();
        }
    }
}