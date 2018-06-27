using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private float speed;

    private Vector3 target;
   

    void Update() {
        GetComponent<Rigidbody2D>().velocity = transform.up * 10;
    }

    public Vector3 Target {
        set {
            this.target = value;
        }
    }

}
