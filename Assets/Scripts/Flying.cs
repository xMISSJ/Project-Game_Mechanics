using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour {

    public float ySpeed;
    public float amplitude;
    public GameObject playerScript;         // The gameobject that has the player scripts.

    public Vector3 tempPosition;

	// Use this for initialization.
	void Start ()
    {
        // Set the default to be the current position of player.
        transform.position = tempPosition + transform.position;
    }

    /* Using FixedUpdate() here, because FixedUpdate can run multiple times for each frame,
     * depending on how many physics frames per second are set in the time settings, and how fast/slow the frame rate is.
     */
    void FixedUpdate ()
    {
        // Sets x position, to move left and right.
        tempPosition.x = transform.position.x;
        tempPosition.y = transform.position.y;

        // Create up and down movement.
        tempPosition.y += Mathf.Sin(Time.realtimeSinceStartup * ySpeed) * amplitude;
        transform.position = tempPosition;
        GetComponent<Movement>().setOldPos(); 
    }
}
