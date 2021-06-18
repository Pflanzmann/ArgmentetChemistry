using System;
using UnityEngine;

public class Target : MonoBehaviour {
    [SerializeField] private ElementType elementType;

    public ElementType ElementType => elementType;


    public void OnTargetFound() {
        TargetManager.Instance.OnTargetFound(this);
    }

    public void OnTargetLost() {
        TargetManager.Instance.OnTargetLost(this);
    }
}