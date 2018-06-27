using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Star : MonoBehaviour {

    [SerializeField]
    private int starScore;

    GameManager gameManager;
    public AudioClip starPickup;
    AudioSource audioSource;

    // Use this for initialization.
    void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();

        // Fetches the GameManager class by searching for the MainCamera and extracts the GameManager.
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
    }

    // Method to check whether there is collision between certain objects.
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            // Plays sound.
            audioSource.PlayOneShot(starPickup, 0.2f);

            // Adds coinScore to our current score.
            gameManager.score += starScore;

            if(other.GetComponent<Player>().Lives < other.GetComponent<Player>().MaxLives)
                other.GetComponent<Player>().addShield();

            // Removes the star.
            Destroy(gameObject);
        }
    }
}