using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSave : MonoBehaviour
{
    public static BuildSave instance;
    void Awake()
    {
        instance = this;
    }
}
