using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBookSpawner : MonoBehaviour
{
    public float maxTime = 5.0f; // tiempo que tiene que transcurrir para respawnear
    public float timer = 0; // tiempo transcurrito respawn
    public GameObject BadBook; // objeto que contrendra al BadBook
    public GameObject BookFallingSound;

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        //x(13 -13)   y (10) 
        if(timer >  maxTime){
            //genero la posicion x inicial del BadBook
            float XpositionBook  = Random.Range(-13.0f, 13.0f);
            // instancio el badbook a spawnear
            GameObject newBadBook= Instantiate(BadBook);
            // ubico el badbook en su posicion de inicio
            newBadBook.transform.position = new Vector2(XpositionBook,10.0f);
            //inicializo sonido de falling
            // Instantiate(BookFallingSound);
            // reinicio timer del respawn
            timer = 0;
        }
        // aumento timer del respawn para que llegue al indicado y respawnee otro carro
        timer += 0.010f;
    }
}
