using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    //criando um singleton
    // tutorial unity learn https://learn.unity.com/tutorial/flocking#6317c5d8edbc2a2290a9e35e
    public static FlockManager FM;
    
    // criar os prefabs dos peixes e o numero de peixes que aparecerão
    public GameObject fishPrefab;
    public int  numFish = 20;
    public GameObject [] allFish;
    public Vector3 swimLimits = new Vector3 (3, 3, 3);  // limite do tanque apa os peixes nadarem

    public Vector3 goalPos = Vector3.zero;

    [Header ("Fish Settings")]
    [Range(0.0f,5.0f)]
    public float minSpeed;
    [Range(0.0f,5.0f)]
    public float maxSpeed;

    [Range(1.0f,10.0f)]
    public float neighbourDistance;

    [Range(1.0f,5.0f)]
    public float rotationSpeed;

    

    void Start()
    {
        allFish = new GameObject [numFish];
        for( int i = 0 ; i< numFish ; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
                                                                Random.Range(-swimLimits.y, swimLimits.y),
                                                                Random.Range(-swimLimits.z, swimLimits.z));
            allFish [i] = Instantiate(fishPrefab, pos, Quaternion.identity);
        }
        FM = this;

        goalPos = this.transform.position;
    }

    void Update()
    {
        //peixes movendo aleatoriamente
        if(Random.Range(0,100) < 10)
        {
          goalPos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
                                                                Random.Range(-swimLimits.y, swimLimits.y),
                                                                Random.Range(-swimLimits.z, swimLimits.z));
        }
    }
}
