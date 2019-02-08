using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    protected bool hasPower;

    private int currentPos;

    private bool isEmpty;

    public bool HasPower
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
    public virtual void CheckIfConnectedCellHasPower() {} //cada tipo de cell tem a sua forma de verificar se a celula perto está com power ou não.
    public void Die() {
        Destroy(gameObject);
    }
	
	
}
