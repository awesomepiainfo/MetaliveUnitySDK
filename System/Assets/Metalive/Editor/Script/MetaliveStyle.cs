/*
 * brunch : phantom
 * update : 2023-02-17
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metalive
{
    public class MetaliveStyle
    {

        #region Area

        // ==================================================
        // [ Area ]
        // ==================================================
        internal class Area
        {
            public static GUIStyle defalut = new GUIStyle()
            {

            };
        }

        #endregion



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
                alignment = TextAnchor.MiddleCenter,
            };

            public static GUIStyle title = new GUIStyle(GUI.skin.label)
            {
                fontSize = 28,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft
            };

            public static GUIStyle subTitle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.UpperLeft,
                padding = new RectOffset(4, 0, 0, 0)
            };

            public static GUIStyle category = new GUIStyle(GUI.skin.label)
            {
                fontSize = 16,
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
                fontSize = 12,
                alignment = TextAnchor.MiddleLeft,
                padding = new RectOffset(12, 0, 0, 0)
            };
        }

        #endregion



        #region Toggle

        // ==================================================
        // [ Toggle ]
        // ==================================================
        internal class Toggle
        {
            public static GUIStyle defalut = new GUIStyle(GUI.skin.toggle)
            {
                fontSize = 8,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft,
                padding = new RectOffset(20, 0, 0, 2)
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
                alignment = TextAnchor.MiddleCenter,
            };

            public static GUIStyle select = new GUIStyle(GUI.skin.button)
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft,
                padding = new RectOffset(32, 0, 0, 0),
            };

            public static GUIStyle unSelect = new GUIStyle(GUI.skin.button)
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft,
                padding = new RectOffset(32, 0, 0, 0),
            };
        }

        #endregion

    }
}

#endif