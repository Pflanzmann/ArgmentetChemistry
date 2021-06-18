using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/QuizQuestion")]
public class QuizQuestion : ScriptableObject {
    [SerializeField] private String title;
    [SerializeField] private String question;

    public string Title => title;
    public string Question => question;

    public List<ElementType> requirements;
}