using System.Collections;
using System.Collections.Generic;
using FirebirdGames.Utilities;
using FirebirdGames.Utilities.UI;
using UnityEngine;

namespace LudumDare52
{
    public class MyGameRoot : GameRoot<MyGameRoot>
    {
        [SerializeField] private Texture2D cursorTexture;
        protected override IEnumerator DoInitializeModules()
        {
            return base.DoInitializeModules();
        }

        protected override void OnBoostrapLoadComplete()
        {
            base.OnBoostrapLoadComplete();
            
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
            UIManager.Instance.ShowBaseDialog(UIReferences.Instance.TitleDialogPrefab, true);
        }

        protected override void OnSceneSwitchDone()
        {
            if (curSceneIndex == 0)
            {
                UIManager.Instance.ShowBaseDialog(UIReferences.Instance.TitleDialogPrefab, true);
            }
        }
    }
}
