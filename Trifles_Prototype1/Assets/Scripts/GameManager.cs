using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Serialization;
using UnityEngine.UI;


//SORRY I HAVE TO GO WITH THE BLASPHEMY OF COROUTINE ;-;
//I just don't know how else to show my dialogue character by character like a printing machine...
public class GameManager : MonoBehaviour
{
    //set up a singleton
    public static GameManager instance;
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
        
        //if currentLocation's upLocation doesn't exist
        //up button is not interactable
        if (!currentLocation.upLocation)
        {
            up.interactable = false;
        }
        else
        {
            up.interactable = true;
            currentLocation.upLocation.downLocation = currentLocation;
        }

        //if currentLocation's downLocation doesn't exist
        if (!currentLocation.downLocation)
        {
            down.interactable = false;
        }
        else
        {
            down.interactable = true;
            currentLocation.downLocation.upLocation = currentLocation;
        }
        
        //if current's left doesn't exist
        if (!currentLocation.leftLocation)
        {
            left.interactable = false;
        }
        else
        {
            left.interactable = true;
            currentLocation.leftLocation.rightLocation = currentLocation;
        }
        
        //if current's right doesn't exist
        if (!currentLocation.rightLocation)
        {
            right.interactable = false;
        }
        else
        {
            right.interactable = true;
            currentLocation.rightLocation.leftLocation = currentLocation;
        }
        
        
    }

    //init player
    public GameObject player;
    Vector3 playerStartPos;
    Vector3 playerPos;
    int moveDistance = 20;
    
    void Start()
    {
        //start with the initial current location
        UpdateLocation();
        
        //define player position
        playerPos = player.transform.position;
    }

    //press button to move in locations
    public void MoveDirection(int dir)
    {
        switch (dir)
        {
            case 0:     //up
                currentLocation = currentLocation.upLocation;
                playerPos.y += moveDistance;
                break;
            case 1:     //down
                currentLocation = currentLocation.downLocation;
                playerPos.y -= moveDistance;
                break;
            case 2:     //left
                currentLocation = currentLocation.leftLocation;
                playerPos.x -= moveDistance;
                break;
            case 3:     //right
                currentLocation = currentLocation.rightLocation;
                playerPos.x += moveDistance;
                break;
        }

        //update the player position
        player.transform.position = playerPos;
        
        //if missing this, text won't update
        UpdateLocation();
    }

}