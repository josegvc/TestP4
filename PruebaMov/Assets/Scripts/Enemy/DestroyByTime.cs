using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByTime : MonoBehaviour
{
    public float lifetime;
     Animator anim;                      // Reference to the animator component.


    void Awake()
    { 
        anim = GetComponent<Animator>();
 
    }



    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    /*
    private void Update()
    {
        if (Time.time > lifetime - 2)
        {
            anim.SetTrigger("Dead");
        }
    }*/
}