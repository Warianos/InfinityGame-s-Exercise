﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2WayConnectionCell : Cell {
    void Awake()
    {

        CellType = Type.H2Way;
        CellAnimator = GetComponent<Animator>();
    }

    public override void CheckIfConnectedCellHasPower()
    {
        int currentPos = CurrentPos;


        Transform left;
        Transform right;

        
        int gridWidth = (int)GridManager.instance.GridSize.x;

       
        if ((currentPos + 1) % gridWidth != 0) // if the position im current at is not divided by 7 at the righ
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
