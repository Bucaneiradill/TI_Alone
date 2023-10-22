using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocoAgent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //InvokeRepeating("Bite", 0.0f, 5.0f);
        if(other.gameObject.CompareTag("Player"))
        {
            Bite();
            Debug.Log("moideu");
        }   
            
    }

    public void Bite()
    {
        GameManager.instance.damage(50);
    }
}
