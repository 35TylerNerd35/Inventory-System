using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_item", menuName = "Data/ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    public Sprite icon;
    public int maxCount;
    public string itemName;
    [TextArea] public string description;
}
