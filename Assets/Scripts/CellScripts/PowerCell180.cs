using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCell180 : Cell {

    public override void CheckIfConnectedCellHasPower()
    {
        int currentPos = CurrentPos;
        Transform left = transform.parent.GetChild(currentPos - 1);
        
            if (left != null)
            {
                if (left.GetComponent<Cell>().HasPower) HasPower = true;
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
