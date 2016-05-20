using UnityEngine;

public class Ball_control : MonoBehaviour {

	private float jumpHeight = 500.0f;
    public float tranSpeed = 50.0f;
    private bool isJumping = false;
    private int points = 0;
    Rigidbody2D body;
	private AudioClip jumpAudio;
	private AudioClip collideAudio;
	private AudioSource source; 
	private int lifes = 1;
	//Wrap
	GameObject mainCamera;
	Renderer[] renderers;
	bool isWrappingX = false;
	bool isWrappingY = false;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>(); 
		jumpAudio = (AudioClip)Resources.Load ("ballJump", typeof(AudioClip));
		collideAudio = (AudioClip)Resources.Load ("ballCollide", typeof(AudioClip));
		renderers = GetComponentsInChildren<Renderer>();
		mainCamera = GameObject.Find("MainCamera");
	}
	void Awake(){
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		Wrap();        
        if(Input.GetKeyDown(KeyCode.Space)){			
            if (isJumping == false){
				source.PlayOneShot (jumpAudio, 1.0f);
				points+=5;
                body.AddForce(Vector2.up * jumpHeight);
                isJumping = true;                
            }
        }
            
        else if(Input.GetKeyDown(KeyCode.LeftArrow)){
            body.AddForce(Vector2.left * tranSpeed);            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            body.AddForce(Vector2.right * tranSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            body.AddForce(Vector2.down * tranSpeed);
        }

    }
    public int getPoints() {
        return points;
    }

	public int getLifes(){
		return lifes;
	}

    void OnCollisionEnter2D(Collision2D col) { 
        if(col.gameObject.tag == "Platform"){
			source.Stop ();			
			source.PlayOneShot (collideAudio, 1.0f);	
			if (col.gameObject.transform.position.y < transform.position.y) {						
				isJumping = false;			
			}
        } else {
			if (col.gameObject.tag == "Power") {
				lifes++;
				Destroy (col.gameObject);
			}
		}
        
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


		// Wrap it is off screen along the x-axis and is not being wrapped already
		if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
		{
			newPosition.x = -newPosition.x;
			isWrappingX = true;
		}

		if (!isWrappingY && (viewportPosition.y < 0))
		{
			lifes=lifes-1;
			newPosition.y = -newPosition.y;
		}
		//Apply new position
		transform.position = newPosition;
	}
}
