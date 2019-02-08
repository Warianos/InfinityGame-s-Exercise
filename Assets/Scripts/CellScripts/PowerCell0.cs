using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCell0 : Cell {

    public override void CheckIfConnectedCellHasPower()
    {
        int currentPos = CurrentPos;
        Transform right = transform.parent.GetChild(currentPos + 1);
        
            if (right != null)
            {
                if (right.GetComponent<Cell>().HasPower) HasPower = true;
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
