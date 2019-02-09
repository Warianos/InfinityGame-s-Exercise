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

    public Vector2 GridSize
    {
        get
        {
            return gridSize;
        }

        set
        {
            gridSize = value;
        }
    }

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
    void Start()
    {
        //UpdateCells();
        
        //UpdateCells();
        InvokeRepeating("UpdateCells", 0, 0.25f);
    }

    void Update()
    {
        //InvokeRepeating("UpdateCells", 0, 2);
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
        for (int x = 0; x < (int)GridSize.x * (int)GridSize.y; x++)
        {
            rand = Random.Range(0, 12);
            GameObject cell = Instantiate(grid[rand]);
            if (rand == 0){ //é empty
                cell.GetComponent<Cell>().IsEmpty = true;
            }
            cell.GetComponent<Cell>().CurrentPos = x;
            cell.name = "Cell" + x;
            cell.transform.SetParent(gridPanel);
            
            Debug.Log(cell.GetComponent<Cell>().CurrentPos);
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

    public void UpdateCells()
    {
        foreach(Transform cell in gridPanel.transform)
        {
            //Debug.Log(cell.GetComponent<Cell>().CellAnimator);
            if (cell != null)
            {
                if (cell.GetComponent<Cell>().cellType != Cell.Type.PowerCell0 &&
                   cell.GetComponent<Cell>().cellType != Cell.Type.PowerCell90 &&
                   cell.GetComponent<Cell>().cellType != Cell.Type.PowerCell180 &&
                   cell.GetComponent<Cell>().cellType != Cell.Type.PowerCell270)
                {


                    cell.GetComponent<Cell>().CheckIfConnectedCellHasPower();

                }
            }
            
        }
    }
    
}
