using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

    

    private Transform originalCell;
    private bool isDragging;

    public void OnPointerDown(PointerEventData eventData)
    {
        
       
            Debug.Log("entrei aqui no OnPointerDown");

            if(eventData.button == PointerEventData.InputButton.Left)
            {
                isDragging = true;
                originalCell = transform.parent;
                transform.SetParent(transform.parent.parent);
                GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        


    }

    public void OnDrag(PointerEventData eventData)
    {
        
        
        
            Debug.Log("entrei aqui no OnDrag");
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                transform.position = Input.mousePosition;
            }
        
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        
        Debug.Log("entrei aqui no OnPointerUp");
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isDragging = false;
            transform.SetParent(originalCell);
            transform.localPosition = Vector3.zero;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        
    }

    
}
