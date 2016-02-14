﻿using UnityEngine;
using System.Collections;

public class Ball_control : MonoBehaviour {

    public float jumpHeight;
    public float tranSpeed;
    public bool isJumping = false;
    private int points = 0;
    Rigidbody2D body;

	// Use this for initialization
	void Start () {

        body = GetComponent<Rigidbody2D>();
	    
	}
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetKeyDown(KeyCode.Space)){
            if (isJumping == false){
                body.AddForce(Vector2.up * jumpHeight);
                isJumping = true;
                points++;
            }
        }
            
        else if(Input.GetKeyDown(KeyCode.LeftArrow)){
            body.AddForce(Vector2.left * tranSpeed);            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            body.AddForce(Vector2.right * tranSpeed);
        }

    }
    public int getPoints() {
        return points;
    }

    void OnCollisionEnter2D(Collision2D col) { 
        if(col.gameObject.tag == "Platform"){
            isJumping = false;
        }
        
    }
}