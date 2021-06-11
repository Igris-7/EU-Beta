using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class ManLvl01 : MonoBehaviour
{
    public LevelManager_01 lm01;
    public GameObject LostLifeSound;
    public GameObject SlideSound;

    //funcion si se desea inicializar un personaje en una determinada posicion
    public void Init(float x,float y){
        transform.position = new Vector2(x,y);
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        //si presiono la tecla w (SUBIR)
        if (Input.GetKeyDown (KeyCode.W)){ 
            //si se encuentra en un rango del carril del medio
            if(transform.position.y > -2.45f && transform.position.y < -1.9f){
                // Debug.Log("entra arriba");
                Instantiate(SlideSound);
                transform.position = new Vector3(-7.0f,-1.5f,-1.0f);
            }
            //si se encuentra en un rango del carril de abajo
            else if(transform.position.y > -3.45f && transform.position.y < -2.9f){
                // Debug.Log("entra medio");
                Instantiate(SlideSound);
                transform.position = new Vector3(-7.0f,-2.5f,-1.0f);
            }
        }
        
        //si presiono la tecla s (BAJAR)
        if (Input.GetKeyDown (KeyCode.S)){ 
            //si se encuentra en un rango del carril de arriba
            if(transform.position.y > -1.45f && transform.position.y < -0.9f){
                // Debug.Log("entra medio");
                Instantiate(SlideSound);
                transform.position = new Vector3(-7.0f,-2.5f,-1.0f);
            }
            //si se encuentra en un rango del carril de medio
            else if(transform.position.y > -2.45f && transform.position.y < -1.9f){
                // Debug.Log("entra abajo");
                Instantiate(SlideSound);
                transform.position = new Vector3(-7.0f,-3.5f,-1.0f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //si el man collisiona con un objeto car, disminuye una vida
        if(collision.gameObject.tag=="Car"){
            LevelManager_01.health -=1;
            Instantiate(LostLifeSound);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
