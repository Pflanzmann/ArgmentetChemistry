using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Combinations")]
public class Combinations : ScriptableObject {
    [SerializeField] private List<ElementType> requirements;
    [SerializeField] private ElementType result;

    public List<ElementType> Requirements => requirements;
    public ElementType Result => result;
}