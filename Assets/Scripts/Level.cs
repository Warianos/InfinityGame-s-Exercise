using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level : System.Object{

    [SerializeField]
    private List<int> levelGrid;

    [SerializeField]
    private int world;

    [SerializeField]
    private int levelNumber;

    [SerializeField]
    private int numberOfLights;

    public Level(int worldNumber, int levelNumber, List<int> grid, int lights)
    {
        World = worldNumber;
        this.levelNumber = levelNumber;
        levelGrid = grid;
        NumberOfLights = lights;
    }

    public List<int> LevelGrid
    {
        get
        {
            return levelGrid;
        }

        set
        {
            levelGrid = value;
        }
    }

    public int NumberOfLights
    {
        get
        {
            return numberOfLights;
        }

        set
        {
            numberOfLights = value;
        }
    }

   
    public int World
    {
        get
        {
            return world;
        }

        set
        {
            world = value;
        }
    }

    public int LevelNumber
    {
        get
        {
            return levelNumber;
        }

        set
        {
            levelNumber = value;
        }
    }

    void OnEnable()
    {
        if (levelGrid == null)
            levelGrid = new List<int>();
    }

    public void Add(int item)
    {
        levelGrid.Add(item);
    }
    public void Remove(int item)
    {
        levelGrid.Remove(item);
    }
}
