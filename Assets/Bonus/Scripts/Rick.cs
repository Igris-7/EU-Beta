using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rick : MonoBehaviour
{
	public float speed;
	public float maxSpeed;
	public SpriteRenderer rick;
	public GameObject soundJump;
    public GameObject soundFuego;
	private Rigidbody2D rickRB;
	private Animator arick;
	public Transform bala;
	public GameObject balaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rickRB = GetComponent<Rigidbody2D>();
        arick = GetComponent<Animator>();
        arick.SetBool("bPiso", false);
    }

    // Update is called once per frame
    void Update()
    {
        arick.SetFloat("dspeed", Mathf.Abs(rickRB.velocity.x));
    	if(Input.GetKey(KeyCode.D))
    	{
    		rick.flipX=false;
    	}
    	if(Input.GetKey(KeyCode.A))
    	{
    		rick.flipX=true;
    	}

    	Disparo();
    }

    void FixedUpdate()
    {
    	float x = Input.GetAxis("Horizontal");
    	rickRB.AddForce(Vector2.right*speed*x);
    	if(rickRB.velocity.magnitude > maxSpeed)
    	{
    		rickRB.velocity = rickRB.velocity.normalized * maxSpeed;
    	}

    	if(Input.GetAxis("Jump") > 0 && arick.GetBool("bPiso"))
    	{
    		Instantiate(soundJump);
    		arick.SetBool("bPiso", false);
    		rickRB.velocity = new Vector2(rickRB.velocity.x, 0f);
    		rickRB.AddForce(new Vector2(0,6), ForceMode2D.Impulse);
    	}

    }

    public void Disparo()
    {
    	if(Input.GetButtonDown("Fire1"))
    	{      
            arick.SetBool("dispara", true);
    		Instantiate(balaPrefab, bala.position, bala.rotation);
            Instantiate(soundFuego);
    	}
        else if(Input.GetButtonUp("Fire1"))
        {
            arick.SetBool("dispara", false);
        }


    }

    void OnCollisionStay2D(Collision2D collision)
    {
    	if(collision.gameObject.tag== "Piso" && Input.GetAxis("Jump") == 0)
    	{
    		arick.SetBool("bPiso", true);
    	}
    }
}
