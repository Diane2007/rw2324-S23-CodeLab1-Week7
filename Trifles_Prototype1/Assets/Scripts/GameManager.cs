using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;


//SORRY I HAVE TO GO WITH THE BLASPHEMY OF COROUTINE ;-;
//I just don't know how else to show my dialogue character by character like a printing machine...
public class GameManager : MonoBehaviour
{
    //set up a singleton
    static GameManager instance;
    void Awake()
    {
        if (!instance)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //init the texts and current locations
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public LocationScriptableObject currentLocation;
    
    //init buttons
    public Button up;
    public Button down;
    public Button left;
    public Button right;
    
    void UpdateLocation()
    {
        //change the title and description text into that of the currentLocation's
        title.text = currentLocation.locationName;
        description.text = currentLocation.locationDescription;
    }

    //init player
    public GameObject player;
    Vector3 playerStartPos;
    int moveDistance = 65;
    
    void Start()
    {
        //start with the initial current location
        UpdateLocation();
        
        //define player start position
        playerStartPos = GetComponent<Transform>().position;
        Debug.Log(playerStartPos);
    }

    //press button to move in locations
    public void MoveDirection(int dir)
    {
        switch (dir)
        {
            case 0:     //up
                currentLocation = currentLocation.upLocation;
                break;
            case 1:     //down
                currentLocation = currentLocation.downLocation;
                break;
            case 2:     //left
                currentLocation = currentLocation.leftLocation;
                break;
            case 3:     //right
                currentLocation = currentLocation.rightLocation;
                break;
        }
        
        //if missing this, text won't update
        UpdateLocation();
    }
    
}