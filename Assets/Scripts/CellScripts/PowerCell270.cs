using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCell270 : Cell {

    public override void CheckIfConnectedCellHasPower()
    {
        int currentPos = CurrentPos;
        Transform down = transform.parent.GetChild(currentPos - 7);

        if (down != null)
        {
            if (down.GetComponent<Cell>().HasPower) HasPower = true;
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
