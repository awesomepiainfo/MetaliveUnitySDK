using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractiveMode
{
    None = 0,
    Animation = 1,
    Gallery = 2,
    Telescope = 3,
    Market = 4,
    Npc = 5,
    Riding = 6,
    TV = 7,
}

public class InteractiveClick : MonoBehaviour
{
    public InteractiveMode mode = InteractiveMode.None;
    public string label = "";        
}
