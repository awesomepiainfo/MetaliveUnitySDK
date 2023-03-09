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
        // ����ɼ�
        // ����? ��� �ν����� ��������

        public string projectBundleIndentifier;
        public string projectCode;
        public string projectName;
        public string projectCompany;        
    }

}

#endif