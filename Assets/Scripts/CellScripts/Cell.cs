using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    private bool hasPower;

    private int currentPos;

    private bool isEmpty;

    protected bool HasPower
    {
        get
        {
            return hasPower;
        }

        set
        {
            hasPower = value;
        }
    }

    public int CurrentPos
    {
        get
        {
            return currentPos;
        }

        set
        {
            currentPos = value;
        }
    }

    public bool IsEmpty
    {
        get
        {
            return isEmpty;
        }

        set
        {
            isEmpty = value;
        }
    }

    //public virtual void VerifyConnection() { }
    public virtual void NoPowerColorChange() { }
    public virtual void PowerColorChange() { }
    public void Die() {
        Destroy(gameObject);
    }
	
	
}
