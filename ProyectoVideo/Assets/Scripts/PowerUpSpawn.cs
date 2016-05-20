using UnityEngine;
using System.Collections;

public class PowerUpSpawn : MonoBehaviour {


	public float targetTime = 16000.0f;
	private float counter;
    //Wrap
    GameObject mainCamera;
    Renderer[] renderers;
    bool isWrappingX = false;
    bool isWrappingY = false;

    public GameObject PowerUp;

	void Start()
	{
		counter = targetTime;
        renderers = GetComponentsInChildren<Renderer>();
        mainCamera = GameObject.Find("MainCamera");
    }


	void Update()
	{
		counter -= Time.deltaTime;
		if (counter <= 0.0f)
		{
			timerEnded();
		}
	}

	void timerEnded()
	{
		//Instanciar prefab:2 
		counter = targetTime;
		Vector3 pos = new Vector3(Random.Range(-7.0f, 7.0f), 6.0f, 0);
		Instantiate (Resources.Load ("Prefabs/powerup1"), pos, Quaternion.identity);	    
	}

    void Wrap()
    {
        // If all parts of the object are invisible we wrap it around
        foreach (var renderer in renderers)
        {
            if (renderer.isVisible)
            {
                isWrappingX = false;
                isWrappingY = false;
                return;
            }
        }

        // If we're already wrapping on both axes there is nothing to do
        if (isWrappingX && isWrappingY)
        {
            return;
        }

        var cam = Camera.main;
        var newPosition = transform.position;
        var viewportPosition = cam.WorldToViewportPoint(transform.position);


  
        if (!isWrappingY && (viewportPosition.y < 0))
        {
            System.Console.WriteLine("Instancia");
            Destroy(this);
        }
        //Apply new position
    }
}
