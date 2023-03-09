/*
 * brunch : phantom
 * update : 2023-02-24
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetaliveEditor
{

    [Serializable]
    public class MetaliveProject
    {
        public string name;
        public string company;        
        public string bundleIndentifier;
        public string code;
    }

    public class MetaliveSettingData : ScriptableObject
    {
        public MetaliveProject project;        
    }

}

#endif