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

    [SerializeField]
    private Transform worldPanel;
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

        gridPanel = GameObject.FindGameObjectWithTag("GridPanel").transform;

        //EasyGridGenerator2(1);



        InitGame();


        //sprites = Resources.LoadAll<Sprite>("Textures/InfinityGamesExercise");


    }
    void Start()
    {
        //UpdateCells();
        //InitGame();
        //UpdateCells();
        //loadGrid(GameManager.instance.LevelDatabase.LevelDatabase[0]);
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
    
    
    public void PopulateGrid(int difficulty)
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
                EasyGridGenerator(1);
                break;
            case 1:
                NormalGridGenerator(5);
                break;
            case 2:
                HardGridGenerator(2);
                break;
        }
    }

    private void EasyGridGenerator(int numberOfLevels)
    {
        
        int rand = 0;
        
        for(int i = 0; i<= numberOfLevels;i++)
        {
            Level level;
            List<int> cellTypeList = new List<int>();
            Debug.Log("Created");
            for (int x = 0; x < (int)GridSize.x * (int)GridSize.y; x++)
            {
                rand = Random.Range(0, 12);
                cellTypeList.Add(rand);
                
                

               
            }
            level = new Level(1, 3, cellTypeList,0);
            GameManager.instance.LevelList.Add(level);
        }

        //Debug.Log(GameManager.instance.LevelDatabalevelList.Count);

    }

    private void EasyGridGenerator2(int numberOfLevels)
    {

        int maxNumberOfEnergy = 1;
        int maxNumberOf4Way = 1;
        int maxNumberOf2HWay = 3;
        int maxNumberOf2VWay = 3;
        int maxNumberOfLamps = 3;
       

        int numberOfEnergyRand = Random.Range(1, maxNumberOfEnergy);
        int numberOf4WayRand = Random.Range(0, maxNumberOf4Way + 1);
        int numberOf2HWayRand = 0;
        int numberOf2VWayRand = 0;
        int numberOfLampsRand = 1;
        int numberOfEmpties = 0;

        float emptyChance = 0;
        float energyChance = 0;
        float way4Chance = 0; 
        float h2Way = 0;
        float v2Way = 0;
        float lampChance = 0;
        float gridSize = GridSize.x * GridSize.y;

        int numberOfObjectsToLight = 0;

        int randomLocal = 0;

        for (int i = 0; i < numberOfLevels; i++)
        {
            
            numberOfEnergyRand = Random.Range(1, maxNumberOfEnergy);
            numberOf4WayRand = Random.Range(0, maxNumberOf4Way + 1);
            numberOf2HWayRand = 0;
            numberOf2VWayRand = 0;
            numberOfLampsRand = 1;
            numberOfEmpties = 0;

            
            energyChance = (numberOfEnergyRand / gridSize);
            way4Chance = numberOf4WayRand / gridSize;
            

            if (numberOf4WayRand > 0)
            {
                
                numberOfLampsRand = Random.Range(1, maxNumberOfLamps + 1);
                numberOf2HWayRand = Random.Range(0, maxNumberOf2HWay + 1);
                numberOf2VWayRand = Random.Range(0, maxNumberOf2VWay + 1);

            }
            else
            {
                randomLocal = Random.Range(0, 3);
                if(randomLocal == 0)
                {
                    numberOf2HWayRand = Random.Range(0, maxNumberOf2HWay + 1);
                    numberOf2VWayRand = 0;
                }
                else
                {
                    numberOf2HWayRand = 0;
                    numberOf2VWayRand = Random.Range(0, maxNumberOf2VWay + 1);
                }
                
                numberOfLampsRand = 1;
            }

            numberOfObjectsToLight = numberOfEnergyRand + numberOf4WayRand + numberOf2HWayRand + numberOf2VWayRand + numberOfLampsRand;
            h2Way = numberOf2HWayRand / gridSize;
            v2Way = numberOf2VWayRand / gridSize;
            lampChance = numberOfLampsRand / gridSize;
            numberOfEmpties = (int)gridSize - numberOfObjectsToLight;
            emptyChance = numberOfEmpties / gridSize;


            //Debug.Log("Created");
            //Debug.Log("gridSize: " + gridSize);
            //Debug.Log("randomLocal: " + randomLocal);

            Debug.Log("numberOfEnergyRand: " + numberOfEnergyRand.ToString("F10"));
            Debug.Log("numberOf4WayRand: " + numberOf4WayRand.ToString("F10"));
            Debug.Log("numberOf2HWayRand: " + numberOf2HWayRand.ToString("F10"));
            Debug.Log("numberOf2VWayRand: " + numberOf2VWayRand.ToString("F10"));
            Debug.Log("numberOfLampsRand: " + numberOfLampsRand.ToString("F10"));


            //Debug.Log("energyChance: " + energyChance.ToString("F10"));
            //Debug.Log("way4Chance: " + way4Chance.ToString("F10"));
            //Debug.Log("h2Way: " + h2Way.ToString("F10"));
            //Debug.Log("v2Way: " + v2Way.ToString("F10"));
            //Debug.Log("lampChance: " + lampChance.ToString("F10"));
            //Debug.Log("emptyChance: " + emptyChance.ToString("F10"));

            //Debug.Log("numberOfObjectsToLight: " + numberOfObjectsToLight);

            float rand = 0;
            Level level;
            List<int> cellTypeList = new List<int>();
            List<int> specialCells = new List<int>();
            
            
            for (int x = 0; x < ((int)GridSize.x * (int)GridSize.y); x++)
            {
                
                energyChance = (numberOfEnergyRand / gridSize);
                way4Chance = numberOf4WayRand / gridSize;
                h2Way = numberOf2HWayRand / gridSize;
                v2Way = numberOf2VWayRand / gridSize;
                lampChance = numberOfLampsRand / gridSize;
                emptyChance = (gridSize - numberOfObjectsToLight) / gridSize;

                //Debug.Log("energyChance: " + energyChance.ToString("F10"));
                //Debug.Log("way4Chance: " + way4Chance.ToString("F10"));
                //Debug.Log("h2Way: " + h2Way.ToString("F10"));
                //Debug.Log("v2Way: " + v2Way.ToString("F10"));
                //Debug.Log("lampChance: " + lampChance.ToString("F10"));
                //Debug.Log("emptyChance: " + emptyChance.ToString("F10"));

                rand = Random.Range(0, 1.0f);
                //Debug.Log("Random: " + rand);
                if (numberOf4WayRand > 0)
                {
                    if(rand <= way4Chance)
                    {
                        cellTypeList.Add(11);
                        specialCells.Add(11);
                        numberOf4WayRand--;
                        gridSize--;
                        //Debug.Log("Entrei no way4 com chance de" + rand);
                        continue;
                    }

                }
                if (numberOfEnergyRand > 0)
                {
                    if (rand <= energyChance)
                    {
                        int randomPower = 0;
                        if (numberOf2HWayRand > 0)
                        {
                            randomPower = Random.Range(1, 3);
                            if(randomPower == 1)
                            {
                                cellTypeList.Add(1);
                                specialCells.Add(1);
                                numberOfEnergyRand--;
                                gridSize--;
                                //Debug.Log("Entrei no energyChance com chance de" + rand);
                                continue;
                            }
                            if (randomPower == 2)
                            {
                                cellTypeList.Add(3);
                                specialCells.Add(3);
                                numberOfEnergyRand--;
                                gridSize--;
                                //Debug.Log("Entrei no energyChance com chance de" + rand);
                                continue;
                            }

                        }
                        if(numberOf2VWayRand > 0)
                        {
                            randomPower = Random.Range(1, 3);
                            if (randomPower == 1)
                            {
                                cellTypeList.Add(2);
                                specialCells.Add(2);
                                numberOfEnergyRand--;
                                gridSize--;
                                //Debug.Log("Entrei no energyChance com chance de" + rand);
                                continue;
                            }
                            if (randomPower == 2)
                            {
                                cellTypeList.Add(4);
                                specialCells.Add(4);
                                numberOfEnergyRand--;
                                gridSize--;
                                //Debug.Log("Entrei no energyChance com chance de" + rand);
                                continue;
                            }
                        }
                       
                    }

                }
                if (numberOf2HWayRand > 0)
                {
                    Debug.Log("h2Way" + (rand <= h2Way));
                    if (rand <= h2Way && (specialCells.Contains(1) || specialCells.Contains(3) || specialCells.Contains(11)))
                    {
                        cellTypeList.Add(9);
                        numberOf2HWayRand--;
                        gridSize--;
                        //Debug.Log("Entrei no 2HWay com chance de" + rand);
                        continue;
                    }
                }
                if (numberOf2VWayRand > 0)
                {
                    Debug.Log("v2Way" + (rand <= v2Way));
                    if (rand <= v2Way && (specialCells.Contains(2) || specialCells.Contains(4) || specialCells.Contains(11)))
                    {

                        cellTypeList.Add(10);
                        numberOf2VWayRand--;
                        gridSize--;
                        //Debug.Log("Entrei no 2VWay com chance de" + rand);
                        continue;
                    }

                }
                if (numberOfLampsRand > 0)
                {
                   // Debug.Log("Entrei no Lamps com chance de" + rand);
                    if (rand <= lampChance && specialCells.Contains(1) && specialCells.Contains(7) == false)
                    {
                       // Debug.Log("Entrei no Lamps com chance de" + rand);
                        specialCells.Add(7);
                        cellTypeList.Add(7);
                        numberOfLampsRand--;
                        gridSize--;
                        continue;

                    }
                    if (rand <= lampChance && specialCells.Contains(2) && specialCells.Contains(8) == false)
                    {
                        //Debug.Log("Entrei no Lamps com chance de" + rand);
                        specialCells.Add(8);
                        cellTypeList.Add(8);
                        numberOfLampsRand--;
                        gridSize--;
                        continue;
                    }

                    if (rand <= lampChance && specialCells.Contains(3) && specialCells.Contains(5) == false)
                    {
                        //Debug.Log("Entrei no Lamps com chance de" + rand);
                        specialCells.Add(5);
                        cellTypeList.Add(5);
                        numberOfLampsRand--;
                        gridSize--;
                        continue;
                    }

                    if (rand <= lampChance && specialCells.Contains(4) && specialCells.Contains(6) == false)
                    {
                        //Debug.Log("Entrei no Lamps com chance de" + rand);
                        specialCells.Add(6);
                        cellTypeList.Add(6);
                        numberOfLampsRand--;
                        gridSize--;
                        continue;
                    }

                }
                if (numberOfEmpties > 0)
                {
                    cellTypeList.Add(0);
                    //Debug.Log("Entrei no Empty com chance de" + rand);
                    //numberOfLampsRand--;
                    gridSize--;
                    numberOfEmpties--;
                    //continue;
                }
                








            }
            Debug.Log("contemPower 1?: " + specialCells.Contains(1));
            Debug.Log("contemPower 2?: " + specialCells.Contains(2));
            Debug.Log("contemPower 3?: " + specialCells.Contains(3));
            Debug.Log("contemPower 4?: " + specialCells.Contains(4));
            Debug.Log("contemPower 11?: " + specialCells.Contains(11));
            //level = new Level(1, i, cellTypeList);
           // GameManager.instance.LevelDatabase.LevelDatabase.Add(level);
            
        }


        /*

                for (int i = 0; i <= numberOfLevels; i++)
                {
                    Level level;
                    List<int> cellTypeList = new List<int>();
                    Debug.Log("Created");
                    for (int x = 0; x < (int)GridSize.x * (int)GridSize.y; x++)
                    {
                        rand = Random.Range(0, 12);
                        cellTypeList.Add(rand);




                    }
                    //level = new Level(1, i, cellTypeList);
                    //GameManager.instance.LevelDatabase.LevelDatabase.Add(level);
                }


            */
    }

    public void loadGrid(Level level)
    {
        List<int> gridLevel = level.LevelGrid;
        
        GameObject cell;
        int currentPos = 0;
        Debug.Log("entrei");
        foreach (int cellType in gridLevel)
        {
            
            cell = Instantiate(grid[cellType]);
            if (cellType == 0)
            { //é empty
                cell.GetComponent<Cell>().IsEmpty = true;
            }
            cell.GetComponent<Cell>().CurrentPos = currentPos;
            cell.name = "Cell" + currentPos;
            cell.transform.SetParent(gridPanel);
            currentPos++;


        }
    }


    private void NormalGridGenerator(int numberOfLevels)
    {

    }

    private void HardGridGenerator(int numberOfLevels)
    {

    }
    
    public void DestroyCellsInPanel()
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
            if (cell.GetComponent<Animator>() != null)
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
