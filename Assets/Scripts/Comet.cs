using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour {

    Player player;
    GameManager gameManager;

    public GameObject hitParticle;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        switch(collision.gameObject.tag) {
            case "Player":
                player.removeShield();

                // Removes comet.
                Destroy(gameObject);

                //Comet Destruction Particle
                Destroy(Instantiate(hitParticle, transform.position, transform.rotation), 1);
                break;
            case "Projectile":
                for (int i = 0; i < 2; i++) {
                    gameManager.StarSpawner();
                }

                // Destroys Comet
                Destroy(gameObject);

                // Destroys Projectile
                Destroy(collision.gameObject);

                // Comet Destruction Particle
                Destroy(Instantiate(hitParticle, transform.position, transform.rotation), 1);
                break;

        }
    }
}
