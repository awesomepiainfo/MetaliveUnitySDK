/*
 * brunch : phantom
 * update : 2023-02-24
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metalive
{

    public class MetaliveProfileData : ScriptableObject
    {
        // 설명옵션
        // 길이? 등등 인스펙터 설정하자

        public string projectBundleIndentifier;
        public string projectCode;
        public string projectName;
        public string projectCompany;        
    }

}

#endif