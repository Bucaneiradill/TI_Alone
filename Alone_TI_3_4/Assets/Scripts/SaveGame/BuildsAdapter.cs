using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildsAdapter : BuildsData
{
    public BuildsAdapter(BuildSave build){
       gameObjectName = build.name;
       pos = build.transform.position;
       rot = build.transform.rotation;
    }
}
