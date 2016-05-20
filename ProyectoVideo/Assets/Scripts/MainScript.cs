using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour
{
    private int playerPoints;
	private int playerLife;
    GameObject playerBall;
    private float level = 1.0f;
    GUIStyle mediumFont;

    public object SceneManger { get; private set; }

    // Use this for initialization
    void Start()
    {
        playerBall = GameObject.Find("Bouncy_Ball");
        mediumFont = new GUIStyle();
        mediumFont.fontSize = 25;
    }

    // Update is called once per frame
    void Update()
    {
        playerPoints = ((Ball_control)playerBall.GetComponent("Ball_control")).getPoints();
		playerLife = ((Ball_control)playerBall.GetComponent("Ball_control")).getLifes();
		if (playerLife < 0) {
			Application.LoadLevel("Menu");
		}
        setlvl();        
    }

    void OnGUI()
    {
		int levelInt = (int)Mathf.Floor(level);
        GUI.Label(new Rect(10, 10, 100, 20), "Points: " + playerPoints.ToString(), mediumFont);
		GUI.Label(new Rect(10, 40, 100, 20), "Lifes: " + playerLife.ToString(), mediumFont);
		GUI.Label(new Rect(10, 70, 100, 20), "Level: " + levelInt.ToString(), mediumFont);

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
