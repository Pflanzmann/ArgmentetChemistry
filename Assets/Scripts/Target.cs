using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour {
    [SerializeField] private GameObject comboPrefab;
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

    public void SwapElement(ElementType elementType, bool correctResutl) {
        if(CurrentModel != null) {
            Destroy(CurrentModel);
        }

        currentElementType = elementType;

        if(currentElementType.Model == null) return;

        if(correctResutl) {
            currentModel = Instantiate(comboPrefab, transform);
            var obj = Instantiate(elementType.Model, currentModel.transform);
            obj.transform.localPosition = Vector3.forward * -7;
            obj.transform.localScale = new Vector3(2f, 2f, 2f);
            GetComponent<ParticleSystem>().Play();
            currentModel.GetComponentInChildren<TMP_Text>().text = elementType.ElementName;
        } else {
            currentModel = Instantiate(elementType.Model, transform);
        }
    }

    private void ResetTarget() {
        currentElementType = elementType;
        if(CurrentModel != elementType.Model)
            Destroy(CurrentModel);
        currentModel = Instantiate(elementType.Model, transform);
    }
}