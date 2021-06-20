using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboChecker : MonoBehaviour {

    public static ComboChecker Instance;

    [SerializeField] private List<Combinations> combinationsList = new List<Combinations>();

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }
    }


    public void CheckCombinations(Target target, List<Target> otherTargets) {
        foreach(var combination in combinationsList) {
        }
    }
}
