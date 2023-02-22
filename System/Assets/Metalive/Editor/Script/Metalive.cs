/*
 * brunch : phantom
 * update : 2023-02-23
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Metalive
{
    public class Metalive
    {

    }

    public class MetaliveEditor : Editor
    {

        #region Variable

        public static MetaliveDashboard dashboard { get; set; }

        #endregion



        #region Method

        [MenuItem("Metalive/Dashboard", priority = 0)]
        public static void Dashboard()
        {
            var window = EditorWindow.GetWindow<MetaliveEditorWindow>();
            var x = 800f;
            var y = 600f;

            window.position = new Rect(100, 100, x, y);
            window.titleContent = new GUIContent("[ Metalive ] Dashboard");
            window.minSize = window.maxSize = new Vector2(x, y);
            window.Show();
        }

        #endregion
    }

    public class MetaliveEditorWindow : EditorWindow
    {

        #region Variable

        private MetaliveCategory category;

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