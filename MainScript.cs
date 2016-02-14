using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour
{
    int playerPoints;
    GameObject playerBall;

    // Use this for initialization
    void Start()
    {
        playerBall = GameObject.Find("Bouncy_Ball");

    }

    // Update is called once per frame
    void Update()
    {
        playerPoints = ((Ball_control)playerBall.GetComponent("Ball_control")).getPoints();

    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), playerPoints.ToString());
    }
}
