using System.Collections;
using System.Collections.Generic;
using FirebirdGames.Utilities;
using FirebirdGames.Utilities.UI;
using UnityEngine;

namespace LudumDare52
{
    public class TitleDialog : Dialog
    {
        public void OnStartClicked()
        {
            MyGameRoot.Instance.GoToScene(1);
            OnCloseClicked();
        }

        public void OnExitClicked()
        {
            Utils.QuitApplication();
        }
    }
}
