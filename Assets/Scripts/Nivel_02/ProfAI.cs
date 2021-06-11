using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ProfAI : MonoBehaviour
{
    private Rigidbody2D rbProf;
    private Animator aniProf;
    public float ProfSpeed;
    private Vector3 dir;
    private Vector3 localScale;

    public float waitTime;
    public float startWaitTime;

    public Transform moveSpot;
    public float minX,maxX,minY,maxY;

    private bool coli=false;

    // GameObject man;//variable para guardar al man

    // Start is called before the first frame update
    void Start(){
        // man = GameObject.FindGameObjectWithTag("ManLvl02");//obtenemos al man

        rbProf = GetComponent<Rigidbody2D>();
        aniProf = GetComponent<Animator>();
        localScale = transform.localScale;

        waitTime = startWaitTime;
        moveSpot.position = getRandomPosition();
    }

    // Update is called once per frame
    void Update(){
        dir = moveSpot.position - transform.position;//para saber a donde se estan dirigiendo

        SetAnimation();
        SetProfSpriteDirection();
        MoveTo();
        // BuscarMan();    
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Fornitures" || collision.gameObject.tag == "Delimitador"){
            coli = true;
        }
    }
    
     private void SetAnimation(){
        if(dir.x>0 || dir.x<0 || dir.y>0 || dir.y<0){
            aniProf.SetBool("bMove",true);
        }else if(dir.x==0 && dir.y==0){
            aniProf.SetBool("bMove",false);
        }
    }

    private void SetProfSpriteDirection(){
        if(dir.x > 0){
            transform.localScale = new Vector3(localScale.x,localScale.y,localScale.z);
        }else if(dir.x < 0){
            transform.localScale = new Vector3(- localScale.x,localScale.y,localScale.z);
        }
    }

    private void MoveTo(){
        transform.position = Vector2.MoveTowards(transform.position,moveSpot.position,ProfSpeed * Time.deltaTime);
        float distance = Vector2.Distance(transform.position,moveSpot.position);
        
        if(distance < 0.2f || coli==true){
            moveSpot.position  = getRandomPosition();
            waitTime = startWaitTime;
            coli=false;
        }else{
            waitTime -= Time.deltaTime;
        }
    }

    private Vector2 getRandomPosition(){
        return new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
    }

    // private void BuscarMan(){
    //     //Obtenemos la distancia entre el Man y el Porfesor
    //     float distance = Vector2.Distance(transform.position,man.transform.position);

    //     if(distance<1.3f){//si la distancia es menor a 1.3f (castigarlo)
    //         print("CERCA" + distance);
    //         LevelManager_02.lm02.GameOver();
    //     }
            
    // }
}
