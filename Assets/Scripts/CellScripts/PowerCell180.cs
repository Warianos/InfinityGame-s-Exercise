using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCell180 : Cell {

    void Awake()
    {
        HasPower = true;
        CellType = Type.PowerCell180;
    }
}
