using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    
    public static GameManager instance = null;
    //private BoardManager grid;
    private int actualLevel;

    public int ActualLevel
    {
        get
        {
            return actualLevel;
        }

        set
        {
            actualLevel = value;
        }
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        //adicionar alguns scripts que necessitar aqui como o boardmanager
    }
	void InitGame () {
		//adicionar aqui a iniciação da grid e ler o primeiro nivel
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetupBoard(int level)
    {

    }
}
