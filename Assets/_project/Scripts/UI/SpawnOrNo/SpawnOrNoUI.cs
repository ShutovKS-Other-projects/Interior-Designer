using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class SpawnOrNoUI : MonoBehaviour
{
    public Interactable yes, no;
    public GameObject scroolScreen, currentObject;
    public Transform contentTransform;
    public ScroolScreenUI scroolScreenUI;


    private void Start()
    {
        yes.OnClick.AddListener(Yes);
        no.OnClick.AddListener(No);

        gameObject.SetActive(false);
    }

    private void No()
    {
        Destroy(currentObject);

        gameObject.SetActive(false);

        scroolScreen.SetActive(true);

        scroolScreenUI.UpdateCollection();
    }

    private void Yes()
    {
        currentObject.transform.SetParent(null);

        var rigidbody = currentObject.GetComponent<Rigidbody>();

        rigidbody.isKinematic = false;

        // ManipulationEvent manipulationStarted = new();
        // ManipulationEvent manipulationEnded = new();
        //
        // manipulationStarted.AddListener((_) => rigidbody.isKinematic = true);
        // manipulationEnded.AddListener((_) => rigidbody.isKinematic = false);
        //
        // currentObject.GetComponent<ObjectManipulator>().OnManipulationStarted = manipulationStarted;
        // currentObject.GetComponent<ObjectManipulator>().OnManipulationEnded = manipulationEnded;

        currentObject = null;

        gameObject.SetActive(false);

        scroolScreen.SetActive(true);
    }
}