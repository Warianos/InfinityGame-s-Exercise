using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GridGenerator : MonoBehaviour {

    //grid variables
    [SerializeField]
    private Vector2 gridSize;
    private GameObject[] grid;

    ////////////////////////////////////////////canvas cell container
    [SerializeField]
    private Transform gridPanel;
    private GameObject[] gridChildren;
    ////////////////////////////////////////////possible cell types 
    
    [SerializeField]
    private GameObject emptyCell;
    /*
    [SerializeField]
    private GameObject PowerCell0;
    [SerializeField]
    private GameObject PowerCell90;
    [SerializeField]
    private GameObject PowerCell180;
    [SerializeField]
    private GameObject PowerCell270;
    [SerializeField]
    private GameObject LampCell0;
    [SerializeField]
    private GameObject LampCell90;
    [SerializeField]
    private GameObject LampCell180;
    [SerializeField]
    private GameObject LampCell270;
    [SerializeField]
    private GameObject H2WayConnection;
    [SerializeField]
    private GameObject V2WayConnection;
    [SerializeField]
    private GameObject WayConnection4;
    */

    //resources sprites texture
    Sprite[] sprites;
    void Awake () {
        sprites = Resources.LoadAll<Sprite>("Textures/InfinityGamesExercise");
        PopulateGridArray(3);
        InstantiateGridArray(ref grid);
        Debug.Log(sprites.Length);
        //DestroyCellsInArray(ref grid);
    }
	
	
	void Update () {
		
	}

    //gerar niveis diferentes consoante a dificuldade, neste caso vai ser consoante os packs de niveis para serem guardados em scriptable object
    private void PopulateGridArray(int difficulty)
    {
        
        grid = new GameObject[(int)gridSize.x * (int)gridSize.y];
        Debug.Log(grid);
        for (int x = 0; x < (int)gridSize.x * (int)gridSize.y; x++)
        {
            
            grid[x] = emptyCell;
            int rand = Random.Range(0, 1);
            if(rand == 0)
            {
                grid[x].transform.GetChild(0).GetComponent<Image>().sprite = sprites[1];
            }
            else if(rand == 1)
            {
                grid[x].transform.GetChild(0).GetComponent<Image>().sprite = sprites[10];
            }
            
            
        }

        
       /* switch (difficulty)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
            */
    }
    //instantiate objects from scriptable objects
    private void InstantiateGridArray(ref GameObject[] grid)
    {
        Debug.Log("Created");
        
        for (int x = 0; x < (int)gridSize.x * (int)gridSize.y; x++)
        {
            // instantiate that cell into a new gameobject in order to be a child of a transform.
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
