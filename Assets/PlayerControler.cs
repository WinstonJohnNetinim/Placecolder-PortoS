using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControler : MonoBehaviour
{
	public LayerMask collisionLayer;
	public Rigidbody2D rb;
	public float speed;
	public float jumpSpeed;
	private Collider2D playerCollider;

	private Animator playerAnimator;
	public AudioClip jumpSFX;


	public bool grounded;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start ()
	{
		
		rb = GetComponent<Rigidbody2D> ();
		playerCollider = GetComponent<Collider2D> ();
		playerAnimator = GetComponent <Animator> ();
	}
		
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		//checa se o jogador está na plataforma pelo collider e pela layer
		grounded = Physics2D.IsTouchingLayers (playerCollider, whatIsGround);

		/*
		if(Input.GetKey (KeyCode.Space))
		{
			transform.DOBlendableMoveBy (new Vector3 (0.5f, 0, 0), 2f)
				.onComplete = new TweenCallback (() =>
					transform.DOBlendableMoveBy (new Vector3 (0, 0, 0), 2f)

			);
		}*/

		//adiciona velocidade no eixo x
		rb.velocity = new Vector2 (speed, rb.velocity.y);


		//pulo do jogador
		if (Input.GetKeyDown (KeyCode.W))
		{


			//AudioSource.PlayClipAtPoint (jumpSFX, gameObject.transform.position);
	

			if (grounded)
			{
				rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);
			}

	
			//descendo da plataforma
			if (Input.GetKeyDown (KeyCode.S)) 
			{
				Debug.Log ("S");
				OverPlatform ();

			}
		}

		//animator
		playerAnimator.SetFloat ("Speed", rb.velocity.x);
		playerAnimator.SetBool ("Grounded", grounded);


	}

	//checando o collider com raycast
	void OverPlatform ()
	{
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down, 1.5f, collisionLayer);
		if (hit.collider != null) 
		{
			if (hit.collider.CompareTag ("Plataforma")) 
			{
				hit.collider.enabled = false;
				Debug.Log ("teste");
			}
		}
	}
}
