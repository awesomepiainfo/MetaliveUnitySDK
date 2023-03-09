/*
 * brunch : phantom
 * update : 2023-02-24
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace MetaliveEditor
{
    public class MetaliveData : Editor
    {

        #region Variable

        public static MetaliveSettingData setting { get; set; }

        #endregion

        #region Method

        public static int Setting()
        {
            try
            {
                if (setting == null)
                {
                    var asset = "Setting.asset";
                    var rootPath = "Assets/Metalive/Scriptable";
                    var path = rootPath + "/" + asset;

                    setting = AssetDatabase.LoadAssetAtPath(path, typeof(MetaliveSettingData)) as MetaliveSettingData;
                    if (setting == null)
                    {
                        if (!Directory.Exists(rootPath))
                        {
                            Directory.CreateDirectory(rootPath);
                        }

                        setting = CreateInstance<MetaliveSettingData>();
                        AssetDatabase.CreateAsset(setting, path);
                        AssetDatabase.SaveAssets();

                        Debug.Log($"Create success account data (Path : {path}");
                    }
                }

                return 0;
            }
            catch
            {
                Debug.Log("Create account data error");
                return 4;
            }
        }

        #endregion
    }
}

#endif