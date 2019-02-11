using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    
    public static GameManager instance = null;
    //private BoardManager grid;

    [SerializeField]
    LevelDataBase levelDatabase;

    List<Level> levelList;

    public Transform worldPanel;
    public Transform worldLevelPanel;

    private const string LEVEL_DATABASE_PATH = @"Assets/Resources/Databases/levelDatabase.asset";
    private int actualLevel;
    private Transform gridPanel;
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

    public LevelDataBase LevelDatabase
    {
        get
        {
            return levelDatabase;
        }

        set
        {
            levelDatabase = value;
        }
    }

    public List<Level> LevelList
    {
        get
        {
            return levelList;
        }

        set
        {
            levelList = value;
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

        gridPanel = GameObject.FindGameObjectWithTag("GridPanel").transform;

        //if (LevelDatabase == null)
        //{
        //    LevelDatabase = Resources.Load("Databases/levelDatabase", typeof(LevelDataBase)) as LevelDataBase;

        //    if(levelDatabase == null)
        //    {
        //        CreateLevelFile();
        //        LevelDatabase = Resources.Load("Databases/levelDatabase", typeof(LevelDataBase)) as LevelDataBase;
        //    }
        //}

        //its here only for cheking if it´s works as it should, since the random generator has bugs.
        levelList = new List<Level>();

        List<int> level1IntList = new List<int>{0,0,0,0,0,0,0,1,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,
            0,0,0,0,0,0,0};
        List<int> level2IntList = new List<int>{9,0,9,0,0,0,0,1,0,0,0,0,0,7,0,0,0,0,0,5,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,0,0,10,0,6,0,0,0,0,0,0,10,0,0,0,0,0,
            0,0,0,0,0,0,0,
            0,0,0,0,0,0,0};
        Level level1 = new Level(1, 1, level1IntList,2);
        Level level2 = new Level(1, 2, level2IntList,10);
        levelList.Add(level1);
        levelList.Add(level2);
        actualLevel = 1;
        DontDestroyOnLoad(gameObject);
        //adicionar alguns scripts que necessitar aqui como o boardmanager
    }
    void Start()
    {
        //CreateDatabase(this.LevelDatabase, LEVEL_DATABASE_PATH);
        //GridManager.instance.PopulateGrid(0);
       // InitGame();
    }
	//void InitGame () {
 //       GridManager.instance.loadGrid(levelDatabase.LevelDatabase[0]);

 //   }
	
	

   

    public bool winningCondition(int level)
    {
        int numberOfCellWPower = 0;
        foreach (Level levelTemp in LevelList)
        {
            if (levelTemp.LevelNumber == level)
            {
                foreach (Transform cell in gridPanel.transform)
                {
                    if(cell != null)
                    {
                        if (cell.GetComponent<Cell>().HasPower) numberOfCellWPower++;
                        if (numberOfCellWPower == levelTemp.NumberOfLights) return true;
                    }
                
                }

            }


        }
        return false;
    }

    public void RefreshPlayerStatus()
    {
        int i = 0;
        foreach(Transform lvl in worldLevelPanel)
        {
            i++;
            if((i <= actualLevel)){
                lvl.GetComponent<Button>().interactable = true;
            }
        }
        GridManager.instance.DestroyCellsInPanel();
        worldPanel.gameObject.SetActive(true);
        foreach(Transform world in worldPanel)
        {
            world.gameObject.SetActive(true);
        }
        actualLevel ++;
    }

}
    
    

    //void CreateDatabase<LevelDataBase>(LevelDataBase database, string path) where LevelDataBase : ScriptableObject
    //{
    //    database = ScriptableObject.CreateInstance<LevelDataBase>();
    //    AssetDatabase.CreateAsset(database, path);
    //    AssetDatabase.SaveAssets();
    //    AssetDatabase.Refresh();
    //}

    //public void CreateLevelFile()
    //{
        
    //    CreateDatabase(this.LevelDatabase, LEVEL_DATABASE_PATH);
    //}

