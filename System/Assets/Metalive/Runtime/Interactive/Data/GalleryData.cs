using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GalleryWriter
{
    public string name;    
    public string type;
    public string description;
    public string site;    
}

[CreateAssetMenu(fileName = "GalleryData", menuName = "Interactive/GalleryData", order = int.MaxValue)]
public class GalleryData : ScriptableObject
{
    [Header("[ Information ]")]
    [Tooltip("piece of work name")]
    public string title = "";
    [Tooltip("piece of work category")]
    public string category = "";
    [Tooltip("piece of work website")]
    public string deeplink = "";
    [Tooltip("piece of work related links")]
    public string outlink = "";

    [Tooltip("gallery piece of work related writer information - writer name, type(writer, picture, originel), description, related link")]
    public List<GalleryWriter> writers;

    [Space(10)]
    [Header("[ Resources ]")]
    // Image
    [Tooltip("load piece of work load location")]
    public InteractiveLocation location = InteractiveLocation.None;
    [Tooltip("labeling according to type [local = Application.persistentDataPath path]  [clip = addressable location ] or [url = user https:// location]")]
    public string label = "";

    // Image description
    [TextArea(3, 10)]
    [Tooltip("piece of work related description")]
    public string content = "";    
}


