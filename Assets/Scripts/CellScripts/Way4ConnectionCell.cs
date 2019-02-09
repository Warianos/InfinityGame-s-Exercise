using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way4ConnectionCell : Cell {

    void Awake()
    {

        cellType = Type.Way4;
        CellAnimator = GetComponent<Animator>();
    }

    public override void CheckIfConnectedCellHasPower()
    {
        int currentPos = CurrentPos;

        

        Transform up;
        Transform down;
        Transform left;
        Transform right;

        int gridSize = (int)GridManager.instance.GridSize.x * (int)GridManager.instance.GridSize.y;
        int gridWidth = (int)GridManager.instance.GridSize.x;

        if ((currentPos - gridWidth) >=0)
        {
            up = transform.parent.GetChild(currentPos - gridWidth);
            if (up.GetComponent<Cell>().HasPower) 
            {
                if(up.GetComponent<Cell>().cellType == Type.Way4 || 
                   up.GetComponent<Cell>().cellType == Type.LampCell270 || 
                   up.GetComponent<Cell>().cellType == Type.PowerCell270 ||
                   up.GetComponent<Cell>().cellType == Type.V2Way)
                {
                    
                    HasPower = true;
                    PowerColorChange();
                    //up.GetComponent<Cell>().CheckIfConnectedCellHasPower();
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
                    //down.GetComponent<Cell>().CheckIfConnectedCellHasPower();
                    return;
                }
            }
        }
        if ((currentPos + 1 ) % gridWidth != 0) // if the position im current at is not divided by 7 at the righ
        {
            right = transform.parent.GetChild(currentPos + 1);
            if (right.GetComponent<Cell>().HasPower) 
            {
                if (right.GetComponent<Cell>().cellType == Type.Way4 ||
                    right.GetComponent<Cell>().cellType == Type.LampCell180 ||
                    right.GetComponent<Cell>().cellType == Type.PowerCell180 ||
                    right.GetComponent<Cell>().cellType == Type.H2Way)
                {
                    
                    HasPower = true;
                    PowerColorChange();
                    //right.GetComponent<Cell>().CheckIfConnectedCellHasPower();
                    return;
                }
            }
        }
        if ((currentPos) % gridWidth != 0) // if the position im current at is not divided by 7 at the left
        {
            left = transform.parent.GetChild(currentPos - 1);
            if (left.GetComponent<Cell>().HasPower) 
            {
                if (left.GetComponent<Cell>().cellType == Type.Way4 ||
                    left.GetComponent<Cell>().cellType == Type.LampCell0 ||
                    left.GetComponent<Cell>().cellType == Type.PowerCell0 ||
                    left.GetComponent<Cell>().cellType == Type.H2Way)
                {
                    
                    HasPower = true;
                    PowerColorChange();
                    //left.GetComponent<Cell>().CheckIfConnectedCellHasPower();
                    return;
                }
            }
        }
        hasPower = false;
        PowerColorChange();
        
        
    }
}
