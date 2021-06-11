using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovBala : MonoBehaviour
{
	public float balaspeed;
	private Rigidbody2D balaRB;
	public float vidabala;
	private Transform rickDir;
	public GameObject rick;
    public static int daño;
    public int dañoRef;

	void Awake()
	{
        daño = dañoRef;
		balaRB = GetComponent<Rigidbody2D>();
		rick= GameObject.FindGameObjectWithTag("Rick");
		rickDir=rick.transform;
	}

    // Start is called before the first frame update
    void Start()
    {
        if(rickDir.localScale.x > 0)
    	{
    		balaRB.velocity = new Vector2(balaspeed, balaRB.velocity.y);
    	}
    	else
    	{
    		balaRB.velocity = new Vector2(balaspeed*-1, balaRB.velocity.y);
    	}
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, vidabala);
    }

     void OnTriggerEnter2D(Collider2D col)
    {
        if( col.tag == "Enemy")
        {
            GetComponent<ParticleSystem>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }

}
