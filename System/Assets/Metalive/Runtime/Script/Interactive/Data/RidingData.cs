/*
 * Day : 2023-01-26
 * Writer : phantom(chho1365@gmail.com)
 */
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
    [Space(10)]    
    [Header("[ Resources ]")]    
    [Tooltip("Refer to InteractiveBase.cs commant or sdk document")]
    public InteractiveLocation ridingLocation = InteractiveLocation.Label;
    [Tooltip("riding prefab path(check riding list)")]    
    public string ridingPath = "";
    // ==================================================



    // ==================================================
    [Space(10)]
    [Header("[ Reset ]")]
    [Tooltip("[true] = use / [false] = unuse")]
    public bool isReset = false;
    [Tooltip("reset position")]
    public Vector3 resetPosition;
    [Tooltip("reset rotation")]
    public Vector3 resetRotation;
    [Tooltip("reset scale")]
    public Vector3 resetScale;
    // ==================================================
}
