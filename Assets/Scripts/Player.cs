using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float maxSpeed = 2;
    public float Speed = 50f;
    public float jumpPow = 200f;
    public int CurHealth;

    public bool Grounded;
    public bool Umbella;
    public bool Box;
    public bool Die;

    private Animator anim;
    private Rigidbody2D rb2d;
    private GameObject Obstacle;
    public HUD Hud;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        CurHealth = 0;
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Ground", Grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Umbella", Umbella);
        anim.SetBool("Box", Box);
        anim.SetBool("Die", Die);

        if (Input.GetAxis("Horizontal") < -0.1f && Die == false)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        if (Input.GetAxis("Horizontal") > 0.1f && Die == false)
        {
            transform.localScale = new Vector3(1,1,1);
        }

        //Player Jump
        if (Input.GetButtonDown("Jump") && Die==false)
        {
            if (Grounded) rb2d.AddForce(Vector2.up * jumpPow);
        }

        //Player Die
        if (CurHealth >= 100)
        {
            Speed = 0.0f;
            Die = true;
        }
    }

    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.x *= 0.5f;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        float h = Input.GetAxis("Horizontal");

        //Friction
        if (Grounded) rb2d.velocity = easeVelocity;
        //Player Move
        if (Grounded && Die == false) rb2d.AddForce((Vector2.right * Speed)*h);
        else rb2d.AddForce((Vector2.right * Speed / 3)*h);

        //Limiting Speed Move
        if (rb2d.velocity.x > maxSpeed) rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        if (rb2d.velocity.x < -maxSpeed) rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
    }
}
