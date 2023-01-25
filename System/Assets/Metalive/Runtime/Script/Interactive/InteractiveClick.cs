/*
 * Day : 2023-02-16
 * Writer : phantom(chho1365@gmail.com)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
using System.Runtime.CompilerServices;
#endif

namespace Metalive.Interactive
{    
    public class InteractiveClick : MonoBehaviour
    {
        [Tooltip("Material auto change")]
        public bool auto = false;
        public InteractiveMode mode = InteractiveMode.None;
        public string label = "";

#if UNITY_EDITOR                
        private void Reset()
        {
            auto = EditorPrefs.GetBool(gameObject.GetInstanceID().ToString(), false);
        }

        private void OnValidate()
        {            
            InteractiveSetting();
        }

        private void InteractiveSetting()
        {
            EditorPrefs.SetBool(gameObject.GetInstanceID().ToString(), auto);

            if (mode == InteractiveMode.None)
            {
                return;
            }

            var count = 0;
            foreach (var script in FindObjectsOfType<InteractiveClick>())
            {
                if (script.mode == mode)
                {
                    count++;
                }
            }

            gameObject.name = $"{mode}-{count}";            
            if(auto == true)
            {
                Renderer renderer = gameObject.GetComponent<Renderer>();
                if(renderer)
                {
                    var rootPath = InteractivePath();
                    var materialName = "";
                    switch(mode)
                    {                        
                        case InteractiveMode.Animation:
                            materialName = "interactive_material_animation.mat";
                            break;
                        case InteractiveMode.Gallery:
                            materialName = "interactive_material_gallery.mat";
                            break;
                        case InteractiveMode.Telescope:
                            materialName = "interactive_material_telescope.mat";
                            break;                        
                        case InteractiveMode.Npc:
                            materialName = "interactive_material_npc.mat";
                            break;
                        case InteractiveMode.Riding:
                            materialName = "interactive_material_riding.mat";
                            break;
                        default:
                            materialName = "interactive_material_basic.mat";
                            break;
                    }

                    var path = rootPath + "/" + materialName;                    
                    var material = AssetDatabase.LoadAssetAtPath(path, typeof(Material)) as Material;
                    
                    if (material != null)
                    {                        
                        renderer.material = material;
                    }
                }
            }
        }

        private static string InteractivePath([CallerFilePath] string fileName = null)
        {
            if (fileName.Contains("com.metalive.sdk"))
            {
                return "Packages/com.metalive.sdk/Runtime/Src/Interactive/Material";
            }
            else
            {
                return "Assets/Metalive/Runtime/Src/Interactive/Material";
            }
        }
#endif
    }
}