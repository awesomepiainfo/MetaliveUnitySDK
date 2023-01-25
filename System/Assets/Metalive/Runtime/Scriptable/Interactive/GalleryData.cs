/*
 * Day : 2023-01-26
 * Writer : phantom(chho1365@gmail.com)
 */

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Metalive.Interactive
{

    [Serializable]
    public class GalleryWriter
    {
        public string name;
        public string type;
        public string description;
        public string site;
    }

    [CreateAssetMenu(fileName = "GalleryData", menuName = "Metalive/Interactive/GalleryData", order = int.MaxValue)]
    public class GalleryData : ScriptableObject
    {
        // ==================================================
        [Header("[ Use ]")]
        [Tooltip("[true] = use / [false] = ready ")]
        public bool isUse = true;
        // ==================================================        

        // ==================================================
        [Space(10)]
        [Header("[ Information ]")]
        [Tooltip("piece of work name")]
        public string galleryTitle = "";
        [Tooltip("piece of work category")]
        public string galleryCategory = "";
        [Tooltip("piece of work website")]
        public string galleryDeeplink = "";
        [Tooltip("piece of work related links")]
        public string galleryOutlink = "";

        [Tooltip("gallery piece of work related writer information - writer name, type(writer, picture, originel), description, related link")]
        public List<GalleryWriter> galleryWriters;
        // ==================================================



        // ==================================================
        // Image    
        [Space(10)]
        [Header("[ Resources ]")]
        [Tooltip("Refer to InteractiveBase.cs commant or sdk document")]
        public InteractiveLocation artLocation = InteractiveLocation.None;
        [Tooltip("Art location type path")]
        public string artPath = "";

        // Image description
        [TextArea(3, 10)]
        [Tooltip("piece of work related description")]
        public string artDescription = "";
        // ==================================================
    }

}