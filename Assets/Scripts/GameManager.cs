using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;

    public GameObject player;
    public GameObject comet;
    public GameObject star;
    public GameObject enemy;

    public GameObject playScreen;

    private System.Random rnd;
    private float spawnTimer;

    public Text scoreText;

    Vector3 targetPosition;
    Movement movementScript;

    GameOver gameOverScript;

    // Use this for initialization.
    void Start()
    {
        gameOverScript = GameObject.Find("Game_Over").GetComponent<GameOver>();

        // Finds the player game object using the tag "Player".
        player = GameObject.FindGameObjectWithTag("Player");
        rnd = new System.Random();

        // Sets default score to 0.
        score = 0;

        // Fetches the Movement script and gets from this Movementscript the "root" which is player.
        movementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        targetPosition = movementScript.transform.root.transform.position;

        transform.LookAt(targetPosition);

        // Finds the score game object using the tag "ScoreText".
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

        spawnTimer = 0;
    }

    // Update is called once per frame.

    void Update()
    {
        spawnTimer += Time.deltaTime;
        scoreText.text = "Starpoints: " + score;

        // Random star spawner.
        if (spawnTimer >= 2)
        {
            StarSpawner();
            spawnTimer = 0;

            // When the player dies, go to game over screen.
            if (player.GetComponent<Player>().Lives <= 0)
            {
                // Shows Game Over Screen.
                gameOverScript.EnterGameOver(score);
            }

            // 50% chance that a random comet will spawn
            if (rnd.Next(0, 2) == 1) {
                CometSpawner();
            }

            // 25% chance that a enemy will spawn :)
            if (rnd.Next(0, 4) == 1) {
                EnemySpawner();
            }
        }

    }

    public void CometSpawner() {
        var obj = Instantiate(comet, new Vector2(player.transform.position.x + rnd.Next(-10, 10),
                                  player.transform.position.y + 60),
                                  new Quaternion(0, 0, 0, 0));

        obj.transform.parent = playScreen.transform;
    }

    public void StarSpawner() {
        var obj =  Instantiate(star, new Vector2(player.transform.position.x + rnd.Next(-10, 10),
                              player.transform.position.y + rnd.Next(-10, 10)),
                              new Quaternion(0, 0, 0, 0));

        obj.transform.parent = playScreen.transform;
    }

    public void EnemySpawner() {
        var obj =  Instantiate(enemy, new Vector2(player.transform.position.x + rnd.Next(-10, 10),
                              player.transform.position.y + rnd.Next(-10, 10)),
                              new Quaternion(0, 0, 0, 0));

        obj.transform.parent = playScreen.transform;
    }
}
