using UnityEngine;

[CreateAssetMenu(fileName = "RidingData", menuName = "Interactive/RidingData", order = int.MaxValue)]
public class RidingData : ScriptableObject
{
    // ==================================================
    [Header("[ Use ]")]
    [Tooltip("[true] = use / [false] = ready")]
    public bool isUse = true;
    // ==================================================



    // ==================================================

}
