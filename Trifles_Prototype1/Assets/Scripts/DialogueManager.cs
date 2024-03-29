using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class DialogueManager : MonoBehaviour
{
    //set up a singleton
    static DialogueManager instance;
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
    
    //init the >>>Next button
    public Button nextButton;

    void Start()
    {
        //the next button won't show until txt is done printing
        nextButton.gameObject.SetActive(false);
            
        //set up the file path for all dialogue txt
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
        
        //clear the text
        dialogue.text = string.Empty;
        
        //BLASPHEMY... start loading dialogue
        StartCoroutine(DialogueSystem());
    }

    //DIALOGUE SYSTEM
    //numbering the txt files in TextResources with a property
    int currentTextFile = 0;

    //TODO: When there are multiple files in TextResources, remember to CurrentTextFile++
    public int CurrentTextFile
    {
        get { return currentTextFile; }
        set
        {
            currentTextFile = value;
            StartCoroutine(DialogueSystem());
        }
    }

    public AudioSource typewriterSound;
    
    IEnumerator DialogueSystem()
    {
        //customize every dialogue file
        string newPath = FILE_PATH.Replace("Num", currentTextFile + "");
        
        //load all lines from the current txt
        string[] fileLines = File.ReadAllLines(newPath);

        //start playing typewriter sound
        typewriterSound.Play();
        
        //go through each line with a for loop
        for (int lineNum = 0; lineNum < fileLines.Length; lineNum++)
        {
            string lineContents = fileLines[lineNum];

                //now get each character from each line
                char[] lineChar = lineContents.ToCharArray();

                //loop through each character
                for (int charNum = 0; charNum < lineChar.Length + 1; charNum++)
                {
                    //print out the char one by one
                    if (charNum < lineChar.Length)
                    {
                        dialogue.text += lineChar[charNum];
                        
                    }
                    //an empty line in between each line in the txt files
                    if (charNum == lineChar.Length)
                    {
                        dialogue.text += "\n" + "\n";
                    }
                    
                    //sorry I have to use CoRoutine and not really understand what it is ;-;
                    //but I tried Time.deltaTime and it's just not working when printing the characters
                    //I watched this YouTube video: https://www.youtube.com/watch?v=45zJpi0jt_Q
                    yield return new WaitForSeconds(0.05f);
                }
                
                yield return null;
        }
        
        //when the text is finished printing
        //stop playing typewriter sound
        typewriterSound.Stop();
        
        //show the >>>Next button
        nextButton.gameObject.SetActive(true);
    }
    
}
