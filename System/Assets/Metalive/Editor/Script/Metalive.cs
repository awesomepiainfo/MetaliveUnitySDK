/*
 * brunch : phantom
 * update : 2023-02-23
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Metalive
{
    public class Metalive
    {
        
    }

    [InitializeOnLoad]
    public class MetaliveEditor : Editor
    {
        static MetaliveEditor()
        {
            var dashboardCode = EditorPrefs.GetString("Dashboard");
            if (!string.IsNullOrEmpty(dashboardCode))
            {
                var enable = Enum.TryParse(dashboardCode, true, out MetaliveDashboard result);
                if (enable)
                {
                    dashboard = result;
                }
            }

        }
        
        #region Variable

        public static MetaliveDashboard dashboard { get; set; }

        #endregion



        #region Method

        [MenuItem("Metalive/Dashboard", priority = 0)]
        public static void Manager()
        {
            var setting = MetaliveData.Setting();
            if(!setting.Equals(0))
            {                
                return;
            }

            if (AddressableAssetSettingsDefaultObject.Settings == null)
            {
                AddressableAssetSettingsDefaultObject.Settings = AddressableAssetSettings.Create(AddressableAssetSettingsDefaultObject.kDefaultConfigFolder, AddressableAssetSettingsDefaultObject.kDefaultConfigAssetName, true, true);
            }

            if (MetaliveData.setting.project == null)
            {
                Profile();
            }
            else
            {   
                if(string.IsNullOrEmpty(MetaliveData.setting.project.name) || string.IsNullOrEmpty(MetaliveData.setting.project.company) || string.IsNullOrEmpty(MetaliveData.setting.project.bundleIndentifier))
                {
                    Profile();
                }
                else
                {
                    Dashboard();
                }                
            }
        }

        public static void Profile()
        {
            var window = EditorWindow.GetWindow<MetaliveProfileWindow>();
            var x = 280f;
            var y = 420f;

            window.position = new Rect(100, 100, x, y);
            window.titleContent = new GUIContent("[ Metalive ] Profile");
            window.minSize = window.maxSize = new Vector2(x, y);
            window.Show();
        }

        public static void Dashboard()
        {
            var window = EditorWindow.GetWindow<MetaliveEditorWindow>();
            var x = 640f;
            var y = 480f;

            window.position = new Rect(100, 100, x, y);
            window.titleContent = new GUIContent("[ Metalive ] Dashboard");
            window.minSize = window.maxSize = new Vector2(x, y);
            window.Show();
        }

        #endregion
    }

    public class MetaliveProfileWindow : EditorWindow
    {
        private string projectName;
        private string projectCompany;
        private string projectBundleIndentifier;

        private void Awake()
        {
            var setting = MetaliveData.Setting();
            if (!setting.Equals(0))
            {
                return;
            }

            if(MetaliveData.setting.project != null)
            {
                projectName = MetaliveData.setting.project.name;
                projectCompany = MetaliveData.setting.project.company;
                projectBundleIndentifier = MetaliveData.setting.project.bundleIndentifier;
            }
        }

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(0f, 0f, 280f, 420f));
            {
                GUILayout.BeginArea(new Rect(20f, 40f, 240f, 20f));
                {
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Name   ", MetaliveStyle.Label.defalut, GUILayout.Width(80f), GUILayout.Height(20f));
                        projectName = GUILayout.TextField(projectName, GUILayout.Width(156f), GUILayout.Height(20f));
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndArea();

                GUILayout.BeginArea(new Rect(20f, 68f, 240f, 20f));
                {
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Company   ", MetaliveStyle.Label.defalut, GUILayout.Width(80f), GUILayout.Height(20f));
                        projectCompany = GUILayout.TextField(projectCompany, GUILayout.Width(156f), GUILayout.Height(20f));
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndArea();

                GUILayout.BeginArea(new Rect(20f, 96f, 240f, 20f));
                {
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Indentifier   ", MetaliveStyle.Label.defalut, GUILayout.Width(80f), GUILayout.Height(20f));
                        projectBundleIndentifier = GUILayout.TextField(projectBundleIndentifier, GUILayout.Width(156f), GUILayout.Height(20f));
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndArea();

                GUILayout.BeginArea(new Rect(20f, 148f, 240f, 40f));
                {
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.FlexibleSpace();
                        if(GUILayout.Button("Setting", MetaliveStyle.Button.defalut ,GUILayout.Width(240f), GUILayout.Height(36f)))
                        {
                            Setting();
                        }
                        GUILayout.FlexibleSpace();
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();
        }

        private void Setting()
        {
            var code = MetaliveData.Setting();
            if (!code.Equals(0))
            {
                return;
            }

            if (string.IsNullOrEmpty(projectName))
            {
                Debug.Log("Please write the project name.");
                return;
            }

            if (string.IsNullOrEmpty(projectCompany))
            {
                Debug.Log("Please write the project company.");
                return;
            }

            if (MetaliveData.setting.project == null)
            {
                MetaliveData.setting.project = new MetaliveProject();
            }

            MetaliveData.setting.project.name = projectName;
            MetaliveData.setting.project.company = projectCompany;

            if (string.IsNullOrEmpty(projectBundleIndentifier))
            {
                MetaliveData.setting.project.bundleIndentifier = $"com.{projectCompany.ToLower()}.{projectName.ToLower()}";
            }
            else
            {
                MetaliveData.setting.project.bundleIndentifier = projectBundleIndentifier;
            }

            EditorUtility.SetDirty(MetaliveData.setting);


            MetaliveEditor.Manager();
            Close();
        }
    }

    public class MetaliveEditorWindow : EditorWindow
    {

        #region Variable

        private MetaliveCategory category;
        private MetaliveVersion version;
        private MetaliveSetting setting;

        #endregion



        #region LifeCycle

        private void OnGUI()
        {
            if (Event.current.keyCode == KeyCode.Escape)
            {
                Close();
            }

            Viewer();
            Setting();
        }

        private void Viewer()
        {
            Category();
            Dashboard();
        }

        private void Setting()
        {
            Style();
        }

        #endregion



        #region Category

        // ==================================================
        // Category
        // ==================================================
        private void Category()
        {
            if(category == null)
            {
                category = CreateInstance<MetaliveCategory>();
            }

            category.Viewer();
        }
        

        // ==================================================
        // Dashboard
        // ==================================================
        private void Dashboard()
        {
            switch(MetaliveEditor.dashboard)
            {
                case MetaliveDashboard.Version:
                    DashboardVersion();
                    break;
                case MetaliveDashboard.Label:

                    break;
                case MetaliveDashboard.Interactive:

                    break;
                case MetaliveDashboard.Setting:
                    DashboardSetting();
                    break;
            }
        }

        private void DashboardVersion()
        {
            if(version == null)
            {
                version = CreateInstance<MetaliveVersion>();
            }

            version.Viewer();
        }

        private void DashboardSetting()
        {
            if(setting == null)
            {
                setting = CreateInstance<MetaliveSetting>();
            }

            setting.Viewer();
        }

        #endregion



        #region Style

        // ==================================================
        // Style
        // ==================================================
        private void Style()
        {
            // Area
            MetaliveStyle.Area.defalut.normal = new GUIStyleState()
            {
                background = StyleColor(1, 1, MetaliveColor.eclipse)
            };

            // Button
            MetaliveStyle.Button.select.normal = new GUIStyleState()
            {
                textColor = Color.white,
                background = StyleColor(1, 1, MetaliveColor.eclipse)
            };

            MetaliveStyle.Button.unSelect.normal = new GUIStyleState()
            {
                textColor = Color.gray,
                background = StyleColor(1, 1, MetaliveColor.eclipse)
            };
        }

        public Texture2D StyleColor(int width, int height, Color color)
        {
            Color[] pixels = new Color[width * height];

            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = color;
            }

            Texture2D texture = new Texture2D(width, height);
            texture.SetPixels(pixels);
            texture.Apply();

            return texture;
        }

        #endregion
    }
}

#endif