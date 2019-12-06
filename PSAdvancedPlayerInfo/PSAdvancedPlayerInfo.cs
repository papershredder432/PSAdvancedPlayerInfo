using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using SDG.Unturned;
using Steamworks;

namespace papershredder432.PSAdvancedPlayerInfo
{
    public class PSAdvancedPlayerInfo : RocketPlugin<PSAdvancedPlayerInfoConfiguration>
    {
        public static PSAdvancedPlayerInfo Instance;

        protected override void Load()
        {
            Instance = this;
            Logger.LogWarning("[PSAdvancedPlayerInfo] Loaded, made by papershredder432, join the support Discord here: https://discord.gg/ydjYVJ2");
        }

        protected override void Unload()
        {
            Instance = null;
            Logger.LogWarning("[PSAdvancedPlayerInfo] Unloaded.");
        }

        public static string GetIP(CSteamID id)
        {
            P2PSessionState_t sessionState;
            SteamGameServerNetworking.GetP2PSessionState(id, out sessionState);
            return Parser.getIPFromUInt32(sessionState.m_nRemoteIP);
        }
    }
}
