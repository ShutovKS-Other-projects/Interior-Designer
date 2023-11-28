using System.Collections.Generic;
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

    private void Start()
    {
        itemDataArray = Resources.LoadAll<ItemData>("Data");
            
        exitButton.OnClick.AddListener(OpenStyleMenu);
        
        gameObject.SetActive(false);
    }

    public void SetUp(StyleType styleType, RoomType roomType)
    {
        foreach (var itemData in itemDataArray)
        {
            if (itemData.roomType == roomType && itemData.styleType == styleType)
            {
                CreatedCreatedButton(itemData);
            }
        }
        
        gridObjectCollection.UpdateCollection();
    }

    private void CreatedCreatedButton(ItemData itemData)
    {
        var instance = Instantiate(itemData.prefab, contentTransform);
        
        buttons.Add(instance);
        
        var interactable = instance.AddComponent<Interactable>();
        
        interactable.OnClick.AddListener(() => InstanceObject(itemData.prefab));
        
        instance.SetActive(true);
    }

    private void InstanceObject(GameObject prefab)
    {
        var spawnOrNoUI = spawnOrNo.GetComponent<SpawnOrNoUI>();
        
        spawnOrNoUI.currentObject = Instantiate(prefab, spawnOrNoUI.contentTransform);
        
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