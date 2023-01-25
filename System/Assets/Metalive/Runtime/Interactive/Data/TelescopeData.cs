using UnityEngine;



[CreateAssetMenu(fileName = "TelescopeData", menuName = "Interactive/TelescopeData", order = int.MaxValue)]
public class TelescopeData : ScriptableObject
{
    [Header("[ Type ]")]
    [Tooltip("telescope load location")]
    public InteractiveLocation location = InteractiveLocation.None;

    [Space(10)]
    [Header("[ Label ]")]    
    [Tooltip("labeling according to type [local = Application.persistentDataPath path]  [clip = addressable location ] or [url = user https:// location]")]
    public string label = "";
}