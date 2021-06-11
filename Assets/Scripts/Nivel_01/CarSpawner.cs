using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float maxTime = 1; // tiempo que tiene que transcurrir para respawnear
    public float timer = 0; // tiempo transcurrito respawn
    public GameObject car0,car1,car2,car3,car4,car5,car6; // objetos que conteneran los prefabs de los carros
    private System.Random rnd = new System.Random(); // variable para generar randoms
    private GameObject[] array_cars = new GameObject[7]; // array en donde se insertaran los gameobjects de los carros
   
    // Start is called before the first frame update
    void Start(){
        //inserto los carros en el array
        array_cars[0] = (GameObject) car0;
        array_cars[1] = (GameObject) car1;
        array_cars[2] = (GameObject) car2; 
        array_cars[3] = (GameObject) car3;
        array_cars[4] = (GameObject) car4; 
        array_cars[5] = (GameObject) car5; 
        array_cars[6] = (GameObject) car6;
        // Instantiate(car6);
    }

    // Update is called once per frame
    void Update(){
        if(timer >  maxTime){
            // genero indice random para indicar que carro spawnear
            int index_car  = rnd.Next(0, 6);
            // genero random para indicar en que carril spawnear
            int rnd_carril  = rnd.Next(1, 4);
            float carril_car = -0.8f-rnd_carril;
            // instancio el carro a spawnear
            GameObject newcar= Instantiate(array_cars[index_car]);
            // cambio el orden del layer para que si se juntan vayan en orden de acuerdo al carril
            Renderer target = newcar.GetComponent<Renderer>();
            target.sortingOrder = rnd_carril;
            // ubico el carro en su posicion de inicio
            newcar.transform.position = new Vector2(12.0f,carril_car);
            // destruyo el carro despues de un tiempo de spawnear
            Destroy(newcar,2.3f);
            // reinicio timer del respawn
            timer = 0;
        }
        // aumento timer del respawn para que llegue al indicado y respawnee otro carro
        timer += 0.010f;
    }
}
