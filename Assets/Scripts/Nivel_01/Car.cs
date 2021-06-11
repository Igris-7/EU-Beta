using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private float CarSpeed=10.0f;// velocidad del carro

    //funcion si se desea inicializar un carro en una determinada posicion
    public void Init(float x,float y){
        transform.position = new Vector2(x,y);
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        //avanzo el carro hacia su derecha
        transform.position += Vector3.left * CarSpeed * Time.deltaTime;
    }
}
