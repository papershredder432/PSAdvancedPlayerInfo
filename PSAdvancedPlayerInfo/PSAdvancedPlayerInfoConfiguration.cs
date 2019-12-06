using Rocket.API;

namespace papershredder432.PSAdvancedPlayerInfo
{
    public class PSAdvancedPlayerInfoConfiguration : IRocketPluginConfiguration
    {
        public bool ReturnIP;

        public void LoadDefaults()
        {
            ReturnIP = true;
        }
    }
}