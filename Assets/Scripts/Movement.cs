using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speedX;
    public float speedY;
    bool playerIsMoving = false;
    public GameObject accessFlyingScript;
    Vector3 playerPosition;
    float oldPosX;
    float oldPosY;

    Rigidbody2D rgbd;

    // Use this for initialization
    void Start()
    {
        setOldPos();
    }

    public void setOldPos()
    {
        oldPosX = transform.position.x;
        oldPosY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2((horizontal * (speedX * 40) * Time.deltaTime), vertical * speedY);

        rgbd = GetComponent<Rigidbody2D>();
        
        playerIsMoving = false;

        // Checks if player is moving.
        if (oldPosX < transform.position.x || oldPosX > transform.position.x || oldPosY < transform.position.y || oldPosY > transform.position.y)
        {
            playerIsMoving = true;
        }

        setOldPos();
        // Detects if the player is moving.
        if (!playerIsMoving)
        {
            // Makes it so the "Flying" script is turned off. This makes it so the player doesn't hover.
            accessFlyingScript.GetComponent<Flying>().enabled = true;
        }
        else
        {
            accessFlyingScript.GetComponent<Flying>().enabled = false;
            rgbd.gravityScale = 0;
        }
    }
}
