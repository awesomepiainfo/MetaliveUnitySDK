using UnityEngine;

namespace Metalive.Map
{

    [CreateAssetMenu(fileName = "MapData", menuName = "Metalive/Map/MapData", order = int.MaxValue)]
    public class MapData : ScriptableObject
    {
        // ==================================================
        [Header("[ Use ]")]
        [Tooltip("[true] = use / [false] = ready")]
        public bool isUse = true;
        // ==================================================



        // ==================================================
        [Space(10)]
        [Header("[ Resources ]")]
        [Tooltip("Refer to WorldBase.cs commant or sdk document")]
        public MapLocation mapLocation = MapLocation.Label;
        [Tooltip("map image path(check riding list)")]
        public string mapPath = "";
        // ==================================================



        // ==================================================
        [Space(10)]
        [Header("[ Point ]")]
        [Tooltip("[true] = use / [false] = ready")]
        public bool isPoint = false;
        [Tooltip("player point position")]
        public Vector3 pointPosition;
        [Tooltip("player point rotation")]
        public Vector3 pointRotation;
        [Tooltip("player point scale")]
        public Vector3 pointScale;
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

        [Tooltip("camera reset orthographic size")]
        [Range(0, 179)]
        public float resetSize = 60;
        // ==================================================
    }

}