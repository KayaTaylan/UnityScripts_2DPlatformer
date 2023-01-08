using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private Animator playerAnimation;
    private GameObject player;
    public GameObject gameOverScreen;

    private void Start()
    {
        playerAnimation = GameObject.Find("Player").GetComponent<Animator>();
        player = GameObject.Find("Player");
        gameOverScreen.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            EndGame();
        }

    }

    public void EndGame()
    {
        playerAnimation.SetBool("Hurt", true);
        gameOverScreen.SetActive(true);
        TimeScaleManager.StopTime();
    }
}
