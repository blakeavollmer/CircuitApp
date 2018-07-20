using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadboardHoles : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Diffuse");
        transform.GetComponent<Renderer>().material.color = Color.clear;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
