using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Element", menuName = "Element")]
public class ElementScriptableObj : ScriptableObject
{
    public string elementName;
    public Sprite image;
}
