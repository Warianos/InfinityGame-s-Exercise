using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampCell0 : Cell {

    void Awake()
    {
        CellType = Type.LampCell0;
        CellAnimator = GetComponent<Animator>();
    }

    public override void CheckIfConnectedCellHasPower()
    {
        int currentPos = CurrentPos;



        
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
    
        hasPower = false;
        PowerColorChange();

    }
}
