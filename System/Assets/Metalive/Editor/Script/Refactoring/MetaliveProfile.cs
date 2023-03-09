/*
 * brunch : phantom
 * update : 2023-03-09
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Metalive
{

    public class MetaliveProfile : EditorWindow
    {
        #region Lifecycle

        private void Awake()
        {
            if (MetaliveSetting.IsProfile == false)
            {
                var redirect = MetaliveSetting.ProfileInit();
                if (redirect.Equals(1000) == false)
                {
                    Close();
                    return;
                }
            }
        }

        private void OnGUI()
        {
            // Project bundle indentifier
            GUILayout.BeginArea(new Rect(0f, 40f, 280f, 20f));
            {
                GUILayout.BeginArea(new Rect(20f, 0f, 80f, 20f));
                {
                    GUILayout.Label("Indentifier * ", MetaliveStyle.Label.defalut, GUILayout.Width(80f), GUILayout.Height(20f));
                }
                GUILayout.EndArea();
                GUILayout.BeginArea(new Rect(100f, 0f, 160f, 20f));
                {
                    MetaliveSetting.profile.projectBundleIndentifier = GUILayout.TextField(MetaliveSetting.profile.projectBundleIndentifier, GUILayout.Width(160f), GUILayout.Height(20f));
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();

            // Project code
            GUILayout.BeginArea(new Rect(0f, 68f, 280f, 20f));
            {
                GUILayout.BeginArea(new Rect(20f, 0f, 80f, 20f));
                {
                    GUILayout.Label("Code * ", MetaliveStyle.Label.defalut, GUILayout.Width(80f), GUILayout.Height(20f));
                }
                GUILayout.EndArea();
                GUILayout.BeginArea(new Rect(100f, 0f, 160f, 20f));
                {
                    MetaliveSetting.profile.projectCode = GUILayout.TextField(MetaliveSetting.profile.projectCode, GUILayout.Width(160f), GUILayout.Height(20f));                                        
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();

            // Project name
            GUILayout.BeginArea(new Rect(0f, 96f, 280f, 20f));
            {
                GUILayout.BeginArea(new Rect(20f, 0f, 80f, 20f));
                {
                    GUILayout.Label("Name", MetaliveStyle.Label.defalut, GUILayout.Width(80f), GUILayout.Height(20f));
                }
                GUILayout.EndArea();
                GUILayout.BeginArea(new Rect(100f, 0f, 160f, 20f));
                {
                    MetaliveSetting.profile.projectName = GUILayout.TextField(MetaliveSetting.profile.projectName, GUILayout.Width(160f), GUILayout.Height(20f));
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();

            // Project company
            GUILayout.BeginArea(new Rect(0f, 124f, 280f, 20f));
            {
                GUILayout.BeginArea(new Rect(20f, 0f, 80f, 20f));
                {
                    GUILayout.Label("Company", MetaliveStyle.Label.defalut, GUILayout.Width(80f), GUILayout.Height(20f));
                }
                GUILayout.EndArea();
                GUILayout.BeginArea(new Rect(100f, 0f, 160f, 20f));
                {
                    MetaliveSetting.profile.projectCompany = GUILayout.TextField(MetaliveSetting.profile.projectCompany, GUILayout.Width(160f), GUILayout.Height(20f));
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(20f, 188f, 240f, 32f));
            {
                if(GUILayout.Button("Setting", MetaliveStyle.Button.defalut, GUILayout.Width(240f), GUILayout.Height(32f)))
                {
                    Setting();
                }
            }
            GUILayout.EndArea();
        }

        #endregion



        #region Method

        public void Setting()
        {
            if(string.IsNullOrEmpty(MetaliveSetting.profile.projectBundleIndentifier) == true || string.IsNullOrEmpty(MetaliveSetting.profile.projectCode) == true)
            {
                MetaliveDebug.Message("1001", "Profile setting fail");
                return;
            }
            else
            {
                EditorUtility.SetDirty(MetaliveSetting.profile);
                Close();
                
                MetaliveEditor.Manager();

                MetaliveDebug.Message("1000", "Profile setting success");
                return;
            }            
        }

        #endregion
    }

}

#endif
