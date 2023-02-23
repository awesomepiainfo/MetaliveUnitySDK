using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Metalive
{
    public class MetaliveVersion : EditorWindow
    {

        private string profile;
        private string buildPath;
        private string loadPath;

        public void Viewer()
        {

            GUILayout.BeginArea(new Rect(200f, 20f, 160f, 400f), MetaliveStyle.Area.defalut);
            {

            }
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(380f, 20f, 400f, 100f), MetaliveStyle.Area.defalut);
            {
                GUILayout.BeginArea(new Rect(20f, 20f, 360f, 20f));
                {
                    GUILayout.BeginHorizontal();
                    {                        
                        GUILayout.Label("Profile   : ", MetaliveStyle.Label.defalut, GUILayout.Width(60f), GUILayout.Height(20f));                        
                        profile = GUILayout.TextField(profile, GUILayout.Width(296f), GUILayout.Height(20f));
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndArea();

                GUILayout.BeginArea(new Rect(232f, 48f, 164f, 32f));
                {
                    GUILayout.BeginHorizontal();
                    {                        
                        if(GUILayout.Button("Add", MetaliveStyle.Button.defalut, GUILayout.Width(72f), GUILayout.Height(28f)))
                        {

                        }

                        if (GUILayout.Button("Remove", MetaliveStyle.Button.defalut, GUILayout.Width(72f), GUILayout.Height(28f)))
                        {

                        }                        
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndArea();

            }
            GUILayout.EndArea();

            
        }
    }

}