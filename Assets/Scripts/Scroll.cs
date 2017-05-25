using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
    public float speed;
    public float tileSize;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(-Vector3.forward * speed * Time.fixedDeltaTime, Space.World);

        if (transform.position.z <= -tileSize)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, tileSize);
        }

    }
}
