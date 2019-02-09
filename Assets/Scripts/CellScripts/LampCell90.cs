using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampCell90 : Cell {

    void Awake()
    {
        CellType = Type.LampCell90;
        CellAnimator = GetComponent<Animator>();
    }
    public override void CheckIfConnectedCellHasPower()
    {
        int currentPos = CurrentPos;



        Transform up;
        

        
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
      
        hasPower = false;
        PowerColorChange();

    }
}
