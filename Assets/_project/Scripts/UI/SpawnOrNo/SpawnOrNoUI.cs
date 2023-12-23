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
        rigidbody.useGravity = true;

        currentObject.transform.localScale = currentObject.transform.localScale * 4;

        currentObject = null;

        gameObject.SetActive(false);

        scroolScreen.SetActive(true);

        scroolScreenUI.UpdateCollection();
    }
}