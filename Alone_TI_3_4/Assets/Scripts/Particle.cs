using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] float countdown = 1;
    void Start()
    {
        Destroy(gameObject, countdown);
    }
}
