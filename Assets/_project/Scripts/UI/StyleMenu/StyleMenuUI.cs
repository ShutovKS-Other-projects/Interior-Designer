using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class StyleMenuUI : MonoBehaviour
{
    public Interactable Minimalism, Modern, Scandinavian, Loft, HighTech, Exit;
    public GameObject listRoom, scroll;
    public RoomType roomType;

    private void Start()
    {
        Minimalism.OnClick.AddListener(() => OpenScroll(StyleType.Minimalism));
        Modern.OnClick.AddListener(() => OpenScroll(StyleType.Modern));
        Scandinavian.OnClick.AddListener(() => OpenScroll(StyleType.Scandinavian));
        Loft.OnClick.AddListener(() => OpenScroll(StyleType.Loft));
        HighTech.OnClick.AddListener(() => OpenScroll(StyleType.HighTech));

        Exit.OnClick.AddListener(OpenListRoom);
        
        gameObject.SetActive(false);
    }

    private void OpenScroll(StyleType styleType)
    {
        gameObject.SetActive(false);
        
        scroll.SetActive(true);
        
        scroll.GetComponent<ScroolScreenUI>().SetUp(styleType, roomType);
    }

    private void OpenListRoom()
    {
        gameObject.SetActive(false);
        
        listRoom.SetActive(true);
    }
}