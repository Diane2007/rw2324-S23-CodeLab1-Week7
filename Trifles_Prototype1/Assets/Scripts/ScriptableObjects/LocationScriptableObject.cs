using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enable super power to create and modify locations in inspector
[CreateAssetMenu(
    fileName = "New Location",
    menuName = "ScriptableObjects/Location",
    order = 0
    )]
public class LocationScriptableObject : ScriptableObject
{
    //the following things will appear in inspector for each location scriptable object
    public string locationName;
    public string locationDescription;

    public LocationScriptableObject upLocation, downLocation, leftLocation, rightLocation;
    
}
