/*
 * brunch : phantom
 * update : 2023-03-09
 * email : chho1365@gmail.com
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

namespace Metalive
{

    public class MetaliveStyle
    {

        #region Label

        // ==================================================
        // [ Label ]
        // ==================================================
        internal class Label
        {
            public static GUIStyle defalut = new GUIStyle(GUI.skin.label)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft,              
            };
        }

        #endregion



        #region TextField
        // ==================================================
        // [ TextField ]
        // ==================================================
        internal class TextField
        {
            public static GUIStyle defalut = new GUIStyle(GUI.skin.textField)
            {
                              
            };
        }

        #endregion



        #region Button
        // ==================================================
        // [ Button ]
        // ==================================================
        internal class Button
        {
            public static GUIStyle defalut = new GUIStyle(GUI.skin.button)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter
            };
        }

        #endregion

    }

}

#endif