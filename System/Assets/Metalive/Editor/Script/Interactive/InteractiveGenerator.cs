/*
 * Day : 2023-02-03
 * Writer : phantom(chho1365@gmail.com)
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Runtime.CompilerServices;

namespace Metalive.Interactive
{
    /*
     * Dev 
     * [1] -> Prefab 생성 및 파일 생성 및 스크립트 기입
     * [2] -> Interactive에 버튼클릭시 data로 이동
     */

    public class InteractiveGenerator : Editor
    {          
        private static string previousMenu = "";
                
        [MenuItem("GameObject/Metalive/Interactive", priority = 1001)]
        public static void CreateInteractiveAnimation()
        {                        
            if (IsDuplicatedMenu()) return;

            InstantiateInteractive("Interactive.prefab");                               
        }

        private static void InstantiateInteractive(string prefabName)
        {                       
            var rootPath = InteractivePath();
            var path = rootPath + "/" + prefabName;            
            var prefab = AssetDatabase.LoadAssetAtPath(path, typeof(GameObject)) as GameObject;

            // SelectionMode.TopLevel => 최상위 부모
            // SelectionMode.Unfiltered => 선택한 것만
            var selections = Selection.GetTransforms(SelectionMode.Unfiltered);
            if(selections.Length > 0)
            {
                for (int i = 0; i < selections.Length; i++)
                {
                    GameObject obj = Instantiate(prefab, selections[i]);
                    obj.name = "Interactive";
                    Selection.activeGameObject = obj;
                }
            }
            else
            {
                var searchParent = "InteractiveCollection";
                GameObject parent = GameObject.Find(searchParent);
                if(parent == null)
                {
                    parent = new GameObject(searchParent);
                }

                GameObject obj = Instantiate(prefab, parent.transform);
                obj.name = "Interactive";
                Selection.activeGameObject = obj;                
            }                 
        }
        
        private static bool IsDuplicatedMenu([CallerMemberName] string memberName = "")
        {
            string menu = memberName + DateTime.Now.ToString();
            
            if (previousMenu.Equals(menu))
            {
                return true;
            }
            else
            {
                previousMenu = menu;
                return false;
            }
        }

        private static string InteractivePath([CallerFilePath] string fileName = null)
        {
            if (fileName.Contains("com.metalive.sdk"))
            {
                return "Packages/com.metalive.sdk/Runtime/Src/Interactive/Prefab";
            }
            else
            {
                return "Assets/Metalive/Runtime/Src/Interactive/Prefab";
            }            
        }
    }
}

#endif