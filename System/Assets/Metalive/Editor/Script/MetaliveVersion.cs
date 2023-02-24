using Codice.CM.Client.Differences;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Metalive
{
    public class MetaliveVersion : EditorWindow
    {

        private string version;
        private string buildPath;
        private string loadPath;

        public void Viewer()
        {

            GUILayout.BeginArea(new Rect(180f, 20f, 140f, 440f), MetaliveStyle.Area.defalut);
            {
                // Scroll


                // ---
                EditorGUI.DrawRect(new Rect(10f, 368f, 120f, 1f), Color.white);

                // Button
                GUILayout.BeginArea(new Rect(10f, 380f, 120f, 60f));
                {
                    if (GUILayout.Button("Add", MetaliveStyle.Button.defalut, GUILayout.Width(120f), GUILayout.Height(24f)))
                    {

                    }

                    if (GUILayout.Button("Remove", MetaliveStyle.Button.defalut, GUILayout.Width(120f), GUILayout.Height(24f)))
                    {

                    }
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();
         
            GUILayout.BeginArea(new Rect(340f, 20f, 280f, 360f), MetaliveStyle.Area.defalut);
            {
                GUILayout.BeginArea(new Rect(20f, 20f, 240f, 20f));
                {
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Version   ", MetaliveStyle.Label.defalut, GUILayout.Width(80f), GUILayout.Height(20f));
                        version = GUILayout.TextField(version, GUILayout.Width(156f), GUILayout.Height(20f));
                    }
                    GUILayout.EndHorizontal();                    
                }
                GUILayout.EndArea();                
            }
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(340f, 400f, 280f, 60f), MetaliveStyle.Area.defalut);
            {
                GUILayout.BeginArea(new Rect(16f, 16f, 248f, 28f));
                {
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.FlexibleSpace();
                        if (GUILayout.Button("Save", MetaliveStyle.Button.defalut, GUILayout.Width(80f), GUILayout.Height(28f)))
                        {
                            
                        }

                        if (GUILayout.Button("---", MetaliveStyle.Button.defalut, GUILayout.Width(80f), GUILayout.Height(28f)))
                        {
                            
                        }

                        if (GUILayout.Button("---", MetaliveStyle.Button.defalut, GUILayout.Width(80f), GUILayout.Height(28f)))
                        {
                            
                        }
                        GUILayout.FlexibleSpace();
                    }
                    GUILayout.EndHorizontal();                    
                }
                GUILayout.EndArea();                
            }
            GUILayout.EndArea();
        }
    }

}