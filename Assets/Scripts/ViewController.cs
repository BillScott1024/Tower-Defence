using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewController : MonoBehaviour {

    // Use this for initialization
    public float speed = 1.0f;
	public float mouseSpeed = 60.0f;
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
		float mouse = Input.GetAxis ("Mouse ScrollWheel");
		transform.Translate(new Vector3(h * speed, mouse * mouseSpeed, v * speed) * Time.deltaTime,Space.World );



        
	}
}
