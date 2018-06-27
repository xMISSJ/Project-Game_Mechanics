using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public GameObject gameOverScreen;
    public GameObject playScreen;
    public Text gameScore;
    public int value;
    //AudioSource backgroundm;

    // Use this for initialization
    void Start()
    {
        //backgroundm = GameObject.FindGameObjectWithTag("Background_Music").GetComponent<AudioSource>();
    }

    public void EnterGameOver(int score)
    {
        gameScore.text = "Your StarScore: " + score.ToString();

        // Game Over screen will be shown.
        gameOverScreen.SetActive(true);
        playScreen.SetActive(false);

        //backgroundm.Stop();
    }
}
