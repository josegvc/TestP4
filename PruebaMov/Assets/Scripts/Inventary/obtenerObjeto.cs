using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class obtenerObjeto : MonoBehaviour {


    public Image objectImage;

    public AudioClip pickupSound;
    public AudioClip putAwaySound;

    public Color newColor = Color.white;
    private Rigidbody rb;
    private GameObject go;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddItem();
            Destroy(gameObject);

        }


    }

    public void AddItem()
    {
        objectImage.material.color = newColor;

    }
     

}
