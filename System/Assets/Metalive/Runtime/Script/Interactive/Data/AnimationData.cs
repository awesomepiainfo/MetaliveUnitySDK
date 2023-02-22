/*
 * [ Animation list ]
 * 1. 
 * 2.
 * 3.
 * 4.
 * 5.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationData", menuName = "Interactive/AnimationData", order = int.MaxValue)]
public class AnimationData : ScriptableObject
{
    // ==================================================
    [Header("[ Use ]")]
    [Tooltip("[true] = use / [false] = ready ")]
    public bool isUse = true;
    // ==================================================



    // ==================================================
    [Space(10)]
    [Header("[ Resources ]")]    
    [Tooltip("Refer to InteractiveBase.cs commant or sdk document")]    
    public InteractiveLocation animationLocation = InteractiveLocation.Label;
    [Tooltip("play animation path(check animation list)")]
    public string animationPath = "";
    // ==================================================



    // ==================================================
    [Space(10)]
    [Header("[ Start ]")]
    [Tooltip("[true] = use / [false] = ready")]
    public bool isStart = false;
    [Tooltip("animation start position")]
    public Vector3 startPosition;
    [Tooltip("animation start rotation")]
    public Vector3 startRotation;
    [Tooltip("animation reset scale")]
    public Vector3 startScale;
    // ==================================================



    // ==================================================
    [Space(10)]
    [Header("[ Finish ]")]
    [Tooltip("[true] = use / [false] = ready")]
    public bool isFinish = false;
    [Tooltip("animation finish position")]
    public Vector3 finishPosition;
    [Tooltip("animation finish rotation")]
    public Vector3 finishRotation;
    [Tooltip("animation finish scale")]
    public Vector3 finishScale;
    // ==================================================
}
