using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildsData 
{
    public List<GameObject> placedObj = new List<GameObject>();
    public BuildsData(List<GameObject> objects){
        placedObj = objects;
    }
}
