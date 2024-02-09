using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverDetection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    SlotDataHolder data;
    DescriptionManager descriptionManager;


    void Awake()
    {
        data = transform.parent.GetComponent<SlotDataHolder>();
        descriptionManager = FindObjectOfType<DescriptionManager>();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionManager.ShowDescription(data.heldItem, data.heldAmount);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionManager.HideDescription();
    }
}
