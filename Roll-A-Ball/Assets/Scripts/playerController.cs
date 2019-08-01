using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    private Rigidbody rb;
    private int score;
    public float speed;
    public Text scoreText;
    public Text winText;

    private void Start()
    {
        //Grab player's rigidbody to allow for force movement in-game
        rb = GetComponent<Rigidbody>();
        //Initialize score
        score = 0;
        //Initialize score UI
        DisplayScore();
        //Initialize winning UI
        winText.text = "You Win!";

    }

    //FixedUpdate called before any physics update. Since movement is used with
    //physics, script will use FixedUpdate
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);


        rb.AddForce(movement * speed);
    }

    //Controlling pickup behavior
    private void OnTriggerEnter(Collider other)
    {
        //check if the collided object is a pickup
        if (other.CompareTag("pickup")) {
            //deactivate the pickup
            other.gameObject.SetActive(false);
            //Increment the score
            score += 1;
            DisplayScore();
        }
    }

    //Function for displaying score UI
    void DisplayScore(){
        scoreText.text = "Score: " + score.ToString();
        //check if player has won [collected all objects]
        if (score >= 10) {
            //Display winning text
            winText.gameObject.SetActive(true);
        }
    }
}