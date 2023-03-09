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
using UnityEngine;

namespace MetaliveEditor
{

    public class MetaliveLabel
    {
        public static readonly string version = "1.0.0";
        public static readonly string[] property =
        {
            "Scene",
            "Skybox",
            "Data",
            "Image",
            "Video",            
            "Sound",            
            "Player"            
        };
    }

    public class MetaliveTag
    {
        public static readonly string version = "1.0.0";
        public static readonly string[] property =
        {
            "GameManager",
            "NetworkManager"
        };
    }

    public class MetaliveLayer
    {
        public static readonly string version = "1.0.0";
        public static readonly string[] property =
        {
            "Obstruction",
            "Point",
            "Interactive",
            "Map",
            "Player",
            "Enemy",
            "Npc"
        };
    }


    public class MetaliveProperty : EditorWindow
    {

        #region Variable

        private PropertyCategory property = PropertyCategory.Addressable;
        private Vector2 propertyScroll;


        #endregion



        #region Lifecycle

        private void Awake()
        {
            var setting = AddressableAssetSettingsDefaultObject.Settings;
            if(setting != null)
            {                
                var list = setting.GetLabels();                
                var label = list.Find(x => x == "default");              
                if (!string.IsNullOrEmpty(label))
                {                    
                    setting.RemoveLabel(label);
                }
            }             
        }

        #endregion



        #region Method

        public void Viewer()
        {

            GUILayout.BeginArea(new Rect(180f, 20f, 140f, 60f), MetaliveStyle.Area.defalut);
            {
                GUILayout.BeginArea(new Rect(10f, 10f, 120f, 40f));
                {
                    GUILayout.BeginVertical(GUILayout.Width(120f), GUILayout.Height(20f));
                    {
                        GUILayout.Label("Property", MetaliveStyle.Label.defalut);
                        GUILayout.Space(2f);
                        property = (PropertyCategory)EditorGUILayout.EnumPopup(property);
                    }
                    GUILayout.EndVertical();
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();

            switch (property)
            {
                case PropertyCategory.Addressable:                    
                    AddressableViewer();
                    break;
                case PropertyCategory.Tag:

                    break;
                case PropertyCategory.Layer:

                    break;
            }
        }

        public void AddressableViewer()
        {

            GUILayout.BeginArea(new Rect(180f, 100f, 140f, 360f), MetaliveStyle.Area.defalut);
            {
                GUILayout.BeginArea(new Rect(10f, 10f, 120f, 340f));
                {
                    propertyScroll = GUILayout.BeginScrollView(propertyScroll);
                    {
                        var labels = AddressableAssetSettingsDefaultObject.Settings.GetLabels();
                        for (int i = 0; i < labels.Count; i++)
                        {
                            if (GUILayout.Button(labels[i]))
                            {

                            }
                        }
                    }
                    GUILayout.EndScrollView();
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(340f, 20f, 280f, 100f), MetaliveStyle.Area.defalut);
            {

            }
            GUILayout.EndArea();

        }
        
        #endregion

    }

}

#endif