using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridSlot : MonoBehaviour, IDropHandler {

    public void OnDrop(PointerEventData eventData)
    {

        int draggedObjIdx = eventData.pointerDrag.transform.parent.GetSiblingIndex();
        int finalPosIdx = transform.GetSiblingIndex();

        if (eventData.pointerDrag.transform.parent.name == gameObject.name) 
        {
            Debug.Log("tenho o nome igual");
            return;
        }
        if (transform.GetComponent<Cell>().IsEmpty) 
        {
            Debug.Log("estou num sitio sem nada");
            eventData.pointerDrag.transform.parent.SetSiblingIndex(finalPosIdx);
            transform.SetSiblingIndex(draggedObjIdx);
            transform.GetComponent<Cell>().CurrentPos = draggedObjIdx;
            eventData.pointerDrag.transform.parent.GetComponent<Cell>().CurrentPos = finalPosIdx;
            transform.parent.GetChild(finalPosIdx).GetComponent<Cell>().CheckIfConnectedCellHasPower(); //checks if the object is connected to power or not
            //if (GameManager.instance.winningCondition(GameManager.instance.ActualLevel))
            //{
            //    Debug.Log("entrei aqui no winningcondition");
            //    GameManager.instance.RefreshPlayerStatus();
            //}
            //GridManager.instance.UpdateCells();

        }
        else 
        {
            Debug.Log("estou num sitio com algo");
            eventData.pointerDrag.transform.parent.SetSiblingIndex(finalPosIdx);
            transform.SetSiblingIndex(draggedObjIdx);
            transform.GetComponent<Cell>().CurrentPos = draggedObjIdx;
            eventData.pointerDrag.transform.parent.GetComponent<Cell>().CurrentPos = finalPosIdx;
            transform.parent.GetChild(draggedObjIdx).GetComponent<Cell>().CheckIfConnectedCellHasPower();//checks if the new object in the iniPos is connected to power or not
            transform.parent.GetChild(finalPosIdx).GetComponent<Cell>().CheckIfConnectedCellHasPower();//checks if the new object in the finalPos is connected to power or not
            //if (GameManager.instance.winningCondition(GameManager.instance.ActualLevel))
            //{
            //    Debug.Log("entrei aqui no winningcondition");
            //    GameManager.instance.RefreshPlayerStatus();
            //}
            //GridManager.instance.UpdateCells();

        }
        
    }

}
