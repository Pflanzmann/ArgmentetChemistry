using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ElementType")]
public class ElementType : ScriptableObject {
    [SerializeField] private String elementName;
    [SerializeField] private GameObject model;

    public string ElementName => elementName;
    public GameObject Model => model;
}