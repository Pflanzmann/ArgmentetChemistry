using System;
using System.Collections.Generic;
using DefaultNamespace;
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

    public List<QuizQuestion> AllQuestions => allQuestions;

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }
    }

    private void Start() {
        foreach(var question in AllQuestions) {
            question.requirements.Sort(Util.ComparisonByHashCode);
        }

        AssignNewRandomQuestion();
    }

    public void SubmitAnswer(QuizQuestion question) {
        if(question == currentQuestion) {
            print("----You solved it!!----");
            AssignNewRandomQuestion();
        }
    }

    public void AssignNewRandomQuestion() {
        if(currentQuestionsList.Count == 0) {
            currentQuestionsList = new List<QuizQuestion>(AllQuestions);
        }

        var random = new Random();
        var randomIndex = random.Next(0, currentQuestionsList.Count);

        currentQuestion = currentQuestionsList[randomIndex];
        currentQuestionsList.Remove(currentQuestion);

        titleText.text = currentQuestion.Title;
        questionText.text = currentQuestion.Question;
        indexText.text = (AllQuestions.Count - currentQuestionsList.Count) + "/" + AllQuestions.Count;
    }
}