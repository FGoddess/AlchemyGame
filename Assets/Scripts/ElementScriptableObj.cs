using UnityEngine;

[CreateAssetMenu(fileName = "New Element", menuName = "Element")]
public class ElementScriptableObj : ScriptableObject
{
    [SerializeField] private string _elementName;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private ElementScriptableObj _firstElemForCraft;
    [SerializeField] private ElementScriptableObj _secondElemForCraft;

    public string ElementName { get { return _elementName; } }
    public Sprite Image { get { return _sprite; } }
    public ElementScriptableObj FirstElemForCraft { get { return _firstElemForCraft; } }
    public ElementScriptableObj SecondElemForCraft { get { return _secondElemForCraft; } }

}
