using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DatabaseHandler : MonoBehaviour {

 //   // Use this for initialization

 //   GameManager gameManager;
 //   public static DatabaseHandler instance = null;
    

 //   void Awake()
 //   {
 //       if (instance == null)
 //       {
 //           instance = this;
 //       }
 //       else if (instance != this)
 //       {
 //           Destroy(gameObject);
 //       }
 //   }

 //   void Start () {
 //       //gameManager = GameManager.instance;
        

 //   }
	
	//// Update is called once per frame
	//void Update () {
		
	//}

 //   void LoadDatabase<LevelDataBase>(LevelDataBase database, string path) where LevelDataBase : ScriptableObject
 //   {

 //       //database = (LevelDataBase)AssetDatabase.LoadAssetAtPath(path, typeof(LevelDataBase));

 //       //if (database == null)
 //       //    CreateDatabase<T>(ref database, path);
 //   }

 //   void CreateDatabase<LevelDataBase>(LevelDataBase database, string path) where LevelDataBase : ScriptableObject
 //   {
 //       database = ScriptableObject.CreateInstance<LevelDataBase>();
 //       AssetDatabase.CreateAsset(database, path);
 //       AssetDatabase.SaveAssets();
 //       AssetDatabase.Refresh();
 //   }

 //   public void CreateLevelFile()
 //   {
 //       //gameManager = GameManager.instance;
 //       //CreateDatabase(gameManager.LevelDatabase, LEVEL_DATABASE_PATH);
 //   }

    
}
