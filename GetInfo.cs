using System.Collections;
using MelonLoader;
using UnityEngine;
using ABI_RC.Core.InteractionSystem;
using ABI_RC.Core.Networking.IO.Social;

namespace GetInfo
{
    public class GetInfo : MelonMod
    {
        private ViewManager _viewManager { get; set; }

        private UserProfile_t _userProfile { get; set; }
        public override void OnApplicationStart()
        {
            MelonCoroutines.Start(WaitForUi());
            MelonLogger.Msg(System.ConsoleColor.Green, "Press G + I While Having A User Selected In The Big Menu");
        }

        private IEnumerator WaitForUi()
        {
            while (GameObject.Find("/Cohtml") == null)
            {
                yield return null;
            }
            _viewManager = GameObject.Find("/Cohtml/CohtmlWorldView").GetComponent<ViewManager>();
        }
        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.G) && Input.GetKeyDown(KeyCode.I))
            {
                _userProfile = (UserProfile_t)typeof(ViewManager).GetField("_userProfile", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(_viewManager);
                MelonLogger.Msg(System.ConsoleColor.DarkGray, $"{_userProfile.UserName}\nUserID: {_userProfile.UserId}\nRank: {_userProfile.UserRank}" + $"\nAvatarID: {_userProfile.CurrentAvatarId}\nAvatarName: {_userProfile.CurrentAvatarName}");
                //System.Windows.Forms.Clipboard.SetText(_userProfile.UserId);
            }
        }

    }
}
