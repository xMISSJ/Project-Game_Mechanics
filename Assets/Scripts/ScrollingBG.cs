using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour {

    public float parallax;     // To make the background slower and create illusion.

	// Update is called once per frame.
	void Update ()
    {
        // Fetches the MeshRenderer of this object.
        MeshRenderer MeshRend = GetComponent<MeshRenderer>();

        // Creates a new variable for material and offset, so every frame there will be a different offset.
        Material mat = MeshRend.material;
        Vector2 offset = mat.mainTextureOffset;

        // Here the offset.x is changed by transform.position.x, this makes the BG slowly shift to the left, creating an illusion.
        offset.x = transform.position.x / transform.localScale.x / parallax;

        offset.y = transform.position.y / transform.localScale.y / parallax;
        mat.mainTextureOffset = offset;
	}
}
