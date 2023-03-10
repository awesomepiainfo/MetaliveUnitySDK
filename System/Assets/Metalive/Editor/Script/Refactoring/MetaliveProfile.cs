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
            if (Metalive.IsProfile == false)
            {
                var redirect = Metalive.ProfileInit();
                if (redirect.Equals(1000) == false)
                {
                    Close();
                    return;
                }
            }
        }

        private void OnGUI()
        {

            // ==================================================
            // [ Style ]
            // ==================================================
            GUIStyle label = new GUIStyle(GUI.skin.label)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft
            };

            GUIStyle button = new GUIStyle(GUI.skin.button)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
            };


            // ==================================================
            // [ Layout ]
            // ==================================================

            // Project bundle indentifier
            GUILayout.BeginArea(new Rect(0f, 40f, 280f, 20f));
            {
                GUILayout.BeginArea(new Rect(20f, 0f, 80f, 20f));
                {
                    GUILayout.Label("Indentifier * ", label, GUILayout.Width(80f), GUILayout.Height(20f));
                }
                GUILayout.EndArea();
                GUILayout.BeginArea(new Rect(100f, 0f, 160f, 20f));
                {
                    Metalive.profile.projectBundleIndentifier = GUILayout.TextField(Metalive.profile.projectBundleIndentifier, GUILayout.Width(160f), GUILayout.Height(20f));
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();

            // Project code
            GUILayout.BeginArea(new Rect(0f, 68f, 280f, 20f));
            {
                GUILayout.BeginArea(new Rect(20f, 0f, 80f, 20f));
                {
                    GUILayout.Label("Code * ", label, GUILayout.Width(80f), GUILayout.Height(20f));
                }
                GUILayout.EndArea();
                GUILayout.BeginArea(new Rect(100f, 0f, 160f, 20f));
                {
                    Metalive.profile.projectCode = GUILayout.TextField(Metalive.profile.projectCode, GUILayout.Width(160f), GUILayout.Height(20f));                                        
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();

            // Project name
            GUILayout.BeginArea(new Rect(0f, 96f, 280f, 20f));
            {
                GUILayout.BeginArea(new Rect(20f, 0f, 80f, 20f));
                {
                    GUILayout.Label("Name", label, GUILayout.Width(80f), GUILayout.Height(20f));
                }
                GUILayout.EndArea();
                GUILayout.BeginArea(new Rect(100f, 0f, 160f, 20f));
                {
                    Metalive.profile.projectName = GUILayout.TextField(Metalive.profile.projectName, GUILayout.Width(160f), GUILayout.Height(20f));
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();


            // Project company
            GUILayout.BeginArea(new Rect(0f, 124f, 280f, 20f));
            {
                GUILayout.BeginArea(new Rect(20f, 0f, 80f, 20f));
                {
                    GUILayout.Label("Company", label, GUILayout.Width(80f), GUILayout.Height(20f));
                }
                GUILayout.EndArea();
                GUILayout.BeginArea(new Rect(100f, 0f, 160f, 20f));
                {
                    Metalive.profile.projectCompany = GUILayout.TextField(Metalive.profile.projectCompany, GUILayout.Width(160f), GUILayout.Height(20f));
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(20f, 188f, 240f, 32f));
            {
                if(GUILayout.Button("Setting", button, GUILayout.Width(240f), GUILayout.Height(32f)))
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
            if(string.IsNullOrEmpty(Metalive.profile.projectBundleIndentifier) == true || string.IsNullOrEmpty(Metalive.profile.projectCode) == true)
            {
                MetaliveDebug.Message("1001", "Profile setting fail");
                return;
            }
            else
            {
                EditorUtility.SetDirty(Metalive.profile);
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
