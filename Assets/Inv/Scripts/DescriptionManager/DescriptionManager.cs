using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] TMP_Text itemName;
    [SerializeField] Image descriptionIcon;
    [SerializeField] TMP_Text itemDescription;

    public void ShowDescription(ItemData item, int itemCount)
    {
        //Don't show for empty slots
        if(item.itemName == "EMPTY")
            return;

        descriptionIcon.sprite = item.icon;
        itemDescription.text = item.description;

        //Format item title
        string title = $"{item.itemName} ({itemCount})";
        itemName.text = title;

        anim.Play("IN");
    }

    public void HideDescription()
    {
        anim.Play("OUT");
    }
}
