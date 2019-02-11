using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour {

    [SerializeField]
    private Transform worldPanel;
    [SerializeField]
    private Transform worldLevelPanel;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void LoadBoard(int level)
    {
        foreach (Level levelTemp in GameManager.instance.LevelList)
        {
            if (levelTemp.LevelNumber == level)
            {
                worldPanel.gameObject.SetActive(false);
                worldLevelPanel.gameObject.SetActive(false);
                GridManager.instance.DestroyCellsInPanel();
                GridManager.instance.loadGrid(levelTemp);
            }


        }
    }
}
