using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare52
{
    public class AnchorObject : InteractableObject
    {
        protected override void HandleOnPointerClick()
        {
             MyGameRoot.Instance.GoToScene(0);
        }
    }
}
