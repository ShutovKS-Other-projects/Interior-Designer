using UnityEngine;

[CreateAssetMenu(fileName = "new ItemData", menuName = "ItemData", order = 0)]
public class ItemData : ScriptableObject
{
    public string name;
    public StyleType styleType;
    public RoomType roomType;
    public GameObject prefab;
}

public enum StyleType
{
    None,
    Minimalism,
    Modern,
    Scandinavian,
    Loft,
    HighTech
}

public enum RoomType
{
    None,
    Kitchen,
    Bedroom,
    LivingRoom,
    Cabinet,
    Bathroom
}