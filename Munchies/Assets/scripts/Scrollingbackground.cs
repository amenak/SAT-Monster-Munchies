using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollingbackground : MonoBehaviour {
	public float speed;
	Vector2 backgroundPos;
	// Update is called once per frame
	void Update () {
		movebg (); 
	}

	void movebg(){
		backgroundPos = new Vector2(Time.time * speed, 0);
		GetComponent<Renderer> ().material.mainTextureOffset = backgroundPos;

	}
}