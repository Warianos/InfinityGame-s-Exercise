using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampCell180 : Cell {

    void Awake()
    {
        CellType = Type.LampCell180;
        CellAnimator = GetComponent<Animator>();
    }

    public override void CheckIfConnectedCellHasPower()
    {
        int currentPos = CurrentPos;
        Transform left;

        
        int gridWidth = (int)GridManager.instance.GridSize.x;

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
