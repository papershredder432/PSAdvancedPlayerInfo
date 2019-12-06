using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;

namespace papershredder432.PSAdvancedPlayerInfo
{
    public class CommandPlayerInfo : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "advancedplayerinfo";

        public string Help => "Returns advanced player info.";

        public string Syntax => "/advancedplayerinfo";

        public List<string> Aliases => new List<string>() { "api", "apinfo" };

        public List<string> Permissions => new List<string>() { "ps.advancedplayerinfo" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length < 1)
            {
                UnturnedChat.Say(caller, "Correct usage: /api <playername>");
                return;
            }

            UnturnedPlayer selectedPlayer = UnturnedPlayer.FromName(command[0]);
            var Health = selectedPlayer.Health;
            var IsBleed = selectedPlayer.Bleeding;
            var IsBroken = selectedPlayer.Broken;
            var CName = selectedPlayer.CharacterName;
            var SID = selectedPlayer.CSteamID;
            var SName = selectedPlayer.SteamName;
            var Hunger = selectedPlayer.Hunger;
            var Thirst = selectedPlayer.Thirst;
            var IsVanished = selectedPlayer.VanishMode;
            var IsGodMode = selectedPlayer.GodMode;
            var IsAdmin = selectedPlayer.IsAdmin;
            var IP = PSAdvancedPlayerInfo.GetIP(selectedPlayer.CSteamID);

            if (PSAdvancedPlayerInfo.Instance.Configuration.Instance.ReturnIP == true)
            {
                UnturnedChat.Say(caller, "Info sent to console!");
                Logger.LogWarning($"[PSAdvancedPlayerInfo]" + Environment.NewLine +
                                   $"Advanced Info of {CName} ({SName}) [{SID}] ---{IP}---" + Environment.NewLine +
                                   $"Health: {Health} | Bleeding: {IsBleed} | Broken: {IsBroken}" + Environment.NewLine +
                                   $"Hunger: {Hunger} | Thirst: {Thirst}" + Environment.NewLine +
                                   $"Vanished: {IsVanished} | Godmode: {IsGodMode} | Admined: {IsAdmin}");
            }
            else
            {
                UnturnedChat.Say(caller, "Info sent to console!");
                Logger.LogWarning($"[PSAdvancedPlayerInfo]" + Environment.NewLine + 
                                   $"Advanced Info of {CName} ({SName}) [{SID}] ---IP RETURN DISABLED---" + Environment.NewLine +
                                   $"Health: {Health} | Bleeding: {IsBleed} | Broken: {IsBroken}" + Environment.NewLine +
                                   $"Hunger: {Hunger} | Thirst: {Thirst}" + Environment.NewLine +
                                   $"Vanished: {IsVanished} | Godmode: {IsGodMode} | Admined: {IsAdmin}");
            }
        }
    }
}
