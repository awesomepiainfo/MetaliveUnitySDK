/*
 * brunch : phantom
 * update : 2023-03-13
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Metalive
{    
    public class MetaliveInstall : Editor
    {

        #region Variable
        
        private string tagVersion;
        private string tagRelease;
        private bool tagInstall;
        private bool tagUpdate;

        #endregion


        #region Lifecycle

        private void Awake()
        {
            TagCheck();
        }

        #endregion



        #region Method

        // ==================================================
        // [ Viewer ]
        // ==================================================
        public void Viewer()
        {
            // [ Style ]
            GUIStyle area = new GUIStyle()
            {
                normal = new GUIStyleState()
                {
                    background = MetaliveStyle.Background(1, 1, MetaliveColor.eclipse)
                }
            };

            GUIStyle label = new GUIStyle(GUI.skin.label)
            {
                fontSize = 16,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft,
            };

            GUIStyle subLabel = new GUIStyle(GUI.skin.label)
            {
                fontSize = 10,                
                alignment = TextAnchor.MiddleLeft,
            };

            // [ Layout ] 
            GUILayout.BeginArea(new Rect(200f, 20f, 320f, 100f), area);
            {
                GUILayout.BeginArea(new Rect(20f, 28f, 280f, 20f));
                {
                    var text = $"Tag (ver. {MetaliveTag.version})";
                    GUILayout.Label(text, label, GUILayout.Width(280f), GUILayout.Height(20f));
                }
                GUILayout.EndArea();

                GUILayout.BeginArea(new Rect(20f, 48f, 280f, 20f));
                {
                    var text = MetaliveTag.release;
                    GUILayout.Label(text, subLabel, GUILayout.Width(280f), GUILayout.Height(20f));                    
                }
                GUILayout.EndArea();

                GUILayout.BeginArea(new Rect(176f, 60f, 60f, 20f));
                {
                    if(tagUpdate)
                    {
                        if (GUILayout.Button("Update", GUILayout.Width(60f), GUILayout.Height(20f)))
                        {
                            TagAdd();
                        }
                    }
                }
                GUILayout.EndArea();

                GUILayout.BeginArea(new Rect(240f, 60f, 60f, 20f));
                {
                    if(tagInstall)
                    {
                        if(GUILayout.Button("Remove", GUILayout.Width(60f), GUILayout.Height(20f)))
                        {
                            TagRemove();
                        }
                    }
                    else
                    {
                        if (GUILayout.Button("Install", GUILayout.Width(60f), GUILayout.Height(20f)))
                        {
                            TagAdd();
                        }
                    }
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();

            //GUILayout.BeginArea(new Rect(200f, 140f, 320f, 100f), area);
            //{

            //}
            //GUILayout.EndArea();

            //GUILayout.BeginArea(new Rect(200f, 260f, 320f, 100f), area);
            //{

            //}
            //GUILayout.EndArea();
        }

        #endregion



        #region Method

        private void TagCheck()
        {
            tagInstall = EditorPrefs.GetBool("TagInstall");
            if (tagInstall) 
            {
                tagVersion = EditorPrefs.GetString("TagVersion");                
                if (tagVersion != MetaliveTag.version)
                {
                    tagUpdate = true;
                    return;
                }

                // Update check                
                foreach (var tag in MetaliveTag.tag)
                {
                    if (tag.Length == 0)
                        continue;

                    if (!InternalEditorUtility.tags.Contains(tag))
                    {
                        tagUpdate = true;
                        return;
                    }
                }

                tagUpdate = false;
            }
            else
            {
                tagUpdate = false;
            }            
        }

        private void TagAdd()
        {
            foreach (var tag in MetaliveTag.tag)
            {
                if (tag.Length == 0)
                    continue;

                if (!InternalEditorUtility.tags.Contains(tag))
                {
                    InternalEditorUtility.AddTag(tag);
                }
            }

            EditorPrefs.SetBool("TagInstall", true);            
            EditorPrefs.SetString("TagVersion", MetaliveTag.version);            

            tagVersion = MetaliveTag.version;
            TagCheck();
        }

        private void TagRemove()
        {
            foreach (var tag in MetaliveTag.tag)
            {
                if (tag.Length == 0)
                    continue;

                if (InternalEditorUtility.tags.Contains(tag))
                {
                    InternalEditorUtility.RemoveTag(tag);
                }
            }

            EditorPrefs.SetBool("TagInstall", false);
            EditorPrefs.SetString("TagVersion", "");            

            tagVersion = "";
            TagCheck();
        }

        #endregion
    }
}

#endif