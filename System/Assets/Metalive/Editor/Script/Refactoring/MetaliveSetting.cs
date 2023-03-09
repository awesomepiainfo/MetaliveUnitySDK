/*
 * brunch : phantom
 * update : 2023-03-09
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

namespace Metalive
{

    [InitializeOnLoad]
    public class MetaliveSetting : Editor
    {
        static MetaliveSetting()
        {
            AddressableInit();
            ProfileInit();
        }

        // ==================================================
        // Addressable
        // ==================================================

        public static bool IsAddressable
        {
            get
            {
                if(AddressableAssetSettingsDefaultObject.Settings)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static int AddressableInit()
        {
            try
            {
                if (AddressableAssetSettingsDefaultObject.Settings == null)
                {
                    AddressableAssetSettingsDefaultObject.Settings = AddressableAssetSettings.Create(AddressableAssetSettingsDefaultObject.kDefaultConfigFolder, AddressableAssetSettingsDefaultObject.kDefaultConfigAssetName, true, true);
                }

                if(AddressableAssetSettingsDefaultObject.Settings == null)
                {
                    // fail
                    MetaliveDebug.Message("1004", "Addressable init fail");
                    return 1001;
                }
                else
                {
                    // success
                    MetaliveDebug.Message("1000", "Addressable init success");                    
                    return 1000;
                }
            }
            catch
            {
                // error
                MetaliveDebug.Message("1004", "Addressable init error");
                return 1004;
            }
        }

        // ==================================================
        // Profile
        // ==================================================

        public static bool IsAccount
        {
            get
            {
                if(profile)
                {
                    if(string.IsNullOrEmpty(profile.projectBundleIndentifier) == false && string.IsNullOrEmpty(profile.projectCode) == false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsProfile
        {
            get
            {
                if(profile)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static MetaliveProfileData profile;

        public static int ProfileInit()
        {
            try
            {
                if (profile == null)
                {
                    var asset = "Profile.asset";
                    var rootPath = "Assets/Metalive/Setting";
                    var path = rootPath + "/" + asset;

                    profile = AssetDatabase.LoadAssetAtPath(path, typeof(MetaliveProfileData)) as MetaliveProfileData;
                    if (profile == null)
                    {
                        if (!Directory.Exists(rootPath))
                        {
                            Directory.CreateDirectory(rootPath);
                        }

                        profile = CreateInstance<MetaliveProfileData>();
                        AssetDatabase.CreateAsset(profile, path);
                        AssetDatabase.SaveAssets();
                    }
                }                

                if(profile == null)
                {
                    // fail
                    MetaliveDebug.Message("1001", "Profile init fail");
                    return 1001;
                }
                else
                {
                    // success
                    MetaliveDebug.Message("1000", "Profile init success");
                    return 1000;
                }                
            }
            catch
            {
                // error
                MetaliveDebug.Message("1004", "Profile init success");
                return 1004;
            }

        }

    }
}

#endif