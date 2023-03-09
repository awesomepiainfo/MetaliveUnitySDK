/*
 * brunch : phantom
 * update : 2023-03-09
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

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

        [MenuItem("Metalive/Dashboard", priority = 0)]
        public static void Manager()
        {
            if(MetaliveSetting.IsAccount)
            {                
                Dashboard();
            }
            else
            {                
                Profile();                                    
            }
        }

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

        public static void Dashboard()
        {
            if(MetaliveSetting.IsAddressable == false)
            {
                var redirect = MetaliveSetting.AddressableInit();
                if(redirect.Equals(1000) == false)
                {
                    return;
                }
            }

            var window = EditorWindow.GetWindow<MetaliveDashboard>();
            var x = 640f;
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