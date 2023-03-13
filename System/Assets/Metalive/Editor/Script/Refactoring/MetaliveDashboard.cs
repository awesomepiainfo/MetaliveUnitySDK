/*
 * brunch : phantom
 * update : 2023-03-10
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using UnityEditor;
using UnityEngine;

namespace Metalive
{
    public class MetaliveDashboard : EditorWindow
    {

        #region Variable

        private DashboardCategory category = DashboardCategory.Basic;
        private MetaliveVersion version;
        private MetaliveInstall install;
        private MetaliveSetting setting;

        #endregion



        #region Lifecycle

        private void Awake()
        {
            if (Metalive.IsAddressable == false)
            {
                var redirect = Metalive.AddressableInit();
                if (redirect.Equals(1000) == false)
                {
                    Close();
                    return;
                }
            }
        }
        
        private void OnGUI()
        {
            EditorGUI.BeginChangeCheck();

            Category();
            Viewer();

            if (EditorGUI.EndChangeCheck())
            {
                
            }
        }

        #endregion



        #region Method

        // ==================================================
        // [ Category ]
        // ==================================================
        private void Category()
        {            
            // [ Style ]         
            GUIStyle area = new GUIStyle()
            {
                normal = new GUIStyleState()
                {
                    background = MetaliveStyle.Background(1, 1, MetaliveColor.eclipse)
                }
            };
            

            // [ Layout ]
            GUILayout.BeginArea(new Rect(0, 0, 180f, 480f), area);
            {

                GUILayout.BeginArea(new Rect(0, 60f, 180f, 320f));
                {
                    CategorySetting(DashboardCategory.Basic, DashboardType.Beta);
                    CategorySetting(DashboardCategory.Version, DashboardType.Beta);
                }
                GUILayout.EndArea();

                GUILayout.BeginArea(new Rect(0, 380f, 180f, 80f));
                {
                    CategorySetting(DashboardCategory.Install, DashboardType.Beta);
                    CategorySetting(DashboardCategory.Setting, DashboardType.Beta);
                }
                GUILayout.EndArea();

            }
            GUILayout.EndArea();
        }

        private void CategorySetting(DashboardCategory redirect, DashboardType type)
        {
            // ==================================================
            // [ Style ]
            // ==================================================
            GUIStyle normal = new GUIStyle(GUI.skin.button)
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft,
                padding = new RectOffset(40, 0, 0, 0),
                normal = new GUIStyleState()
                {
                    textColor = Color.gray,
                    background = MetaliveStyle.Background(1, 1, MetaliveColor.eclipse)
                }
            };

            GUIStyle click = new GUIStyle(GUI.skin.button)
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft,
                padding = new RectOffset(40, 0, 0, 0),
                normal = new GUIStyleState()
                {
                    textColor = Color.white,
                    background = MetaliveStyle.Background(1, 1, MetaliveColor.eclipse)
                }
            };

            // ==================================================
            // [ Layout ]
            // ==================================================
            GUILayout.BeginVertical(GUILayout.Width(180f), GUILayout.Height(40f));
            {
                var text = redirect.ToString();                
                if(type == DashboardType.Beta)
                {
                    text += "(Beta)";
                }                

                if(category.Equals(redirect))
                {
                    if(GUILayout.Button(text, click))
                    {
                        category = redirect;
                    }
                }
                else
                {
                    if(GUILayout.Button(text, normal))
                    {
                        category = redirect;
                    }
                }
            }
            GUILayout.EndVertical();
        }


        // ==================================================
        // [ Viewer ]
        // ==================================================
        private void Viewer()
        {
            switch(category)
            {
                case DashboardCategory.Basic:

                    break;
                case DashboardCategory.Version:
                    VersionViewer();
                    break;
                case DashboardCategory.Property:

                    break;
                case DashboardCategory.Interactive: 

                    break;
                case DashboardCategory.Install:
                    InstallViewer();
                    break;
                case DashboardCategory.Setting:
                    SettingViewer();
                    break;
            }
        }

        private void VersionViewer()
        {
            if(version == null)
            {
                version = CreateInstance<MetaliveVersion>();
            }
            version.Viewer();
        }

        private void InstallViewer()
        {
            if(install == null)
            {
                install = CreateInstance<MetaliveInstall>();
            }
            install.Viewer();
        }

        private void SettingViewer()
        {
            if(setting == null)
            {
                setting = CreateInstance<MetaliveSetting>();
            }
            setting.Viewer();
        }

        #endregion

    }
}

#endif