using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_Supervisione_ITIS
{
    public partial class LedBulb : Component
    {
        public LedBulb()
        {
            
        }

        public LedBulb(IContainer container)
        {
            container.Add(this);

            
        }
    }
}
