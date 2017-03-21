using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public RawImage noteImage;

    public AudioClip pickupSound;
    public AudioClip putAwaySound;

    public float sec = 19f;


    private Rigidbody rb;
    private GameObject go;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (noteImage.enabled==true)
        noteImage.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            go = other.gameObject;
            go.SetActive(false);
            ShowNoteImage();
            StartCoroutine(LateCall());
        }
    }

    public void AddItem()
    {


    }



    public void ShowNoteImage()
    {
        noteImage.enabled = true;
        GetComponent<AudioSource>().PlayOneShot(pickupSound);
    }

    public void HideNoteImage()
    {
        noteImage.enabled = false;
        GetComponent<AudioSource>().PlayOneShot(putAwaySound);

    }

    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(sec);

        noteImage.enabled = false;
        GetComponent<AudioSource>().PlayOneShot(putAwaySound);
        go.SetActive(true);
    }


}