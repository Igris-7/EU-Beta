using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyMananger : MonoBehaviour
{
	public int enemyhealth;
	public int enemyValue;

	private Animator aenemigo;
	public float animacionDelay;

	public GameObject barraVida;
	private float refVida;

	public static bool enemigoMuere = false;

	void Start()
	{
		refVida = enemyhealth;
		aenemigo = GetComponent<Animator>();
	}

    public void OnTriggerEnter2D(Collider2D col)
    {
    	if(col.tag =="Bala")
    	{
    		refVida -= MovBala.daño;
    		float ctdVida = refVida / enemyhealth;
    		SetHealthBar(ctdVida);
    		if(refVida <= 0)
    		{
    			enemigoMuere = true;
    			aenemigo.SetBool("muere?", true);
    			Debug.Log(enemyValue);
    			Destroy(gameObject, animacionDelay);
				SceneManager.LoadScene("Nivel_03");
    		}
    	}
    }

    public void SetHealthBar(float enemigoVida)
    {
    	barraVida.transform.localScale= new Vector3(enemigoVida, barraVida.transform.localScale.y, barraVida.transform.localScale.z);
   }

}
