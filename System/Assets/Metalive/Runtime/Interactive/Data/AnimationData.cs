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
    [Header("[ Label ]")]
    [Tooltip("play animation label(check animation list)")]
    public string animation = "";

    [Space(10)]
    [Header("[ Start ]")]
    public InteractivePlay start = InteractivePlay.None;
    [Tooltip("animation start position")]
    public Vector3 startPosition;
    [Tooltip("animation start rotation")]
    public Vector3 startRotation;

    [Space(10)]
    [Header("[ Finish ]")]
    public InteractivePlay finish = InteractivePlay.None;
    [Tooltip("animation finish position")]
    public Vector3 finishPosition;
    [Tooltip("animation finish rotation")]
    public Vector3 finishRotation;
}
