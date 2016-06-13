using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float vSpeed = 15f;
	public float hSpeed = 10f;
	public Camera mainCamera;
	public Transform groundCheck;
	public LayerMask whatIsGround;

	public float move = 0f;
	private float checkRadius = 0.01f;
	private bool grounded = true;
	private Rigidbody2D rb;
	private Animator anim;
	private bool facingRight = true;

	void Start() {
		this.rb = GetComponent <Rigidbody2D> ();
		this.anim = GetComponent <Animator> ();
	}

	void Update() {
		//Checks if player is grounded
		this.grounded = Physics2D.OverlapCircle (this.groundCheck.position, this.checkRadius, this.whatIsGround);

		//
		if (this.grounded) {
			this.rb.velocity = new Vector2 (0f, this.rb.velocity.y);
		}

		//Changes animation
		this.anim.SetBool("isGrounded", this.grounded);
		//this.anim.SetFloat("vSpeed", this.rb.velocity.y);



		//Checks if user is touch the screen
		if (Input.touchCount > 0) {

			if (Input.GetTouch (0).tapCount == 1) {
                if(GameManager.Instance.IsPlaying())
                    Fly(Input.GetTouch(0).position);
			}
			else if (Input.GetTouch (0).tapCount == 2) {
				//				Debug.Log ("teste");
				//				this.rb.AddForce (Vector2.up * (this.vSpeed * this.booster));
				//				this.boosted = true;
			}
		}

		if (move > 0 && !this.facingRight)
		{
			Flip();
		}
		if(move < 0 && this.facingRight)
		{
			Flip();
		}
	}

	void Flip()
	{
		this.facingRight = !this.facingRight;
		Vector3 scale = this.transform.localScale;
		scale.x *= -1;
		this.transform.localScale = scale;
	}

	void Fly(Vector2 posFinger){
		//Gets touch screen position and converts to world position
		//Vector3 touchPosition = this.mainCamera.ScreenToWorldPoint (new Vector3 (posFinger.x, posFinger.y));


        //Calcutes the difference between player and touch position
        //Vector3 playerPosition = this.rb.transform.position;
        //Vector3 diff = touchPosition - playerPosition;

        //Debug.Log(Screen.width);
        //Debug.Log(posFinger);

        //Asssigns move according to the position of the finger on the screen 
        //left: -1
        //right: +1
        //if(diff.x <= -1 || diff.x >= 1)
        //{
        //    this.move = diff.x / Mathf.Abs(diff.x);
        //    this.rb.velocity = new Vector2(move * hSpeed, this.rb.velocity.y);
        //}
        //else
        //{
        //this.rb.velocity = new Vector2(0f, this.rb.velocity.y);
        //}

        if(posFinger.x > Screen.width / 2)
        {
            this.move = 1;
        }
        else
        {
            this.move = -1;
        }

        //Move player horizontally and vertically
        this.rb.velocity = new Vector2(move * hSpeed, this.rb.velocity.y);
        this.rb.AddForce (Vector2.up * this.vSpeed);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("TutorialPoint"))
            Destroy(coll.gameObject.transform.parent.gameObject);
    }
}

