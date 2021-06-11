using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManLvl03 : MonoBehaviour
{
    private Rigidbody2D rbMan;
    private Animator aMan;
    public GameObject LostLifeSound;
    public GameObject JumpSound;
    // public SpriteRenderer srMan;
    private float moveSpeed = 4.5f;
    private int jumpPower = 280 ;
    private float dirX;

    private Vector3 localScale;
    // Start is called before the first frame update
    void Start(){
        rbMan = GetComponent<Rigidbody2D>();
        aMan = GetComponent<Animator>();
        aMan.SetBool("bPiso",false);

        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update(){
        dirX = Input.GetAxisRaw("Horizontal");
        SetAnimation();
        Control();
    }

    private void LateUpdate(){
        if(rbMan.velocity.x > 0){//cambiar direccion del sprite
            transform.localScale = new Vector3(localScale.x,localScale.y,localScale.z);
        }else if(rbMan.velocity.x < 0){
            transform.localScale = new Vector3(- localScale.x,localScale.y,localScale.z);
        }
    }

    void OnCollisionStay2D(Collision2D collision){
        string tag = collision.gameObject.tag;
        if((tag=="Superficie" || tag=="Piso" || tag=="SuperficieMovil") && Input.GetAxis("Jump")==0){
            aMan.SetBool("bPiso",true); 
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag=="SuperficieMovil"){
            transform.parent = collision.transform;
        }
        //si el man collisiona con un objeto car, disminuye una vida
        if(collision.gameObject.tag=="BadBook"){
            LevelManager_03.health -=1;
            Instantiate(LostLifeSound);
            // LevelManager_03.lm03.LostLife();
        }
        if(collision.gameObject.tag=="GoldBook"){
            LevelManager_03.health +=1;
            LevelManager_03.lm03.SumarPuntajeBook();
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        // Excluímos como hijo de la plataforma a cualquier objeto que se separe de ella
        if(collision.gameObject.tag=="SuperficieMovil"){
            transform.parent = null;
        }
    }

    private void SetAnimation(){
        if(dirX>0||dirX<0){//para cambiar animacion
            aMan.SetFloat("dMove",1.0f);
        }else if(dirX==0){
            aMan.SetFloat("dMove",0.0f);
        }
    }

    private void Control(){
        //control derecha - izquierda
        rbMan.velocity = new Vector2(dirX*moveSpeed,rbMan.velocity.y);
        //control salto
        if(Input.GetAxis("Jump")>0 && aMan.GetBool("bPiso")==true){//si apreto space y estoy pisando piso salto
            aMan.SetBool("bPiso",false);//digo que no esta pisando piso
            Jump();
        }
    }

    private void Jump(){
        Instantiate(JumpSound);
        rbMan.AddForce(Vector2.up*jumpPower);//salto
    }
}
