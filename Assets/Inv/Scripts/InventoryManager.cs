using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] ItemData empty;
    [Space]
    public ItemData[,] items = new ItemData[3, 5];
    public int[,] itemCount = new int[3, 5];
    [Space]
    [SerializeField] Image[] invCollum1 = new Image[5];
    [SerializeField] Image[] invCollum2 = new Image[5];
    [SerializeField] Image[] invCollum3 = new Image[5];
    Image[] currentCollum;

    void Awake()
    {
        EmptyInv();
    }

    public void EmptyInv()
    {
        for(int y = 0; y < items.GetLength(1); y++)
        {
            for(int x = 0; x < items.GetLength(0); x++)
            {
                //Update artificial grid
                items[x, y] = empty;
                itemCount[x, y] = 0;

                DisplayNewItem(x, y, empty);
            }
        }
    }

    public void AddItem(ItemData item)
    {
        for(int y = 0; y < items.GetLength(1); y++)
        {
            for(int x = 0; x < items.GetLength(0); x++)
            {
                //Grab first free slot
                if(CanInsert(item, x, y))
                {
                    InsertStackable(item, x, y);
                    return;
                }
            }
        }

        CantAddToInv(item);
    }

    void CantAddToInv(ItemData item)
    {
        //Do something when inv is full
        Debug.Log($"Can't add more of '{item.itemName}' to inventory");
    }


    void DisplayNewItem(int x, int y, ItemData item)
    {
        CollumSwitch(x);

        //Update visuals
        currentCollum[y].sprite = item.icon;
        currentCollum[y].transform.GetChild(0).GetComponent<TMP_Text>().text = itemCount[x, y].ToString();

        //Contain data within slot
        currentCollum[y].transform.parent.GetComponent<SlotDataHolder>().heldItem = item;
        currentCollum[y].transform.parent.GetComponent<SlotDataHolder>().heldAmount = itemCount[x,y];
    }

    bool CanInsert(ItemData item, int x, int y)
    {
        //If nothing in current slot
        if(items[x, y].itemName == "EMPTY")
            return true;

        //If same item in current slot, and not full
        if(items[x, y] == item && itemCount[x, y] < item.maxCount)
            return true;

        return false;
    }

    void InsertStackable(ItemData item, int x, int y)
    {
        if(items[x, y].itemName == "EMPTY")
        {
            //If first in stack, create item in slot and set count
            items[x, y] = item;
            itemCount[x, y] = 1;
        }
        else
            //If in pre-existing stack, increase count
            itemCount[x, y]++;

        DisplayNewItem(x, y, item);
    }

    public void RemoveStackItems(ItemData item)
    {
        for(int i = 0; i < item.maxCount; i++)
            RemoveItem(item);
    }

    public void RemoveItem(ItemData item)
    {
        //Loop backwards
        for(int y = items.GetLength(1) - 1; y >= 0; y--)
        {
            for(int x = items.GetLength(0) - 1; x >= 0; x--)
            {
                if(items[x, y] == item)
                {
                    //Take one from count
                    itemCount[x, y]--;
                    DisplayNewItem(x, y, item);

                    //Remove item from slot if empty
                    if(itemCount[x, y] == 0)
                    {
                        items[x, y] = empty;
                        DisplayNewItem(x, y, empty);
                    }

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
}
