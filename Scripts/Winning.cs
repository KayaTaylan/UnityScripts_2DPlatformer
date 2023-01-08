using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning : MonoBehaviour
{
    private Player_GemCount player_gems;
    private GameObject winningScreen;
    public float requiredGems;

    // Start is called before the first frame update
    void Start()
    {
        player_gems = GameObject.Find("Player").GetComponent<Player_GemCount>();
        winningScreen = GameObject.Find("WinningScreen");
        winningScreen.SetActive(false);
        SceneManaging.SetCurrentSceneIndex();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(player_gems.collectedGems >= requiredGems)
        {
            player_gems.collectedGems -= requiredGems;
            winningScreen.SetActive(true);
            SceneManaging.LoadNextScene();
            TimeScaleManager.StopTime();
        }
    }
}
