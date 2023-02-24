using Metalive;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MetaliveSetting : EditorWindow
{
    public void Viewer()
    {
        GUILayout.BeginArea(new Rect(180f, 20f, 440f, 60f), MetaliveStyle.Area.defalut);
        {

        }
        GUILayout.EndArea();
    }
}
