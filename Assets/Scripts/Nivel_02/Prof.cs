using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prof : MonoBehaviour
{
    public Transform[] waypoints;// Array de waypoints para seguirlos en orden
    private float moveSpeed = 3f;// velocidad para caminar
    private int waypointIndex = 0;// Index del actual waypoint

    private Rigidbody2D rbProf;
    private Animator aniProf;
    private Vector3 dir;
    private Vector3 localScale;

    public float maxTime = 0.5f; // tiempo que tiene que transcurrir para que vaya a otro waypoint
    private float timer = 0; // tiempo transcurrito en wl waypoint

    GameObject man;//variable para guardar al man

    //funcion si se desea inicializar un personaje en una determinada posicion
    public void Init(float x,float y){
        transform.position = new Vector2(x,y);
    }

	// Start is called before the first frame update
	void Start () {
        man = GameObject.FindGameObjectWithTag("ManLvl02");//obtenemos al man

        rbProf = GetComponent<Rigidbody2D>();
        aniProf = GetComponent<Animator>();
        localScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        dir = waypoints[waypointIndex].position - transform.position;//para saber a donde se estan dirigiendo

        SetAnimation();
        SetProfSpriteDirection();
        MoveTo();
        BuscarMan();    
	}

    private void SetAnimation(){
        if(dir.x>0 || dir.x<0 || dir.y>0 || dir.y<0){//para cambiar de animacion
            aniProf.SetBool("bMove",true);
        }else if(dir.x==0 && dir.y==0){
            aniProf.SetBool("bMove",false);
        }
    }

    private void SetProfSpriteDirection(){
        if(dir.x > 0){//para que el sprite cambie de direccion
            transform.localScale = new Vector3(localScale.x,localScale.y,localScale.z);
        }else if(dir.x < 0){
            transform.localScale = new Vector3(- localScale.x,localScale.y,localScale.z);
        }
    }

    private void MoveTo()
    {
        //muevo al profesor al waypoint que siga
        transform.position = Vector2.MoveTowards(transform.position,waypoints[waypointIndex].position, moveSpeed *Time.deltaTime);

        float distance = Vector2.Distance(transform.position,waypoints[waypointIndex].position);//distancia del waypoint hacia mi posicion actual      
        if(distance < 0.1f){ // si ya se acerco al waypoint cambia de index
            // print(waypointIndex);

            if(timer >  maxTime){
                if (waypointIndex < waypoints.Length - 1){//saber si ya llego al index maximo
                    waypointIndex += 1;
                }else{
                    waypointIndex = 0;
                }
                timer = 0;
            }
            // aumento timer (estado de espera)
            timer += 0.010f;
        }
    }

    private void BuscarMan(){
        //Obtenemos la distancia entre el Man y el Porfesor
        float distance = Vector2.Distance(transform.position,man.transform.position);

        if(distance<1.3f){//si la distancia es menor a 1.3f (castigarlo)
            print("CERCA" + distance);
            LevelManager_02.lm02.GameOver();
        }
            
    }
}
