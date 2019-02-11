using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagersLoader : MonoBehaviour
{

    public GameObject gameManager;          //GameManager prefab to instantiate.
    public GameObject gridManager;
           //SoundManager prefab to instantiate.


    void Awake()
    {
        /*
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (GameManager.instance == null)

            //Instantiate gameManager prefab
            Instantiate(gameManager);
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (GridManager.instance == null)

            //Instantiate gameManager prefab
            Instantiate(gridManager);
*/

    }
}
