using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceLogic : MonoBehaviour
{

    public AudioClip soundClip; // Arrastra tu clip de audio aqu� en el Inspector
    private AudioSource audioSource;

    void Start()
    {
        // Obt�n el componente AudioSource del objeto
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Manager.instance.hasPrice = true;
            Debug.Log("Price has been taken!");
            PlaySound();
            gameObject.SetActive(false);
        }
    }

    public void PlaySound()
    {
        if (soundClip != null)
        {
            // Asigna el clip al AudioSource y reprod�celo
            audioSource.clip = soundClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No se ha asignado un AudioClip.");
        }
    }
}
