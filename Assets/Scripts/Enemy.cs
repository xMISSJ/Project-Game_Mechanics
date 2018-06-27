using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private int killScore;

    [SerializeField]
    private int damageScore;

    [SerializeField]
    private float speed;

    Player player;
    GameManager gameManager;
    //public AudioClip enemyDamage;
    AudioSource audioSource;

    public GameObject hitParticle;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
    }

    void Update() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }

    // Method to check whether there is collision between certain objects.
    void OnTriggerEnter2D(Collider2D other) {

        switch (other.gameObject.tag) {
            case "Player":
                // Plays sound.
                //audioSource.PlayOneShot(starPickup, 0.2f);

                // Adds coinScore to our current score.
                gameManager.score -= damageScore;

                    other.GetComponent<Player>().removeShield();

                // Deactivates the gameObject for visual correction and then removes the star.
                Destroy(gameObject);
                break;
            case "Projectile":
                //Spawn 2 stars if a player kills an enemy.
                for (int i = 0; i < 2; i++) {
                    gameManager.StarSpawner();
                }

                gameManager.score += killScore;

                player.removeShield();

                Destroy(Instantiate(hitParticle, transform.position, transform.rotation), 1);
                Destroy(other.gameObject);
                Destroy(gameObject);
                break;
        }
    }

}
