/*
 * brunch : phantom
 * update : 2023-02-27
 * email : chho1365@gmail.com
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine.Networking;
using Unity.EditorCoroutines.Editor;
using System.Linq;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;

#if UNITY_EDITOR

namespace Metalive
{
    public class MetaliveVersion : EditorWindow
    {
        #region Variable

        // Value
        private string profileID;
        private string profile;        

        // Check
        private bool profileAndroid;
        private bool profileiOS;

        #endregion



        #region Method

        public void Viewer()
        {

            GUILayout.BeginArea(new Rect(180f, 20f, 140f, 440f), MetaliveStyle.Area.defalut);
            {
                // Scroll
                GUILayout.BeginArea(new Rect(10f, 20f, 120f, 340f));
                {
                    ViewerCategory();
                }
                GUILayout.EndArea();

                // ---
                EditorGUI.DrawRect(new Rect(10f, 368f, 120f, 1f), Color.white);

                // Button
                GUILayout.BeginArea(new Rect(10f, 380f, 120f, 60f));
                {
                    if (GUILayout.Button("Add", MetaliveStyle.Button.defalut, GUILayout.Width(120f), GUILayout.Height(24f)))
                    {
                        Add();
                    }

                    if (GUILayout.Button("Remove", MetaliveStyle.Button.defalut, GUILayout.Width(120f), GUILayout.Height(24f)))
                    {
                        Remove();
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
                        profile = GUILayout.TextField(profile, GUILayout.Width(156f), GUILayout.Height(20f));
                    }
                    GUILayout.EndHorizontal();                    
                }
                GUILayout.EndArea();

                GUILayout.BeginArea(new Rect(104f, 44f, 156f, 40f));
                {
                    if (GUILayout.Button("Export"))
                    {                        
                        AddressableAssetSettings.BuildPlayerContent();                        
                    }

                    if (GUILayout.Button("Clean"))
                    {
                        AddressableAssetSettings.CleanPlayerContent();                        
                    }
                }
                GUILayout.EndArea();

                GUILayout.BeginArea(new Rect(20f, 120f, 240f, 60f));
                {
                    GUILayout.Label("Connect", MetaliveStyle.Label.defalut, GUILayout.Width(80f), GUILayout.Height(20f));

                    GUILayout.BeginArea(new Rect(84f, 4f, 160f, 60f));
                    {
                        if(profileAndroid)
                        {
                            GUILayout.Label("Android : success");
                        }
                        else
                        {
                            GUILayout.Label("Android : fail");
                        }

                        if(profileiOS)
                        {
                            GUILayout.Label("iOS : success");
                        }
                        else
                        {
                            GUILayout.Label("iOS : fail");
                        }                                                
                    }
                    GUILayout.EndArea();                                   
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
                            Save();
                        }

                        if (GUILayout.Button("Refresh", MetaliveStyle.Button.defalut, GUILayout.Width(80f), GUILayout.Height(28f)))
                        {
                            Refresh();
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

        private void ViewerCategory()
        {            
            var profile = AddressableAssetSettingsDefaultObject.Settings.profileSettings;            
            var profileCategory = profile.GetAllProfileNames();
            for(int i = 1; i < profileCategory.Count; i++)
            {
                GUILayout.BeginHorizontal();
                {
                    if (GUILayout.Button(profileCategory[i]))
                    {
                        var code = MetaliveData.Setting();
                        if(!code.Equals(0))
                        {
                            return;
                        }
                        else
                        {       
                            if(string.IsNullOrEmpty(MetaliveData.setting.project.name))
                            {
                                Debug.LogError("There is no project name. Please fill out your project profile\n[Setting] - [Profile");
                            }

                            if(string.IsNullOrEmpty(MetaliveData.setting.project.company))
                            {
                                Debug.LogError("There is no project company. Please fill out your project profile\n[Setting] - [Profile");
                            }

                            if(string.IsNullOrEmpty(MetaliveData.setting.project.bundleIndentifier))
                            {
                                Debug.LogError("There is no bundleIndentifier. Please fill out your project profile\n[Setting] - [Profile");
                            }
                        }                                                                        

                        Init(profileCategory[i]);
                        Debug.Log("Profile select complete");
                    }
                }
                GUILayout.EndHorizontal();
            }
        }

        private void Init(string profileName)
        {
            var profileSetting = AddressableAssetSettingsDefaultObject.Settings;            
            var profileSettingID = profileSetting.profileSettings.GetProfileId(profileName);
            var profilePath = $"https://metalive-asset-resouse.s3.ap-northeast-2.amazonaws.com/admin/asset-resouse/WORLD/{MetaliveData.setting.project.bundleIndentifier}/v{profileName}";
            var profileBuildPath = $"ServerData/{profileName}/[BuildTarget]";
            var profileLoadPath = profilePath + "/" + "[BuildTarget]";

            profileSetting.activeProfileId = profileSettingID;
            profileSetting.OverridePlayerVersion = "metalive";
            profileSetting.ContentStateBuildPath = $"Assets/AddressableAssetsData/{profileName}";
            profileSetting.BuildRemoteCatalog = true;
                        
            profileSetting.profileSettings.SetValue(profileSettingID, AddressableAssetSettings.kRemoteBuildPath, profileBuildPath);
            profileSetting.profileSettings.SetValue(profileSettingID, AddressableAssetSettings.kRemoteLoadPath, profileLoadPath);

            profileID = profileSettingID;
            profile = profileName;

            // Check Android
            var profileAndroidPath = $"{profilePath}/Android/catalog_metalive.json";            
            EditorCoroutineUtility.StartCoroutine(Android(profileAndroidPath), this);

            // Check iOS
            var profileiOSPath = $"{profilePath}/iOS/catalog_metalive.json";
            EditorCoroutineUtility.StartCoroutine(iOS(profileiOSPath), this);
        }

        IEnumerator Android(string url)
        {
            using (var request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                if(request.result != UnityWebRequest.Result.Success)
                {
                    profileAndroid = false;
                    Debug.Log("Server : false");
                }
                else
                {
                    profileAndroid = true;
                    Debug.Log("Server : true");
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
                    profileiOS = false;
                    Debug.Log("Server : false");
                }
                else
                {
                    profileiOS = true;
                    Debug.Log("Server : true");
                }
            }
        }

        private void Add()
        {
            var profileSetting = AddressableAssetSettingsDefaultObject.Settings.profileSettings;            
            if(string.IsNullOrEmpty(profileSetting.GetProfileId("New")))
            {
                profileSetting.AddProfile("New", "");                
                Init("New");

                Debug.Log("Profile add complete");
            }
            else
            {
                Debug.Log("Profile does not exist.");
            }
        }

        private void Remove()
        {
            var profileSetting = AddressableAssetSettingsDefaultObject.Settings.profileSettings;
            if(string.IsNullOrEmpty(profileSetting.GetProfileName(profileID)))
            {
                Debug.Log("Profile does not exist.");
            }
            else
            {
                profileSetting.RemoveProfile(profileID);
                profileID = "";
                profile = "";

                Debug.Log("Profile remove complete");
            }
        }

        private void Save()
        {
            var profileSetting = AddressableAssetSettingsDefaultObject.Settings.profileSettings;            
            if (string.IsNullOrEmpty(profileSetting.GetProfileName(profileID)))
            {
                Debug.Log("Profile does not exist.");
            }
            else
            {
                profileSetting.RenameProfile(profileID, profile);                
                EditorUtility.SetDirty(AddressableAssetSettingsDefaultObject.Settings);

                Init(profile);
                Debug.Log("Profile save complete");                
            }
        }

        private void Refresh()
        {
            var profileSetting = AddressableAssetSettingsDefaultObject.Settings.profileSettings;            
            if (string.IsNullOrEmpty(profileSetting.GetProfileName(profileID)))
            {
                Debug.Log("Profile does not exist.");
            }
            else
            {                
                profile = profileSetting.GetProfileName(profileID);
                Init(profile);
            }
        }
        
        #endregion
    }
}

#endif