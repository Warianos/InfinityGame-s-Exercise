using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldChanger : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    ParticleSystem world1PS;

    [SerializeField]
    ParticleSystem world2PS;

    [SerializeField]
    ParticleSystem world3PS;

    [SerializeField]
    Transform world1LevelPanel;

    [SerializeField]
    Transform world2LevelPanel;

    [SerializeField]
    Transform world3LevelPanel;

    [SerializeField]
    Transform worldPanel;
    

    public void ChangeBackground(string worldName)
    {
        if (worldName == "World 1")
        {
            transform.parent.parent.GetComponent<Image>().color = new Color(0.125f, 0.231f, 0.271f, 0.5f);
            world1PS.gameObject.SetActive(true);
            world2PS.gameObject.SetActive(false);
            world3PS.gameObject.SetActive(false);
            world1LevelPanel.gameObject.SetActive(true);
            transform.gameObject.SetActive(false);

        }
        if (worldName == "World 2")
        {
            transform.parent.parent.GetComponent<Image>().color = new Color(0.271f, 0.125f, 0.125f, 0.5f);
            world1PS.gameObject.SetActive(false);
            world2PS.gameObject.SetActive(true);
            world3PS.gameObject.SetActive(false);
            //transform.parent.gameObject.SetActive(false);
        }
        if (worldName == "World 3")
        {
            transform.parent.parent.GetComponent<Image>().color = new Color(0.271f, 0.231f, 0.125f, 0.5f);
            world1PS.gameObject.SetActive(false);
            world2PS.gameObject.SetActive(false);
            world3PS.gameObject.SetActive(true);
            //transform.parent.gameObject.SetActive(false);
        }
    }

    public void returnToMainMenu()
    {
        transform.parent.GetComponent<Image>().color = new Color(0.349f, 0.537f, 0.506f, 0.5f);
        world1PS.gameObject.SetActive(false);
        world2PS.gameObject.SetActive(false);
        world3PS.gameObject.SetActive(false);
        world1LevelPanel.gameObject.SetActive(false);
        worldPanel.gameObject.SetActive(true);
        foreach(Transform world in worldPanel)
        {
            world.gameObject.SetActive(true);
        }

        if (GameObject.FindGameObjectWithTag("GridPanel").transform.childCount > 0)
        {
            foreach (Transform cell in GameObject.FindGameObjectWithTag("GridPanel").transform)
            {
                cell.GetComponent<Cell>().Die();
            }
        }
        
    }
}
