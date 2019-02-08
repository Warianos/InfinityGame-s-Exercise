using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2WayConnectionCell : Cell {

    public override void CheckIfConnectedCellHasPower()
    {
        int currentPos = CurrentPos;
        
        Transform left = transform.parent.GetChild(currentPos - 1);
        Transform right = transform.parent.GetChild(currentPos + 1);
        for (int i = 0; i < 4; i++)
        {
            if (left != null)
            {
                if (left.GetComponent<Cell>().HasPower) HasPower = true;
                PowerColorChange();
                return;
            }
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
}
