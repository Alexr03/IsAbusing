using Rocket.Core.Plugins;
using System;
using Rocket.API.Collections;
using Rocket.Unturned.Player;
using UnityEngine;
using SDG.Unturned;
using Steamworks;
using Rocket.Unturned.Chat;
using System.IO;

namespace IsAbusing
{
    public class IsAbusing : RocketPlugin<IsAbusingConfiguration>
    {
        public static IsAbusing Instance;

        public string directory = System.IO.Directory.GetCurrentDirectory() + "/..";

        protected override void Load()
        {
            Instance = this;
            Rocket.Unturned.Events.UnturnedPlayerEvents.OnPlayerDeath += onPlayerDeath;
            ChatManager.onChatted += OnChatted;
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
            Rocket.Unturned.Events.UnturnedPlayerEvents.OnPlayerDeath -= onPlayerDeath;
            Rocket.Core.Logging.Logger.Log("IsAbusing has unloaded!");
        }

        private void FixedUpdate() { }

        public override TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList() {
                };
            }
        }

        private void OnChatted(SteamPlayer player, EChatMode mode, ref Color chatted, ref bool isrich, string text, ref bool isvisible)
        {
            if (Configuration.Instance.ShowHeal)
            {
                if (text.Contains("/heal"))
                {
                    UnturnedPlayer player2 = UnturnedPlayer.FromSteamPlayer(player);
                    UnturnedChat.Say($"{player2.DisplayName} has used /heal!");
                }
            }


        }
        private void onPlayerDeath(UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer)
        {
            UnturnedPlayer murderer3 = UnturnedPlayer.FromCSteamID(murderer);
            if (Configuration.Instance.ShowInChat)
            {
                if (cause == EDeathCause.SENTRY) return;
                try
                {
                    if(Configuration.Instance.ShowGodemode)
                    {
                        if (murderer3.GodMode)
                        {
                            if (murderer3.IsInVehicle)
                            {
                                UnturnedChat.Say(player.CharacterName + " was roadkilled by " + murderer3.CharacterName + " in godmode! VEHICLE: " + murderer3.CurrentVehicle, UnturnedChat.GetColorFromName(Configuration.Instance.Color, Color.green));
                            }
                            else
                            {
                                UnturnedChat.Say(player.CharacterName + " died by " + murderer3.CharacterName + " in godmode!", UnturnedChat.GetColorFromName(Configuration.Instance.Color, Color.green));
                            }

                            using (StreamWriter w = File.AppendText(directory + "/Admin-Abuse.txt"))
                            {
                                w.WriteLine(player.CharacterName + " died by a abusive admin! ABUSER: " + murderer3.CharacterName + " Steam64ID: " + murderer3.CSteamID + w.NewLine);
                                w.Close();
                            }
                        }
                    }
                    if(Configuration.Instance.ShowVanish)
                    {
                        if (murderer3.VanishMode)
                        {
                            if (murderer3.IsInVehicle)
                            {
                                UnturnedChat.Say(player.CharacterName + " was roadkilled by " + murderer3.CharacterName + " in vanish mode! VEHICLE: " + murderer3.CurrentVehicle, UnturnedChat.GetColorFromName(Configuration.Instance.Color, Color.green));
                            }
                            else
                            {
                                UnturnedChat.Say(player.CharacterName + " died by " + murderer3.CharacterName + " in vanish mode!", UnturnedChat.GetColorFromName(Configuration.Instance.Color, Color.green));
                            }

                            using (StreamWriter w = File.AppendText(directory + "/Admin-Abuse.txt"))
                            {
                                w.WriteLine(player.CharacterName + " died by a abusive admin! ABUSER: " + murderer3.CharacterName + " Steam64ID: " + murderer3.CSteamID + w.NewLine);
                                w.Close();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    if (Configuration.Instance.debug)
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