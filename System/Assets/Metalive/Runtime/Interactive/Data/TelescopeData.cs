using UnityEngine;

[CreateAssetMenu(fileName = "TelescopeData", menuName = "Interactive/TelescopeData", order = int.MaxValue)]
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
}