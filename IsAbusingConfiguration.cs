using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsAbusing
{
    public class IsAbusingConfiguration : IRocketPluginConfiguration
    {
        public bool debug;
        public bool ShowInChat;
        public bool ShowGodemode;
        public bool ShowVanish;
        public bool ShowHeal;
        public string Color;

        public void LoadDefaults()
        {
            debug = false;
            ShowInChat = true;
            ShowVanish = true;
            ShowGodemode = true;
            ShowHeal = true;
            Color = "yellow";
        }
    }
}
