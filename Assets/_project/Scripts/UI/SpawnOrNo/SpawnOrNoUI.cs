using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class SpawnOrNoUI : MonoBehaviour
{
    public Interactable yes, no;
    public GameObject scroolScreen, currentObject;
    public Transform contentTransform;

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
    }

    private void Yes()
    {
        currentObject.transform.SetParent(null);
        
        currentObject.AddComponent<NearInteractionGrabbable>();
        currentObject.AddComponent<ManipulationHandler>();
        
        currentObject = null;
        
        gameObject.SetActive(false);
        
        scroolScreen.SetActive(true);
    }
}