using UnityEngine;

namespace Metalive.World
{

    [CreateAssetMenu(fileName = "SystemData", menuName = "Metalive/System/SystemData", order = int.MaxValue)]
    public class SystemData : ScriptableObject
    {
        // ==================================================
        [Header("[ Use ]")]
        [Tooltip("[true] = use / [false] = ready")]
        public bool isUse = true;
        // ==================================================



        // ==================================================
        [Space(10)]
        [Header("[ Information ]")]
        [Tooltip("World name")]
        public string systemName = "";
        [Tooltip("Worlddescription")]
        public string systemDescription = "";
        // ==================================================


        // ==================================================
        [Space(10)]
        [Header("[ Reset ]")]
        [Tooltip("bool = [false : vector3.zero]")]
        public bool isReset = false;
        [Tooltip("player reset position")]
        public Vector3 resetPosition;
        [Tooltip("player reset rotation")]
        public Vector3 resetRotation;
        [Tooltip("player reset scale")]
        public Vector3 resetScale;
        // ==================================================
    }

}