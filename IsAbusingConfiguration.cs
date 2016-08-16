using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAbusing
{
    public class IsAbusingConfiguration : IRocketPluginConfiguration
    {
        public bool debug;

       public void LoadDefaults()
        {
            debug = true;
        }
    }
}
