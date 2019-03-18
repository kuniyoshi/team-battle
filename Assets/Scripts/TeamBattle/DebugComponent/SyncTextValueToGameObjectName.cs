using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace TeamBattle.DebugComponent
{

    public class SyncTextValueToGameObjectName : MonoBehaviour
    {

        [Conditional("DEBUG")]
        void Start()
        {
            var text = GetComponentInChildren<Text>();

            if (text == null)
            {
                return;
            }

            text.text = name;
        }

    }

}
