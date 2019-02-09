using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCell90 : Cell {

    void Awake()
    {
        HasPower = true;
        CellType = Type.PowerCell90;
    }
}
