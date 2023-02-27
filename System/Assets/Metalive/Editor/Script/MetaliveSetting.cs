/*
 * brunch : phantom
 * update : 2023-02-27
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Metalive
{

    public class MetaliveSetting : EditorWindow
    {

        #region Method

        public void Viewer()
        {
            GUILayout.BeginArea(new Rect(180f, 20f, 440f, 40f));
            {
                if (GUILayout.Button("Profile", MetaliveStyle.Button.defalut, GUILayout.Width(80f), GUILayout.Height(32f)))
                {
                    MetaliveEditor.Profile();
                }
            }
            GUILayout.EndArea();
        }

        #endregion
    }

}

#endif