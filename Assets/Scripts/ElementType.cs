using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ElementType")]
public class ElementType : ScriptableObject {
    [SerializeField] private String elementName;

    public string ElementName => elementName;
}