using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    private bool hasPower;

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

    //public virtual void VerifyConnection() { }
    public virtual void NoPowerColorChange() { }
    public virtual void PowerColorChange() { }
    public void Die() {
        Destroy(gameObject);
    }
	
	
}
