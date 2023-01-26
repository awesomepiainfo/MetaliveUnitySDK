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
    [Tooltip("[true] = use / [false] = unuse")]
    public bool isAnimation = true;
    [Tooltip("Refer to InteractiveBase.cs commant or sdk document")]
    public readonly InteractiveLocation animationLocation = InteractiveLocation.Local;
    [Tooltip("play animation path(check animation list)")]
    public string animationPath = "";
    // ==================================================



    // ==================================================
    [Space(10)]
    [Header("[ Start ]")]
    public bool isStart = false;
    [Tooltip("animation start position")]
    public Vector3 startPosition;
    [Tooltip("animation start rotation")]
    public Vector3 startRotation;
    // ==================================================



    // ==================================================
    [Space(10)]
    [Header("[ Finish ]")]
    public bool isFinish = false;
    [Tooltip("animation finish position")]
    public Vector3 finishPosition;
    [Tooltip("animation finish rotation")]
    public Vector3 finishRotation;
    // ==================================================
}
