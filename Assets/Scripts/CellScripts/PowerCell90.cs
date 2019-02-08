using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCell90 : Cell {

    public override void CheckIfConnectedCellHasPower()
    {
        int currentPos = CurrentPos;
        Transform up = transform.parent.GetChild(currentPos - 7);
        
            if (up != null)
            {
                if (up.GetComponent<Cell>().HasPower) HasPower = true;
                PowerColorChange();
                return;
            }
            else
            {
                HasPower = false;
                PowerColorChange();
            }
        
    }
}
