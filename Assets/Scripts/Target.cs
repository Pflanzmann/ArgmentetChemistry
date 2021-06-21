using System.Security.Cryptography;
using UnityEngine;

public class Target : MonoBehaviour {
    [SerializeField] private ElementType elementType;
    private ElementType currentElementType;
    private bool targetSeen = false;
    private GameObject currentModel;

    public ElementType ElementType { get => currentElementType; set => currentElementType = value; }

    public bool TargetSeen => targetSeen;

    public GameObject CurrentModel => currentModel;

    public void OnTargetFound() {
        targetSeen = true;
        ResetTarget();
        TargetManager.Instance.OnTargetFound(this);
    }

    public void OnTargetLost() {
        targetSeen = false;
        TargetManager.Instance.OnTargetLost(this);
    }

    private void OnTriggerEnter(Collider other) {
        if(TargetSeen)
            TargetManager.Instance.OnCollisionDetected(this);
    }

    public void SetEmptyModel() {
        if(CurrentModel != null) {
            Destroy(CurrentModel);
        }

        currentElementType = ScriptableObject.CreateInstance<ElementType>();
    }

    public void SwapElement(ElementType elementType) {
        if(CurrentModel != null) {
            Destroy(CurrentModel);
        }

        currentElementType = elementType;

        if(currentElementType.Model == null) return;
        currentModel = Instantiate(elementType.Model, transform.position + (Vector3.up / 2), transform.rotation, transform);
    }

    private void ResetTarget() {
        currentElementType = elementType;
        if(CurrentModel != elementType.Model)
            Destroy(CurrentModel);
        currentModel = Instantiate(elementType.Model, transform.position + (Vector3.up / 2), transform.rotation, transform);
    }
}