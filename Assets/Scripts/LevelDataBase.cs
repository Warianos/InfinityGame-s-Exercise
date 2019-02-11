using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelDataBase: ScriptableObject {

    [SerializeField]
    private List<Level> levelDatabase;

    public List<Level> LevelDatabase
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

    void OnEnable()
    {
        if (levelDatabase == null)
            levelDatabase = new List<Level>();
    }

    public void Add(Level item)
    {
        levelDatabase.Add(item);
    }

    public void Remove(Level item)
    {
        levelDatabase.Remove(item);
    }
}
