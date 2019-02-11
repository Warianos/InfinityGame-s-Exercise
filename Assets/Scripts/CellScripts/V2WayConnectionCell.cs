using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2WayConnectionCell : Cell
{


    void Awake()
    {

        CellType = Type.V2Way;
        CellAnimator = GetComponent<Animator>();
     
    }


    public override void CheckIfConnectedCellHasPower()
    {
        int currentPos = CurrentPos;

        Transform up;
        Transform down;
        

        int gridSize = (int)GridManager.instance.GridSize.x * (int)GridManager.instance.GridSize.y;
        int gridWidth = (int)GridManager.instance.GridSize.x;

        if ((currentPos - gridWidth) >= 0)
        {
            up = transform.parent.GetChild(currentPos - gridWidth);
            if (up.GetComponent<Cell>().HasPower)
            {
                
                    if (up.GetComponent<Cell>().cellType == Type.Way4 ||
                       up.GetComponent<Cell>().cellType == Type.LampCell270 ||
                       up.GetComponent<Cell>().cellType == Type.PowerCell270 ||
                       up.GetComponent<Cell>().cellType == Type.V2Way)
                    {
                        HasPower = true;
                        PowerColorChange();
                       // up.GetComponent<Cell>().CheckIfConnectedCellHasPower();
                        return;
                    }
                
            }
        }
        if ((currentPos + gridWidth) < gridSize)
        {
            down = transform.parent.GetChild(currentPos + gridWidth);
            if (down.GetComponent<Cell>().HasPower)
            {
                
                    if (down.GetComponent<Cell>().cellType == Type.Way4 ||
                    down.GetComponent<Cell>().cellType == Type.LampCell90 ||
                    down.GetComponent<Cell>().cellType == Type.PowerCell90 ||
                    down.GetComponent<Cell>().cellType == Type.V2Way)
                    {

                        HasPower = true;
                        PowerColorChange();
                       // down.GetComponent<Cell>().CheckIfConnectedCellHasPower();
                        return;
                    }
                
            }
        }
        
        hasPower = false;
        PowerColorChange();
    }
}
