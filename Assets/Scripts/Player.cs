using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    [SerializeField]
    private int lives;

    [SerializeField]
    private int maxLives;

    public GameObject shield;
    public GameObject bullet;

    void Start() {
        // For every (star) life, get the ID.
        for (int i = 0; i < lives; i++) {
            var obj = Instantiate(shield, transform.position, transform.rotation);
            obj.GetComponent<Shield>().Id = i;
            obj.transform.parent = this.gameObject.transform;
        }
    }

    void Update() {

        //If player clicks, a star will shoot in that direction.
        if (Input.GetMouseButtonDown(0) && Lives > 1)
            fireStar();
    }

    public void addShield() {
        Lives++;
        GameObject[] shields = GameObject.FindGameObjectsWithTag("Shield");
        var obj = Instantiate(shield, transform.position, transform.rotation);
        obj.GetComponent<Shield>().Id = shields.Length;
        obj.transform.parent = this.gameObject.transform;

        foreach (GameObject shield in shields) {
            shield.GetComponent<Shield>().ResetPosition();
        }
    }

    public void removeShield() {
        Lives--;
        GameObject[] shields = GameObject.FindGameObjectsWithTag("Shield");
        Destroy(shields[shields.Length - 1]);

        foreach (GameObject shield in shields) {
            shield.GetComponent<Shield>().ResetPosition();
        }
    }

    public void fireStar() {
        removeShield();
        Destroy(Instantiate(bullet, transform.position, transform.rotation), 3);
    }

    public int Lives {
        get {
            return this.lives;
        }
        set {
            if (this.lives < value) {

            } else {

            }
            this.lives = value;
        }
    }

    public int MaxLives {
        get {
            return this.maxLives;
        }
    }
}