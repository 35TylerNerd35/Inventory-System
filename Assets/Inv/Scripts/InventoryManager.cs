using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] ItemData empty;
    [Space]
    ItemData[,] items = new ItemData[3, 5];
    [SerializeField] Image[] invCollum1 = new Image[5];
    [SerializeField] Image[] invCollum2 = new Image[5];
    [SerializeField] Image[] invCollum3 = new Image[5];
    Image[] currentCollum;

    void Awake()
    {
        //Empty inv
        for(int y = 0; y < items.GetLength(1); y++)
        {
            for(int x = 0; x < items.GetLength(0); x++)
            {
                CollumSwitch(x);

                currentCollum[y].sprite = empty.Icon;
                currentCollum[y].transform.GetChild(0).GetComponent<TMP_Text>().text = empty.itemName;
            }
        }
    }

    public void AddItem(ItemData item)
    {
        for(int y = 0; y < items.GetLength(1); y++)
        {
            for(int x = 0; x < items.GetLength(0); x++)
            {
                if(CanInsert(item, x, y))
                {
                    CollumSwitch(x);

                    currentCollum[y].sprite = item.Icon;
                    currentCollum[y].transform.GetChild(0).GetComponent<TMP_Text>().text = item.itemName;
                    return;
                }
            }
        }
    }

    public void CollumSwitch(int collum)
    {
        switch (collum)
        {
            case 2:
                currentCollum = invCollum3;
                break;
            case 1:
                currentCollum = invCollum2;
                break;
            case 0:
                currentCollum = invCollum1;
                break;
        } 
    }

    bool CanInsert(ItemData item, int x, int y)
    {
        if(items[x, y].itemName == "EMPTY")
            return true;

        return false;
    }

    public void RemoveItem(ItemData item)
    {

    }

    void GrabItem(ItemData item)
    {

    }
}
