using System.Collections.Generic;
using UnityEngine;

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
    }

    public void OnTargetLost(Target target) {
        currentTargets.Remove(target);
    }

    public void OnCollisionDetected(Target target) {
        if(!target.TargetSeen) return;

        var targets = new List<Target>();

        foreach(var comparedTarget in currentTargets) {
            if(comparedTarget != target && comparedTarget.TargetSeen &&
               Vector2.Distance(comparedTarget.transform.position, target.transform.position) <= 1.5) {
                targets.Add(comparedTarget);
            }
        }

        ComboManager.Instance.CheckCombinations(target, targets);
    }
}