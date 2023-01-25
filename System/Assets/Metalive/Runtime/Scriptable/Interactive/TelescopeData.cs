/*
 * Day : 2023-01-26
 * Writer : phantom(chho1365@gmail.com)
 */

using UnityEngine;

namespace Metalive.Interactive
{

    [CreateAssetMenu(fileName = "TelescopeData", menuName = "Metalive/Interactive/TelescopeData", order = int.MaxValue)]
    public class TelescopeData : ScriptableObject
    {
        // ==================================================
        [Header("[ Use ]")]
        [Tooltip("[true] = use / [false] = ready")]
        public bool isUse = true;
        // ==================================================



        // ==================================================
        [Space(10)]
        [Header("[ Resources ]")]
        [Tooltip("Refer to InteractiveBase.cs commant or sdk document")]
        public InteractiveLocation telescopeLocation = InteractiveLocation.None;
        [Tooltip("Telescope location type path")]
        public string telescopePath = "";
        // ==================================================



        // ==================================================
        [Space(10)]
        [Header("[ Reset ]")]
        [Tooltip("[true] = use / [false] = ready")]
        public bool isReset = false;
        [Tooltip("camera reset position")]
        public Vector3 resetPosition;
        [Tooltip("camera reset rotation")]
        public Vector3 resetRotation;
        [Tooltip("camera reset scale")]
        public Vector3 resetScale;
        // ==================================================
    }

}