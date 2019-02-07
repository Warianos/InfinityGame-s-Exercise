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
    private GameObject[] gridChildren;
    ////////////////////////////////////////////possible cell types 
    
    [SerializeField]
    private GameObject Cell;

    [SerializeField]
    private GameObject EmptyCell;


    //resources sprites texture
    Sprite[] sprites;

    public GameObject[] Grid
    {
        get
        {
            return grid;
        }

        set
        {
            grid = value;
        }
    }

    void Awake () {
        
        //Check if instance already exists
        if (instance == null)
            instance = this;
        //If instance already exists and it's not this:
        else if (instance != this)
            Destroy(gameObject);
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        

        //Call the InitGame function to initialize the first level 
        
        gridPanel = GameObject.FindGameObjectWithTag("GridPanel").transform;
        //Grid = new GameObject[(int)gridSize.x * (int)gridSize.y];
        //for (int i =0;i < gridSize.x * gridSize.y; i++)
        //{
          //  Grid[i] = gridPanel.GetChild(i).gameObject;
        //}
        sprites = Resources.LoadAll<Sprite>("Textures/InfinityGamesExercise");
        PopulateGridArray(3);
        //InstantiateGridArray(ref grid);
        Debug.Log(sprites.Length);
        //DestroyCellsInArray(ref grid);
    }
	
	
	void Update () {
		
	}

    //gerar niveis diferentes consoante a dificuldade, neste caso vai ser consoante os packs de niveis para serem guardados em scriptable object
    private void PopulateGridArray(int difficulty)
    {
        
        
        Debug.Log(Grid);
        int rand = 0;
        for (int x = 0; x < grid.Length; x++) //mudar isto mais tarde para generico
        {
            
            
            
            rand = Random.Range(0, 3);
            Debug.Log(rand);

            if (rand == 0)
            {

                Grid[x].transform.Find("CellImage").GetComponent<Image>().color = new Color(0,0,0,0);
                Grid[x].GetComponent<Cell>().CurrentPos = x;
                Grid[x].GetComponent<Cell>().IsEmpty = true;
            }

            else if(rand == 1)
            {
                
                Grid[x].transform.Find("CellImage").GetComponent<Image>().sprite = sprites[1];
                Grid[x].GetComponent<Cell>().CurrentPos = x;
                Grid[x].GetComponent<Cell>().IsEmpty = false;

            }
            else if (rand == 2)
            {
                
                Grid[x].transform.Find("CellImage").GetComponent<Image>().sprite = sprites[10];
                Grid[x].GetComponent<Cell>().CurrentPos = x;
                Grid[x].GetComponent<Cell>().IsEmpty = false;
            }

            Grid[x].transform.SetParent(gridPanel);
        }


        
     
    }

    public void UpdateSlots(Transform slotPanel,int currentPos, int finalPos)
    {
        GameObject tempSlot = Grid[currentPos];
        Grid[currentPos].transform.Find("CellImage").GetComponent<Image>().sprite = Grid[finalPos].transform.Find("CellImage").GetComponent<Image>().sprite;
        Grid[finalPos].transform.Find("CellImage").GetComponent<Image>().sprite = tempSlot.transform.Find("CellImage").GetComponent<Image>().sprite;
    }
    //instantiate objects from scriptable objects
    private void InstantiateGridArray(ref GameObject[] grid)
    {
        Debug.Log("Created");
        
        for (int x = 0; x < (int)gridSize.x * (int)gridSize.y; x++)
        {
            // instantiate that cell into a new gameobject in order to be a child of a transform prefab.
            GameObject cell = Instantiate(grid[x]);
            cell.transform.SetParent(gridPanel);
        }
        
    }
    //destroy objects from scriptable objects
    private void DestroyCellsInArray(ref GameObject[] grid)
    {
        Debug.Log("Destroyed");
        //obter os filhos do canvas e chamar o die de cada um correspondente
        if (gridPanel.childCount > 0)
        {
            foreach (Transform child in gridPanel.transform)
            {
                if (child.GetComponent<Cell>() != null)
                {
                    child.GetComponent<Cell>().Die();
                }
            }
        }
       
        

    }


    
}
