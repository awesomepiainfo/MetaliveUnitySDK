/*
 * brunch : phantom
 * update : 2023-03-13
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.Networking;

namespace Metalive
{

    public class MetaliveVersion : Editor
    {

        #region Variable

        private string versionID;
        private string versionOverride;
        private bool versionAndroid;
        private bool versioniOS;
        
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

            GUIStyle button = new GUIStyle(GUI.skin.button)
            {
                fontSize = 10,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
            };

            GUIStyle label = new GUIStyle(GUI.skin.label)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft,
            };


            // [ Layout ]                                     
            GUILayout.BeginArea(new Rect(200f, 20f, 140f, 440f), area);
            {
                GUILayout.BeginArea(new Rect(10f, 20f, 120f, 320f));
                {
                    Version();
                }
                GUILayout.EndArea();

                EditorGUI.DrawRect(new Rect(10f, 368f, 120f, 1f), Color.white);

                GUILayout.BeginArea(new Rect(10f, 380f, 120f, 60f));
                {
                    if (GUILayout.Button("Add", button, GUILayout.Width(120f), GUILayout.Height(24f)))
                    {
                        Add();
                    }   
                    
                    if (GUILayout.Button("Remove", button, GUILayout.Width(120f), GUILayout.Height(24f)))
                    {
                        Remove();
                    }
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(360f, 20f, 340f, 40f), area);
            {
                GUILayout.BeginArea(new Rect(10f, 10f, 320f, 20f));
                {
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.FlexibleSpace();
                        if (GUILayout.Button("Save", button, GUILayout.Width(76f), GUILayout.Height(20f)))
                        {
                            Save();
                        }

                        if (GUILayout.Button("Refresh", button, GUILayout.Width(76f), GUILayout.Height(20f)))
                        {
                            Refresh();
                        }

                        if (GUILayout.Button("---", button, GUILayout.Width(76f), GUILayout.Height(20f)))
                        {

                        }

                        if (GUILayout.Button("---", button, GUILayout.Width(76f), GUILayout.Height(20f)))
                        {

                        }
                        GUILayout.FlexibleSpace();
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();


            GUILayout.BeginArea(new Rect(360f, 80f, 340f, 360f), area);
            {
                // Version
                GUILayout.BeginArea(new Rect(20f, 20f, 300f, 80f));
                {
                    GUILayout.BeginArea(new Rect(0f, 0f, 80f, 20f));
                    {
                        GUILayout.Label("Version", label, GUILayout.Width(80f), GUILayout.Height(20f));
                    }
                    GUILayout.EndArea();
                    GUILayout.BeginArea(new Rect(80f, 0f, 220f, 20f));
                    {
                        versionOverride = GUILayout.TextField(versionOverride, GUILayout.Width(220f), GUILayout.Height(20f));
                    }
                    GUILayout.EndArea();

                    GUILayout.BeginArea(new Rect(176f, 24f, 60f, 20f));
                    {
                        if (GUILayout.Button("Export", button, GUILayout.Width(60f), GUILayout.Height(20f)))
                        {
                            Export();
                        }
                    }
                    GUILayout.EndArea();
                    GUILayout.BeginArea(new Rect(240f, 24f, 60f, 20f));
                    {
                        if (GUILayout.Button("Clean", button, GUILayout.Width(60f), GUILayout.Height(20f)))
                        {
                            Clean();
                        }
                    }
                    GUILayout.EndArea();
                }
                GUILayout.EndArea();                               

                GUILayout.BeginArea(new Rect(20f, 80f, 240f, 60f));
                {
                    GUILayout.BeginArea(new Rect(0f, 20f, 60f, 20f));
                    {
                        GUILayout.Label("Connect", label, GUILayout.Width(60f), GUILayout.Height(20f));
                    }
                    GUILayout.EndArea();

                    GUILayout.BeginArea(new Rect(80f, 20f, 220f, 60f));
                    {
                        if (versionAndroid)
                        {
                            GUILayout.Label("Android : connect");
                        }
                        else
                        {
                            GUILayout.Label("Android : disconnect");
                        }

                        if (versioniOS)
                        {
                            GUILayout.Label("iOS : connect");
                        }
                        else
                        {
                            GUILayout.Label("iOS : disconnect");
                        }
                    }
                    GUILayout.EndArea();
                }
                GUILayout.EndArea();
            }
            GUILayout.EndArea();

        }


        // ==================================================
        // [ Setting ]
        // ==================================================
        private void Version()
        {
            GUIStyle normal = new GUIStyle(GUI.skin.button)
            {                
                alignment = TextAnchor.MiddleCenter,                
                normal = new GUIStyleState()
                {
                    textColor = Color.gray,                    
                }
            };

            GUIStyle click = new GUIStyle(GUI.skin.button)
            {                
                alignment = TextAnchor.MiddleCenter,                
                normal = new GUIStyleState()
                {
                    textColor = Color.white,                    
                }
            };

            var profile = AddressableAssetSettingsDefaultObject.Settings.profileSettings;
            var profileList = profile.GetAllProfileNames();
            for(int i = 1; i < profileList.Count; i++) 
            {
                GUILayout.BeginHorizontal();
                {
                    if(versionOverride == profileList[i])
                    {
                        if (GUILayout.Button(profileList[i], click))
                        {
                            Setting(profileList[i]);
                        }
                    }
                    else
                    {
                        if (GUILayout.Button(profileList[i], normal))
                        {
                            Setting(profileList[i]);
                        }
                    }                    
                }
                GUILayout.EndHorizontal();
            }            
        }

        private void Setting(string version)
        {
            var setting = AddressableAssetSettingsDefaultObject.Settings;
            var settingID = setting.profileSettings.GetProfileId(version);
            var settingPath = $"https://metalive-asset-resouse.s3.ap-northeast-2.amazonaws.com/admin/asset-resouse/WORLD/{Metalive.profile.projectBundleIndentifier}/{Metalive.profile.projectCode}/v{version}";
            var settingBuildPath = $"ServerData/{version}/[BuildTarget]";
            var settingLoadPath = settingPath + "/" + "[BuildTarget]";

            setting.activeProfileId = settingID;
            setting.OverridePlayerVersion = "metalive";
            setting.ContentStateBuildPath = $"Assets/AddressableAssetsData/{version}";
            setting.BuildRemoteCatalog = true;

            setting.profileSettings.SetValue(settingID, AddressableAssetSettings.kRemoteBuildPath, settingBuildPath);
            setting.profileSettings.SetValue(settingID, AddressableAssetSettings.kRemoteLoadPath, settingLoadPath);

            versionID = settingID;
            versionOverride = version;

            // Check Android
            var androidPath = $"{settingPath}/Android/catalog_metalive.json";
            EditorCoroutineUtility.StartCoroutine(Android(androidPath), this);

            // Check iOS
            var iOSPath = $"{settingPath}/iOS/catalog_metalive.json";
            EditorCoroutineUtility.StartCoroutine(iOS(iOSPath), this);
        }

        IEnumerator Android(string url)
        {
            using (var request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                if (request.result != UnityWebRequest.Result.Success)
                {
                    versionAndroid = false;
                    MetaliveDebug.Message("server", "false");
                }
                else
                {
                    versionAndroid = true;
                    MetaliveDebug.Message("server", "true");
                }
            }
        }

        IEnumerator iOS(string url)
        {
            using (var request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                if (request.result != UnityWebRequest.Result.Success)
                {
                    versioniOS = false;
                    MetaliveDebug.Message("server", "false");
                }
                else
                {
                    versioniOS = true;
                    MetaliveDebug.Message("server", "true");
                }
            }
        }

        private void Add()
        {
            var setting = AddressableAssetSettingsDefaultObject.Settings.profileSettings;
            if(string.IsNullOrEmpty(setting.GetProfileId("New")))
            {
                setting.AddProfile("New", "");
                Setting("New");

                MetaliveDebug.Message("1000", "Version add complete");
            }
            else
            {
                MetaliveDebug.Message("1001", "Version already exists.");                
            }
        }

        private void Remove()
        {
            var setting = AddressableAssetSettingsDefaultObject.Settings.profileSettings;
            if(string.IsNullOrEmpty(setting.GetProfileName(versionID)))
            {
                MetaliveDebug.Message("1001", "Version does not exists.");
            }
            else
            {
                setting.RemoveProfile(versionID);
                versionID = "";
                versionOverride = "";
                versionAndroid = false;
                versioniOS = false;

                MetaliveDebug.Message("1000", "Version remove complete");
            }
        }

        private void Save()
        {
            var setting = AddressableAssetSettingsDefaultObject.Settings.profileSettings;
            if(string.IsNullOrEmpty(setting.GetProfileName(versionID)))
            {
                MetaliveDebug.Message("1001", "Version does not exists.");
            }
            else
            {
                setting.RenameProfile(versionID, versionOverride);
                EditorUtility.SetDirty(AddressableAssetSettingsDefaultObject.Settings);

                Setting(versionOverride);
                MetaliveDebug.Message("1000", "Version save complete");
            }
        }

        private void Refresh()
        {
            var setting = AddressableAssetSettingsDefaultObject.Settings.profileSettings;
            if (string.IsNullOrEmpty(setting.GetProfileName(versionID)))
            {
                MetaliveDebug.Message("1001", "Version does not exists.");
            }
            else
            {
                versionOverride = setting.GetProfileName(versionID);
                Setting(versionOverride);
            }
        }

        private void Export()
        {
            AddressableAssetSettings.BuildPlayerContent();
        }

        private void Clean()
        {
            AddressableAssetSettings.CleanPlayerContent();
        }

        #endregion

    }

}

#endif