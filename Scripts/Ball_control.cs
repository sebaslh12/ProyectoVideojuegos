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

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>(); 
		jumpAudio = (AudioClip)Resources.Load ("ballJump", typeof(AudioClip));
		collideAudio = (AudioClip)Resources.Load ("ballCollide", typeof(AudioClip));
	}
	void Awake(){
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
        
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

    void OnCollisionEnter2D(Collision2D col) { 
        if(col.gameObject.tag == "Platform"){
			source.Stop ();			
			source.PlayOneShot (collideAudio, 1.0f);	
			if (col.gameObject.transform.position.y < transform.position.y) {						
				isJumping = false;			
			}
        }
        
    }
}
