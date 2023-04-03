using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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

    void Start()
    {

    }

    //init the texts and current locations
    public TextMeshProUGUI locationName;
    public TextMeshProUGUI locationDescription;
    public LocationScriptableObject currentLocation;
    
    //init buttons
    public Button up;
    public Button down;
    public Button left;
    public Button right;
    
    void UpdateLocation()
    {
        
    }

    
}