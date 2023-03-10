/*
 * brunch : phantom
 * update : 2023-03-10
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.UIElements;

namespace Metalive
{

    [InitializeOnLoad]
    public class MetaliveEditor : Editor
    {
        static MetaliveEditor()
        {
            
        }


        #region Variable



        #endregion



        #region Method

        // ==================================================
        // Menu
        // ==================================================

        [MenuItem("Metalive/Dashboard", priority = 0)]
        public static void Manager()
        {
            if(Metalive.IsAccount)
            {                
                Dashboard();
            }
            else
            {                
                Profile();                                    
            }
        }


        // ==================================================
        // [ Profile ]
        // ==================================================
        public static void Profile()
        {
            var window = EditorWindow.GetWindow<MetaliveProfile>();
            var x = 280f;
            var y = 420f;

            window.position = new Rect(((Screen.currentResolution.width * 0.5f) - (x * 0.5f)), 100, x, y);                        
            window.titleContent = new GUIContent("[ Metalive ] Profile");
            window.minSize = window.maxSize = new Vector2(x, y);
            window.Show();
        }


        // ==================================================
        // [ Dashboard ]
        // ==================================================
        public static void Dashboard()
        {
            var window = EditorWindow.GetWindow<MetaliveDashboard>();
            var x = 720f;
            var y = 480f;

            window.position = new Rect(100, 100, x, y);
            window.titleContent = new GUIContent("[ Metalive ] Dashboard");
            window.minSize = window.maxSize = new Vector2(x, y);
            window.Show();
        }

        #endregion

    }

}

#endif