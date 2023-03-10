/*
 * brunch : phantom
 * update : 2023-03-10
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metalive
{

    public class MetaliveStyle
    {

        // ==================================================
        // [ Color ]
        // ==================================================
        public static Texture2D Background(int width, int height, Color color)
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

    }

}

#endif