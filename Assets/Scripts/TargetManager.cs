using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetManager : MonoBehaviour {
    public static TargetManager Instance;

    public List<Target> currentTargets = new List<Target>();

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }
    }

    public void OnTargetFound(Target target) {
        currentTargets.Add(target);
        TargetsUpdated();
    }

    public void OnTargetLost(Target target) {
        currentTargets.Remove(target);
        TargetsUpdated();
    }

    public void TargetsUpdated() {
        if(currentTargets.Count > 0) {
            QuizManager.Instance.OnCurrentTargetsChanged(new List<Target>(currentTargets));
        }
    }
}