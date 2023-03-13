/*
 * brunch : phantom
 * update : 2023-03-13
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Metalive
{    

    public class MetaliveSetting : Editor
    {

        #region Method

        // ==================================================
        // [ Viewer ]
        // ==================================================
        public void Viewer()
        {            
            // [ Style ]            
            GUIStyle button = new GUIStyle(GUI.skin.button)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
            };

         
            // [ Layout ]
            GUILayout.BeginArea(new Rect(200f, 20f, 440f, 40f));
            {
                if (GUILayout.Button("Profile", button, GUILayout.Width(80f), GUILayout.Height(32f)))
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