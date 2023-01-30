using UnityEngine;

[CreateAssetMenu(fileName = "NpcData", menuName = "Interactive/NpcData", order = int.MaxValue)]
public class NpcData : ScriptableObject
{
    // ==================================================
    [Header("[ Use ]")]
    [Tooltip("[true] = use / [false] = ready")]
    public bool isUse = true;
    // ==================================================



    // ==================================================
    [Space(10)]
    [Header("[ Information ]")]
    [Tooltip("npc name")]
    public string npcTitle = "";
    [Tooltip("npc chat")]
    [TextArea(3, 10)]
    public string[] npcChat;
    // ==================================================



    // ==================================================
    [Space(10)]
    [Header("[ Resources ]")]
    [Tooltip("Refer to InteractiveBase.cs commant or sdk document")]
    public InteractiveLocation backgroundLocation = InteractiveLocation.None;
    [Tooltip("Telescope location type path")]
    public string backgroundPath;

    [Space(7)]
    [Tooltip("Refer to InteractiveBase.cs commant or sdk document")]
    public InteractiveLocation avatarLocation = InteractiveLocation.None;
    [Tooltip("Avatar location type path")]
    public string avatarPath;

    [Space(7)]
    [Tooltip("Refer to InteractiveBase.cs commant or sdk document")]
    public InteractiveLocation ttsLocation = InteractiveLocation.None;
    [Tooltip("TTS location type path")]
    public string ttsPath;
    // ==================================================


}
