using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager_01 : MonoBehaviour
{
    public ManLvl01 man;
    public GameObject CarSpawner; // el objecto respawner
    public GameObject life01,life02,life03;// los corazones
    public static int health; 
    
    public static LevelManager_01 lm01; 
    public GameObject Sountrack;

    public GameObject gameOverCanvas;
    public GameObject GameOverSound;

    public GameObject levelPassedCanvas;
    public GameObject levelPassedSound;
    float timeCanvas;

    // Start is called before the first frame update
    void Start(){
        lm01 = this;//la variable level manager la igualamos a este mismo script
     
        health = 3;//inicializo cantidad de vidas
        // life01.SetActive(true);//inicializo los corazones (no necesario por que los tengo en el inspector)
        //life01.SetActive(true);
        // life03.SetActive(true);
           
        Time.timeScale = 1;//dejo que el tiempo corra
        gameOverCanvas.SetActive(false);//desactivamos el canvas gameover
        GameOverSound.SetActive(false);//desactivamos el audio del gameover

        levelPassedCanvas.SetActive(false);//desactivamos el canvas gameover
        levelPassedSound.SetActive(false);//desactivamos el audio del levelpassed
        timeCanvas=3.5f;//segundos que durara el canvas de level passed

        Instantiate(man);// inicializo al personaje con su ubicacion predeterminada
        // ManLvl01 man1 = Instantiate(man) as ManLvl01;man1.Init(-7.0f,-2.5f); // inicializo al personaje con una ubicacion determinada 
    }

    // Update is called once per frame
    void Update(){
        //comprobamos la vida y la seteamos
        //if(health>3){ health=3; } //si la vida sobrepasa los 3 lo igualamos a 3
        switch (health){//hacemos el display correspondiente a cuantos corazones tenemos
            case 3:
                life01.SetActive(true);
                life02.SetActive(true);
                life03.SetActive(true);
                break;
            case 2:
                life01.SetActive(true);
                life02.SetActive(true);
                life03.SetActive(false);
                break;
            case 1:
                life01.SetActive(true);
                life02.SetActive(false);
                life03.SetActive(false);
                break;
            case 0:
                life01.SetActive(false);
                life02.SetActive(false);
                life03.SetActive(false);
                GameOver();
                break;
        } 
    }
    
    public void GameOver(){
        Sountrack.SetActive(false); // desactivamos sountrack del nivel
        CarSpawner.SetActive(false) ;// desactivamos el car spawner
        gameOverCanvas.SetActive(true);//activamos el canvas de gameover
        GameOverSound.SetActive(true);// inicializamos audio del gameover

        Time.timeScale = 0;//detengo el tiempo del juego
    }

    public void LevelPassed(){
        CarSpawner.SetActive(false);// desactivamos el car spawner
        health=3;//reiniciamos la salud
        Sountrack.SetActive(false); // desactivamos sountrack del nivel
        levelPassedCanvas.SetActive(true);//activamos el canvas de levelpassed
        levelPassedSound.SetActive(true);// inicializamos audio del levelpassed
        DelayedLevelPassedAction();
    }

    void DelayedLevelPassedAction(){
        if(timeCanvas > 0){ 
            timeCanvas -= Time.deltaTime;
        }else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
