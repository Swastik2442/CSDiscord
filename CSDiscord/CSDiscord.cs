//Copyright 2022 Swastik2442
//
//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.

using System;
using ICities;
using UnityEngine;
using DiscordRPC;
using DiscordRPC.Logging;
using ColossalFramework.UI;

namespace CSDiscord
{
    public class CSDiscord : IUserMod
    {
        public string Name => "CSDiscord";
        public string Description => "Enable Discord Rich Presence for Cities: Skylines";      
    }

    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            // Get the UIView object. This seems to be the top-level object for most
            // of the UI.
            var uiView = UIView.GetAView();

            // Add a new button to the view.
            var button = (UIButton)uiView.AddUIComponent(typeof(UIButton));

            // Set the text to show on the button.
            button.text = "DiscordRP";

            // Set the button dimensions.
            button.width = 100;
            button.height = 30;

            // Style the button to look like a menu button.
            button.normalBgSprite = "ButtonMenu";
            button.disabledBgSprite = "ButtonMenuDisabled";
            button.hoveredBgSprite = "ButtonMenuHovered";
            button.focusedBgSprite = "ButtonMenuFocused";
            button.pressedBgSprite = "ButtonMenuPressed";
            button.textColor = new Color32(255, 255, 255, 255);
            button.disabledTextColor = new Color32(7, 7, 7, 255);
            button.hoveredTextColor = new Color32(7, 132, 255, 255);
            button.focusedTextColor = new Color32(255, 255, 255, 255);
            button.pressedTextColor = new Color32(30, 30, 44, 255);

            // Enable button sounds.
            button.playAudioEvents = true;

            // Place the button.
            button.transformPosition = new Vector3(-1.65f, 0.97f);

            // Respond to button click.
            button.eventClick += ButtonClick;
        }

        private DiscordRpcClient client;
        private void ButtonClick(UIComponent component, UIMouseEventParameter eventParam)
        {
            /*
            Create a Discord client
            NOTE: 	If you are using Unity3D, you must use the full constructor and define
                     the pipe connection.
            */
            client = new DiscordRpcClient("925994149390454804");

            //Set the logger
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            //Subscribe to events
            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Received Update! {0}", e.Presence);
            };

            //Connect to the RPC
            client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(new RichPresence()
            {
                Details = "Example Project",
                State = "csharp example",
                Assets = new Assets()
                {
                    LargeImageKey = "cs_icon",
                    LargeImageText = "Lachee's Discord IPC Library",
                    SmallImageKey = "user_icon"
                }
            });
        }
    }
}
