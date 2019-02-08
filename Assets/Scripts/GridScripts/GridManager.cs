using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GridManager : MonoBehaviour {


    public static GridManager instance = null; 

    //grid variables
    [SerializeField]
    private Vector2 gridSize;
    [SerializeField]
    private GameObject[] grid;

    ////////////////////////////////////////////canvas cell container
    [SerializeField]
    private Transform gridPanel;
    //private GameObject[] gridChildren;
    ////////////////////////////////////////////possible cell types 
    
    
    /*
    [SerializeField]
    private GameObject EmptyCell;

    [SerializeField]
    private GameObject Power0Cell;

    [SerializeField]
    private GameObject Power90Cell;

    [SerializeField]
    private GameObject Power180Cell;

    [SerializeField]
    private GameObject Power270Cell;

    [SerializeField]
    private GameObject Lamp0Cell;

    [SerializeField]
    private GameObject Lamp90Cell;

    [SerializeField]
    private GameObject Lamp180Cell;

    [SerializeField]
    private GameObject Lamp270Cell;

    [SerializeField]
    private GameObject WayH2ConnectionCell;

    [SerializeField]
    private GameObject WayV2ConnectionCell;

    [SerializeField]
    private GameObject Way4ConnectionCell;


    */

    //resources sprites texture
    Sprite[] sprites;

  

    void Awake () {
        
        
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);



        InitGame();
        
       
     
   

    //sprites = Resources.LoadAll<Sprite>("Textures/InfinityGamesExercise");
        
        
    }



    private void InitGame()
    {
        PopulateGrid(0);
    }
    
    
    private void PopulateGrid(int difficulty)
    {
        if(gridPanel.childCount > 0)
        {
            DestroyCellsInPanel();
        }
        else
        {
            CreateGrid(difficulty);
        }
    }
    
    private void CreateGrid(int difficulty)
    {

        switch (difficulty)
        {
            case 0:
                EasyGridGenerator();
                break;
            case 1:
                NormalGridGenerator();
                break;
            case 2:
                HardGridGenerator();
                break;
        }
    }

    private void EasyGridGenerator()
    {
        Debug.Log("Created");
        int rand = 0;
        for (int x = 0; x < (int)gridSize.x * (int)gridSize.y; x++)
        {
            rand = Random.Range(0, 12);
            GameObject cell = Instantiate(grid[rand]);
            if (rand == 0){ //é empty
                cell.GetComponent<Cell>().IsEmpty = true;
            }
            cell.name = "Cell" + x;
            cell.transform.SetParent(gridPanel);
        }
    }

    private void NormalGridGenerator()
    {

    }

    private void HardGridGenerator()
    {

    }
    
    private void DestroyCellsInPanel()
    {
        Debug.Log("Destroyed");
        //obter os filhos do canvas e chamar o die de cada um correspondente
        
            foreach (Transform child in gridPanel.transform)
            {
                if (child.GetComponent<Cell>() != null)
                {
                    child.GetComponent<Cell>().Die();
                }
            }
        
       
        

    }


    
}
