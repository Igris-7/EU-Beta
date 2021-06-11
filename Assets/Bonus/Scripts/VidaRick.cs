using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VidaRick : MonoBehaviour
{
	Rigidbody2D rickRB;

	public float movX , movY;

	public int rickhealth;
	public int enemigodaño;

	public GameObject explossion;
	

    // Start is called before the first frame update
    void Start()
    {
        rickRB = GetComponent<Rigidbody2D>();
    }

   	void OnTriggerEnter2D(Collider2D col)
   	{
   		if(col.tag =="Enemy")
   		{
   			rickhealth -= enemigodaño;

   			if(rickhealth > 0)
   			{
   				GetComponent<SpriteRenderer>().color = Color.red;
   				if(col.GetComponent<SpriteRenderer>().flipX == false) //empuje hacia izquierda
   				{
   					rickRB.velocity = new Vector2(-movX, movY);
   				}

   				else if(col.GetComponent<SpriteRenderer>().flipX == true) //empuje hacia derecha
	   			{
	   				rickRB.velocity = new Vector2(movX, movY);
	   			}
	   		}

	   		else if( rickhealth <= 0) //si su vida es menor o igual a 0
	   		{

	   			Destroy(gameObject);
	   			Instantiate(explossion, transform.position, transform.rotation);
	   			Debug.Log("Perdio");
            	SceneManager.LoadScene("Nivel_Bonus"); //CARGAR ESCENA
	   		}
   		}
   	}

   /*	void OnTriggerStay2D(Collider2D col)
   	{
   		if(col.tag =="Enemy")
   		{
   			GetComponent<SpriteRenderer>().color = Color.white;
   		}
   	}*/

   	void OnTriggerExit2D(Collider2D col)
   	{
   		if(col.tag =="Enemy")
   		{
   			GetComponent<SpriteRenderer>().color = Color.white;
   		}
   	}
}
