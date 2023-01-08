using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
    private Player_GemCount gemCount;
    private GameObject player;
    private AudioSource audioSource;
    public AudioClip gemSound;

    private void Start()
    {       
        player = GameObject.Find("Player");
        gemCount = GameObject.Find("Player").GetComponent<Player_GemCount>();
        audioSource = GameObject.Find("GemSound").GetComponent<AudioSource>();
        audioSource.clip = gemSound;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            gemCount.collectedGems += 1;
            audioSource.PlayOneShot(gemSound);
            gameObject.SetActive(false);
        }
    }
}
