using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    protected bool hasPower;
    
    public enum Type
    {
        LampCell0,
        LampCell90,
        LampCell180,
        LampCell270,
        PowerCell0,
        PowerCell90,
        PowerCell180,
        PowerCell270,
        V2Way,
        H2Way,
        Way4
    };

    public Type cellType;

    private int currentPos;

    private bool isEmpty;

    private Animator cellAnimator;

    

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

    protected Type CellType
    {
        get
        {
            return cellType;
        }

        set
        {
            cellType = value;
        }
    }

    public Animator CellAnimator
    {
        get
        {
            return cellAnimator;
        }

        set
        {
            cellAnimator = value;
        }
    }

    //public virtual void VerifyConnection() { }
    public virtual void NoPowerColorChange() { }

    public virtual void PowerColorChange() {
        if (hasPower)
        {
            CellAnimator.SetBool("hasPower", true);
        }
        else
        {
            CellAnimator.SetBool("hasPower", false);
        }


    }
    public virtual void CheckIfConnectedCellHasPower() {} //cada tipo de cell tem a sua forma de verificar se a celula perto está com power ou não.
    public void Die() {
        Destroy(gameObject);
    }
	
	
}
