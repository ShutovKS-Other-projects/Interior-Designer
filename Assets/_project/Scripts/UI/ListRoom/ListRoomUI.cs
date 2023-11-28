using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class ListRoomUI : MonoBehaviour
{
    public Interactable Kitchen, Bedroom, LivingRoom, Cabinet, Bathroom, Exit;
    public GameObject mainMenu, styleMenu;

    private void Start()
    {
        Kitchen.OnClick.AddListener(() => OpenStyleMenuRoom(RoomType.Kitchen));
        Bedroom.OnClick.AddListener(() => OpenStyleMenuRoom(RoomType.Bedroom));
        LivingRoom.OnClick.AddListener(() => OpenStyleMenuRoom(RoomType.LivingRoom));
        Cabinet.OnClick.AddListener(() => OpenStyleMenuRoom(RoomType.Cabinet));
        Bathroom.OnClick.AddListener(() => OpenStyleMenuRoom(RoomType.Bathroom));
        
        Exit.OnClick.AddListener(OpenMainMenu);
        
        gameObject.SetActive(false);
    }

    private void OpenStyleMenuRoom(RoomType roomType)
    {
        styleMenu.GetComponent<StyleMenuUI>().roomType = roomType;

        styleMenu.SetActive(true);
        
        gameObject.SetActive(false);
    }
    
    private void OpenMainMenu()
    {
        gameObject.SetActive(false);
        
        mainMenu.SetActive(true);
    }
}