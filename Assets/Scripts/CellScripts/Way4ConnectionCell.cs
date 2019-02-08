using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way4ConnectionCell : Cell {

	public override void CheckIfConnectedCellHasPower()
    {
        int currentPos = CurrentPos;
        Transform up = transform.parent.GetChild(currentPos - 7);
        Transform down = transform.parent.GetChild(currentPos + 7);
        Transform left = transform.parent.GetChild(currentPos - 1);
        Transform right = transform.parent.GetChild(currentPos + 1);
        for (int i = 0 ; i < 4 ; i++)
        {
            if(up != null)
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
