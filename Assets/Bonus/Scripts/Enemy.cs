using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public GameObject startPoint;
	public GameObject endPoint;

	public float enemyspeed;
	private bool enemydir;

    // Start is called before the first frame update
    void Start()
    {
        if(!enemydir)
        {
        	transform.position = startPoint.transform.position;
        }

        else
        {
        	transform.position = endPoint.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyMananger.enemigoMuere ==false) //si el enemigo no esta destruido, se realiza la animación
        {
             if(!enemydir)//direccion 
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, enemyspeed * Time.deltaTime);
            if(transform.position == endPoint.transform.position)
            {
                enemydir=true;
                GetComponent<SpriteRenderer>().flipX = true;
            }

        }

        if(enemydir)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint.transform.position, enemyspeed * Time.deltaTime);
            if(transform.position == startPoint.transform.position)
            {
                enemydir=false;
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        }
       
    }

    public void OnDrawGizmos() //dibuja el camino
    {
    	Gizmos.DrawLine(startPoint.transform.position, endPoint.transform.position);
    }

}
