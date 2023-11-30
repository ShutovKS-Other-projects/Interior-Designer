using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

public class ScroolScreenUI : MonoBehaviour
{
    public GameObject styleMenu, spawnOrNo;
    public Interactable exitButton;
    public Transform contentTransform;
    public GridObjectCollection gridObjectCollection;
    private List<GameObject> buttons = new();
    private ItemData[] itemDataArray;
    private StyleType _styleType;
    private RoomType _roomType;

    private void Start()
    {
        itemDataArray = Resources.LoadAll<ItemData>("Data");

        exitButton.OnClick.AddListener(OpenStyleMenu);

        gameObject.SetActive(false);
    }

    public void SetUp(StyleType styleType, RoomType roomType)
    {
        _roomType = roomType;
        _styleType = styleType;

        foreach (var itemData in itemDataArray)
        {
            if (itemData.roomType == _roomType && itemData.styleType == _styleType)
            {
                CreatedCreatedButton(itemData);
            }
        }

        gridObjectCollection.UpdateCollection();
    }

    public void UpdateCollection()
    {
        gridObjectCollection.UpdateCollection();
    }

    private void CreatedCreatedButton(ItemData itemData)
    {
        var instance = Instantiate(itemData.prefab, contentTransform);

        buttons.Add(instance);

        instance.AddComponent<ConstraintManager>();
        instance.AddComponent<NearInteractionGrabbable>();
        instance.AddComponent<ObjectManipulator>();
        instance.AddComponent<Rigidbody>().isKinematic = true;
        instance.GetComponent<Rigidbody>().useGravity = false;

        // var interactable = instance.AddComponent<Interactable>();
        // interactable.OnClick.AddListener(() => InstanceObject(itemData.prefab));

        ManipulationEvent manipulationStarted = new();
        manipulationStarted.AddListener((_) => InstanceObject(itemData.prefab));
        instance.GetComponent<ObjectManipulator>().OnManipulationStarted = manipulationStarted;

        instance.SetActive(true);
    }

    private void InstanceObject(GameObject prefab)
    {
        var spawnOrNoUI = spawnOrNo.GetComponent<SpawnOrNoUI>();

        spawnOrNoUI.currentObject = Instantiate(prefab, spawnOrNoUI.contentTransform);

        spawnOrNoUI.currentObject.AddComponent<ConstraintManager>();
        spawnOrNoUI.currentObject.AddComponent<NearInteractionGrabbable>();
        spawnOrNoUI.currentObject.AddComponent<ObjectManipulator>();
        spawnOrNoUI.currentObject.AddComponent<Rigidbody>().isKinematic = true;

        spawnOrNo.SetActive(true);

        gameObject.SetActive(false);
    }

    private void OpenStyleMenu()
    {
        RemoveAllButton();

        gameObject.SetActive(false);

        styleMenu.SetActive(true);
    }

    private void RemoveAllButton()
    {
        while (buttons.Count > 0)
        {
            Destroy(buttons[0]);

            buttons.RemoveAt(0);
        }
    }
}