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
        public string Color;

        public void LoadDefaults()
        {
            debug = false;
            ShowInChat = true;
            Color = "yellow";
        }
    }
}
