using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_item", menuName = "Data/ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    public Sprite Icon;
    public int maxCount;
    public string itemName;
    public string itemDescription;
}
