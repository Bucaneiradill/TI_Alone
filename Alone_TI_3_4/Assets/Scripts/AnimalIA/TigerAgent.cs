using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerAgent : MonoBehaviour
{
  public Animator TigerAnim;

    void Start()
    {
        TigerAnim = GetComponent<Animator>();
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
           TigerAnim.SetTrigger("Bite");  
            Bite();
            Debug.Log("moideu");
        }   
            
    }

    public void Bite()
    {
        GameManager.instance.damage(30);
    }
}
