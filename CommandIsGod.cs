using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Provider;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace IsAbusing
{
    class CommandIsGod : IRocketCommand
    {
        public static UnturnedPlayer player2;

        public string Help
        {
            get { return "See's if the user is in godmode."; }
        }

        public string Name
        {
            get { return "isgod"; }
        }

        public string Syntax
        {
            get { return "/isgod <player>"; }
        }

        public List<string> Aliases
        {
            get { return new List<string>(); }
        }

        public AllowedCaller AllowedCaller
        {
            get { return AllowedCaller.Both; }
        }

        public List<string> Permissions
        {
            get
            {
                return new List<string>() { "abuse.isgod" };
            }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length == 1)
            {
                player2 = UnturnedPlayer.FromName(command[0]);
                if (player2.GodMode == true)
                {
                    UnturnedChat.Say(player2.CharacterName + "Has godmode enabled");
                }
                else
                {
                    UnturnedChat.Say(player2.CharacterName + "Has godmode disabled");
                }
            }
        }
    }
}
