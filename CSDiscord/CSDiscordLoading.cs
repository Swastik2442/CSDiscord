using ColossalFramework.UI;
using ICities;

namespace CSDiscord
{
    public class CSDiscordLoading : ILoadingExtension
    {
        // called when level loading begins
        public void OnCreated(ILoading loading)
        {
        }

        // called when level is loaded
        public void OnLevelLoaded(LoadMode mode)
        {
            // create dialog panel
            //ExceptionPanel panel = UIView.library.ShowModal<ExceptionPanel>("ExceptionPanel");
            //string msg = ("The City is " + "CityName" + "!");
            // display a message for the user in the panel
            //panel.SetMessage("CSDiscord", msg, false);
        }

        // called when unloading begins
        public void OnLevelUnloading()
        {
        }

        // called when unloading finished
        public void OnReleased()
        {
        }
    }
}