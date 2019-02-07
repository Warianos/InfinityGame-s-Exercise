using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridSlot : MonoBehaviour, IDropHandler {

    

	public void UpdateSlot () {
        if(GridManager.instance.Grid[transform.GetSiblingIndex()] != null)
        {
            transform.gameObject.SetActive(true);
        }
        else
        {
            transform.gameObject.SetActive(false);
        }
		
	}

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedCell = GridManager.instance.Grid[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()]; // the cell that was dragged
                                                                                                                                                      // Debug.Log(droppedCell.name);

        Debug.Log(eventData.pointerDrag.transform.parent.name + "é igual a" + gameObject.name);
        if (eventData.pointerDrag.transform.parent.name == gameObject.name) //if the dragged parent´s name is equal to this slot´s name, then does nothing.
        {
            Debug.Log("tenho o nome igual");
            return;
        }

        
        if (GridManager.instance.Grid[transform.GetSiblingIndex()].GetComponent<Cell>().IsEmpty) // if the cell is empty it can move to that slot
        {
            Debug.Log("estou num sitio sem nada");

            GameObject tempCell = GridManager.instance.Grid[transform.GetSiblingIndex()];
           
            GridManager.instance.Grid[transform.GetSiblingIndex()] = droppedCell;

            //gameObject = droppedCell;


            GridManager.instance.Grid[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()] = tempCell;
            
            GridManager.instance.UpdateSlots(transform.parent,droppedCell.GetComponent<Cell>().CurrentPos, tempCell.GetComponent<Cell>().CurrentPos);
        }
        else // if the cell is not empty then the cells swap places
        {
            Debug.Log("estou num sitio com algo");
            GameObject tempCell = GridManager.instance.Grid[transform.GetSiblingIndex()];
            GridManager.instance.Grid[transform.parent.GetSiblingIndex()] = droppedCell;
            GridManager.instance.Grid[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()] = tempCell;

            GridManager.instance.UpdateSlots(transform.parent, droppedCell.GetComponent<Cell>().CurrentPos, tempCell.GetComponent<Cell>().CurrentPos);
        }
    }

}
