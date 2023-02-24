/*
 * brunch : phantom
 * update : 2023-02-23
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Metalive
{
    public class MetaliveCategory : EditorWindow
    {
        public void Viewer()
        {

            GUILayout.BeginArea(new Rect(0, 0, 160f, 480f), MetaliveStyle.Area.defalut);
            {

                GUILayout.BeginArea(new Rect(0, 80f, 160f, 320f));
                {
                    ViewerSetting(MetaliveDashboard.Version);
                    ViewerSetting(MetaliveDashboard.Label);
                    ViewerSetting(MetaliveDashboard.Interactive);                    
                }
                GUILayout.EndArea();

                GUILayout.BeginArea(new Rect(0, 400f, 160f, 60f));
                {
                    ViewerSetting(MetaliveDashboard.Setting);
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();

        }

        private void ViewerSetting(MetaliveDashboard dashboard)
        {
            EditorGUI.BeginChangeCheck();

            GUILayout.BeginVertical(GUILayout.Width(180), GUILayout.Height(48));
            {
                if (MetaliveEditor.dashboard == dashboard)
                {
                    if(GUILayout.Button(dashboard.ToString(), MetaliveStyle.Button.select))
                    {
                        MetaliveEditor.dashboard = dashboard;
                    }
                }
                else
                {
                    if (GUILayout.Button(dashboard.ToString(), MetaliveStyle.Button.unSelect))
                    {
                        MetaliveEditor.dashboard = dashboard;
                    }
                }
            }
            GUILayout.EndVertical();

            if (EditorGUI.EndChangeCheck())
            {
                EditorPrefs.SetString("Dashboard", dashboard.ToString());
            }
        }
    }
}

#endif