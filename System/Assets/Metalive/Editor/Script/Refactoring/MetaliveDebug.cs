#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metalive
{
    public class MetaliveDebug
    {

        public static bool IsMine = true;        

        public static void Message(string key, string value)
        {
            if(IsMine)
            {
                Debug.Log($"Key : {key} / Value : {value}");         
            }
        }        
    }
}

#endif