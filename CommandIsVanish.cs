using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;

namespace IsAbusing
{
    class CommandIsVanish : IRocketCommand
    {
        public static UnturnedPlayer player2;

        public string Help
        {
            get { return "See if the user is in vanish."; }
        }

        public string Name
        {
            get { return "isvanish"; }
        }

        public string Syntax
        {
            get { return "[Player]"; }
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
                return new List<string>() { "abuse.isvanish" };
            }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {

            player2 = UnturnedPlayer.FromName(command[0]);
            if (player2 != null)
            {
                if (player2.VanishMode)
                {
                    UnturnedChat.Say(caller, player2.CharacterName + " has vanish enabled");
                }
                else
                {
                    UnturnedChat.Say(caller, player2.CharacterName + " has vanish disabled");
                }
            }
            else
            {
                UnturnedChat.Say(caller, "You may not have entered a player's name correctly or they are not in the server!");
                UnturnedChat.Say(caller, "Correct usage: /isvanish PLAYERNAME");
            }

        }
    }
}
