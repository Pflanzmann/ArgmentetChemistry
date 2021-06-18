using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class QuizManager : MonoBehaviour {
    public static QuizManager Instance;

    [SerializeField] private TMP_Text indexText;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text questionText;

    [SerializeField] private List<QuizQuestion> allQuestions;

    private List<QuizQuestion> currentQuestionsList = new List<QuizQuestion>();
    [SerializeField] private QuizQuestion currentQuestion;

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }
    }

    private void Start() {
        AssignNewRandomQuestion();
    }

    public void OnCurrentTargetsChanged(List<Target> targets) {
        foreach(var requirement in currentQuestion.requirements) {
            var foundTarget = targets.Find(target => target.ElementType == requirement);
            if(foundTarget != null) {
                targets.Remove(foundTarget);
            } else {
                print("Not fitting answers");
            }
        }

        if(targets.Count == 0) {
            print("we solved the quiz!!");
            AssignNewRandomQuestion();
        }
    }

    public void AssignNewRandomQuestion() {
        if(currentQuestionsList.Count == 0) {
            currentQuestionsList = new List<QuizQuestion>(allQuestions);
        }

        var random = new Random();
        var randomIndex = random.Next(0, currentQuestionsList.Count);

        currentQuestion = currentQuestionsList[randomIndex];
        currentQuestionsList.Remove(currentQuestion);

        titleText.text = currentQuestion.Title;
        questionText.text = currentQuestion.Question;
        indexText.text = (allQuestions.Count - currentQuestionsList.Count).ToString() + "/" + allQuestions.Count.ToString();
    }
}