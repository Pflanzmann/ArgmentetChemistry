using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class ComboManager : MonoBehaviour {
    public static ComboManager Instance;

    private bool isCombinating = false;

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }
    }

    public void CheckCombinations(Target target, List<Target> otherTargets) {
        if(isCombinating) return;

        var elements = otherTargets.ConvertAll(obj => obj.ElementType);
        elements.Add(target.ElementType);
        elements.Sort(Util.ComparisonByHashCode);

        foreach(var question in QuizManager.Instance.AllQuestions) {
            if(elements.SequenceEqual(question.requirements)) {
                isCombinating = true;
                StartCoroutine(CombineElements(target, otherTargets, question));
            }
        }
    }

    private IEnumerator CombineElements(Target target, List<Target> otherTargets, QuizQuestion question) {
        var otherObjects = otherTargets.ConvertAll(input => input.CurrentModel);
        var targetObject = target.CurrentModel;

        var didMoveSomething = true;

        while(didMoveSomething) {
            didMoveSomething = false;

            foreach(var otherObject in otherObjects) {
                if(Vector3.Distance(targetObject.transform.position, otherObject.transform.position) > 0.25) {
                    didMoveSomething = true;
                    otherObject.transform.position += (targetObject.transform.position - otherObject.transform.position) * (Time.deltaTime * 5);
                }
            }

            yield return new WaitForEndOfFrame();
        }

        AssignCombination(target, otherTargets, question.ResultType);
        QuizManager.Instance.SubmitAnswer(question);
        isCombinating = false;
    }

    private void AssignCombination(Target mainTarget, List<Target> otherTargets, ElementType result) {
        foreach(var target in otherTargets) {
            target.SetEmptyModel();
        }

        mainTarget.SwapElement(result);
    }
}