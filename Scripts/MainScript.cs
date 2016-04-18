using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour
{
    private int playerPoints;
    GameObject playerBall;
    private float level = 1.0f;

    // Use this for initialization
    void Start()
    {
        playerBall = GameObject.Find("Bouncy_Ball");
    }

    // Update is called once per frame
    void Update()
    {
        playerPoints = ((Ball_control)playerBall.GetComponent("Ball_control")).getPoints();
        setlvl();        
    }

    void OnGUI()
    {
		int levelInt = (int)level;
        GUI.Label(new Rect(10, 10, 100, 20), "Points: " + playerPoints.ToString());
		GUI.Label(new Rect(10, 20, 100, 20), "Level: " + levelInt.ToString());
    }
    public float getLvl(){
        return level;    
    }

    public void setlvl() {
        float lvlCalc = (playerPoints)-50* level;
        if ( (lvlCalc <5.0f && lvlCalc>=0) && level <5 ) {
            level=level+0.1f;
        }
    }
}
