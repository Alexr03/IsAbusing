using Rocket.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API.Collections;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using UnityEngine;
using SDG.Unturned;
using Steamworks;
using Rocket.Unturned.Chat;
using Rocket.Core.Logging;
using System.IO;
using Rocket.Unturned.Commands;

namespace IsAbusing
{
    public class IsAbusing : RocketPlugin<IsAbusingConfiguration>
    {
        public static IsAbusing Instance;

        public string directory = System.IO.Directory.GetCurrentDirectory() + "/..";

        public static UnturnedPlayer murderer3;

        protected override void Load()
        {
            Instance = this;
            Rocket.Unturned.Events.UnturnedPlayerEvents.OnPlayerDeath += onplayerdeath;
            Rocket.Core.Logging.Logger.Log("IsAbusing has loaded!");

            if (File.Exists(directory + "/Admin-Abuse.txt"))
            {
                Rocket.Core.Logging.Logger.Log(directory + "/Admin-Abuse.txt Already exists, loopholing...");
            }
            else
            {
                File.CreateText(directory + "/Admin-Abuse.txt");
            }
        }

        protected override void Unload()
        {
            Rocket.Unturned.Events.UnturnedPlayerEvents.OnPlayerDeath -= onplayerdeath;
            Rocket.Core.Logging.Logger.Log("IsAbusing has unloaded!");
        }

        private void FixedUpdate()
        {

        }

        public override TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList() {
                };
            }
        }
        private void onplayerdeath(UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer)
        {
            murderer3 = UnturnedPlayer.FromCSteamID(murderer);
            if (Configuration.Instance.ShowInChat == true)
            {
                if (cause == EDeathCause.SENTRY) { }
                try
                {
                    if (murderer3.GodMode == true)
                    {
                        UnturnedChat.Say(player.CharacterName + " died by a player in godmode ABUSER: " + murderer3.CharacterName, UnturnedChat.GetColorFromName(Configuration.Instance.Color, Color.green));

                        using (StreamWriter w = File.AppendText(directory + "/Admin-Abuse.txt"))
                        {
                            w.WriteLine(player.CharacterName + " died by a abusive admin! ABUSER: " + murderer3.CharacterName + " Steam64ID: " + murderer3.CSteamID + w.NewLine);
                            w.Close();
                        }
                    }
                    else if (murderer3.VanishMode == true)
                    {
                        UnturnedChat.Say(player.CharacterName + " died by a player in vanish mode ABUSER: " + murderer3.CharacterName, UnturnedChat.GetColorFromName(Configuration.Instance.Color, Color.green));

                        using (StreamWriter w = File.AppendText(directory + "/Admin-Abuse.txt"))
                        {
                            w.WriteLine(player.CharacterName + " died by a abusive admin! ABUSER: " + murderer3.CharacterName + " Steam64ID: " + murderer3.CSteamID + w.NewLine);
                            w.Close();
                        }
                    }
                    else
                    {
                        Rocket.Core.Logging.Logger.Log(player.CharacterName + " Died by a player not in godmode");
                    }
                }
                catch (Exception e)
                {
                    if (Configuration.Instance.debug == true)
                    {
                        Rocket.Core.Logging.Logger.LogException(e);
                    }
                }
            }
            else
            {
                Rocket.Core.Logging.Logger.Log("Chat is disabled to show messages.");
            }
        }
    }
}