using ICities;
using UnityEngine;

namespace CSDiscord
{

    public class CSDiscord : IUserMod
    {

        public string Name
        {
            get { return "Cities: Skylines Discord Presence"; }
        }

        public string Description
        {
            get { return "This mod enable Discord Rich Presence for Cities: SKylines."; }
        }
    }
}
