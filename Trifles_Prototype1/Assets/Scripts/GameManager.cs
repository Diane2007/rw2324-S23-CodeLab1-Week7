using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

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
    
    //FILE PATH FOR DIALOGUE
    const string FILE_NAME = "TextNum.txt";
    const string FILE_DIR = "/TextResources/";
    string FILE_PATH;
    
    //init the dialogue game objects
    public TextMeshProUGUI dialogue;

    void Start()
    {
        //set up the file path for all dialogue txt
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
        
        //clear the text file
        dialogue.text = string.Empty;
        

    }

    //DIALOGUE SYSTEM
    //numbering the txt files in TextResources with a property
    int currentTextFile = 0;

    public int CurrentTextFile
    {
        get { return currentTextFile; }
        set
        {
            currentTextFile = value;
            DialogueSystem();
        }
    }

    void DialogueSystem()
    {
        //customize every dialogue file
        string newPath = FILE_PATH.Replace("Num", currentTextFile + "");
        
        //load all lines from the current txt
        string[] fileLines = File.ReadAllLines(newPath);
    }
    

}
