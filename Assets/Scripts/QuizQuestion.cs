using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/QuizQuestion")]
public class QuizQuestion : ScriptableObject {
    [SerializeField] private String title;
    [SerializeField] private String question;
    [SerializeField] private ElementType resultType;
    private void Awake() {
        requirements.Sort(Util.ComparisonByHashCode);
    }

    public string Title => title;
    public string Question => question;
    public ElementType ResultType => resultType;
    public List<ElementType> requirements;
}