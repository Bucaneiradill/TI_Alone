using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocoAgent : MonoBehaviour
{
    
    public Animator CrocAnim;

    void Start()
    {
        CrocAnim = GetComponent<Animator>();
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
            CrocAnim.SetTrigger("Bite");  
            Bite();
            Debug.Log("moideu");
        }   
            
    }

    public void Bite()
    {
        GameManager.instance.damage(50);
    }
}
