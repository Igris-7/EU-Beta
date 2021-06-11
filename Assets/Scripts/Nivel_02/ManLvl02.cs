using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManLvl02 : MonoBehaviour
{
    private Rigidbody2D rbMan;
    private Animator aniMan;
    private float dirX,dirY;
    public float moveSpeed;
    private Vector3 localScale;


    GameObject profObject;//variable para guardar al profeAI

    public GameObject ClickSound;

    // public LevelManager_02 lm02;

    // Start is called before the first frame update
    void Start(){
        rbMan = GetComponent<Rigidbody2D>();
        aniMan = GetComponent<Animator>();
        moveSpeed = 3f;
        localScale = transform.localScale;

        profObject = GameObject.FindGameObjectWithTag("Profesor");//obtenemos a los profesores
    }

    // Update is called once per frame
    void Update(){
        dirX = Input.GetAxisRaw("Horizontal")*moveSpeed;
        dirY = Input.GetAxisRaw("Vertical")*moveSpeed;


        SetAnimation();
        GetCaughtByAI(); 
        CheckManFinishedLevel(); 
    }

    private void FixedUpdate(){
        rbMan.velocity = new Vector2(dirX,dirY);//moverse
    }

    private void LateUpdate(){
        if(rbMan.velocity.x > 0){//cambiar direccion del sprite
            transform.localScale = new Vector3(localScale.x,localScale.y,localScale.z);
        }else if(rbMan.velocity.x < 0){
            transform.localScale = new Vector3(- localScale.x,localScale.y,localScale.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name == "PcProfe"){//si colisiona con la pc del profe
            if(LevelManager_02.getExam == false){
                Instantiate(ClickSound);//sonido de click
                GameObject Exam = GameObject.FindGameObjectWithTag("Examen");//buscamos el objeto examen
                Exam.SetActive(false);//desactivamos objeto examen (tbm se podria destruir)
                LevelManager_02.getExam =true;// seteamos la bandera de conseguido con true
                print("conseguido");
            }
        }
    }

    private void SetAnimation(){
        if(dirX>0 || dirY>0 || dirX<0 || dirY<0){//para cambiar animacion
            aniMan.SetFloat("dMove",1.0f);
        }else if(dirX==0 && dirY==0){
            aniMan.SetFloat("dMove",0.0f);
        }
    }

    private void GetCaughtByAI(){
        //Obtenemos la distancia entre el Man y el Porfesor
        float distance = Vector2.Distance(transform.position,profObject.transform.position);

        if(distance<1.3f){//si la distancia es menor a 1.3f (castigarlo)
            print("Man Cerca: " + distance);
            LevelManager_02.lm02.GameOver();
        }
    }

    private void CheckManFinishedLevel(){
        if(transform.position.x>8.5f && LevelManager_02.getExam == true ){//saber si ya llego a posicion exit y si ya recogio el examen
            LevelManager_02.lm02.LevelPassed();
        }
    }
}
