using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static GameObject dragedObject;
    Inventory inventory;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragedObject = gameObject;
        inventory.dragPrefab.SetActive(true);
        inventory.dragPrefab.GetComponent<CanvasGroup>().blocksRaycasts = false;
        if (dragedObject.GetComponent<CurrentItem>())
        {
            int index = dragedObject.GetComponent<CurrentItem>().index;
            inventory.dragPrefab.GetComponent<Image>().sprite = inventory.item[index].icon;
            if(inventory.dragPrefab.GetComponent<Image>().sprite == null)
            {
                dragedObject = null;
                inventory.dragPrefab.SetActive(false);
            }
           
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        inventory.dragPrefab.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragedObject = null ;
        inventory.dragPrefab.SetActive(false);
       //inventory.dragPrefab.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
