using UnityEngine;

[CreateAssetMenu(fileName = "New Element", menuName = "Element")]
public class ElementScriptableObj : ScriptableObject
{
    [SerializeField] private string _elementName;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private ElementScriptableObj _firstElemForCraft;
    [SerializeField] private ElementScriptableObj _secondElemForCraft;
    [SerializeField] private bool _isCreated;

    public string ElementName { get { return _elementName; } }
    public bool IsCreated { get { return _isCreated; } set { _isCreated = value; } }
    public Sprite Image { get { return _sprite; } }
    public ElementScriptableObj FirstElemForCraft { get { return _firstElemForCraft; } }
    public ElementScriptableObj SecondElemForCraft { get { return _secondElemForCraft; } }

}
