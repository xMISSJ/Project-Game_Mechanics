using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    Player player;
    GameManager gameManager;

    int radius;

    [SerializeField]
    private int id;

    float timeCounter;
    private float speed;
    private float width;
    private float height;


    // Use this for initialization.
    void Start()
    {
        speed = 1.5f;
        height = 1.8f;
        width = 1.8f;

        timeCounter = 0;

        // Fetches the GameManager class by searching for the MainCamera and extracts the GameManager.
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * speed;

        // Takes the x and y coordinates from player and makes this the center.
        // Mathf.PI * 1 = half a circle, Mathf.PI*2 is a whole circle. This divided by the "lives" times by the ID makes it so every star is divided evenly.
        float x = Mathf.Cos(timeCounter + ((Mathf.PI * 2) / player.Lives * Id)) * width;
        float y = Mathf.Sin(timeCounter + ((Mathf.PI * 2) / player.Lives * Id)) * height;

        // Makes it so this gameobject rotates around the center (which is the player).
        this.transform.position = new Vector3(x, y) + gameManager.player.transform.position;
    }

    public void ResetPosition() {
        timeCounter = 0;
    }

    public int Id
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }
}