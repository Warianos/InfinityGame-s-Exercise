using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2WayConnectionCell : Cell
{
    public override void CheckIfConnectedCellHasPower()
    {
        int currentPos = CurrentPos;
        Transform up = transform.parent.GetChild(currentPos - 7);
        Transform down = transform.parent.GetChild(currentPos + 7);
        for (int i = 0; i < 4; i++)
        {
            if (up != null)
            {
                if (up.GetComponent<Cell>().HasPower) HasPower = true;
                PowerColorChange();
                return;
            }
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
}
