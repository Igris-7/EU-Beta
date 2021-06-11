using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager_02 : MonoBehaviour
{
    public ManLvl02 man;
    public Prof prof;
    public static bool getExam; 

    public static LevelManager_02 lm02; 
    public GameObject Sountrack;

    public GameObject gameOverCanvas;
    public GameObject GameOverSound;

    public GameObject levelPassedCanvas;
    public GameObject levelPassedSound;
    float timeCanvas;
    
    // Start is called before the first frame update
    void Start(){
        lm02 = this;//la variable level manager la igualamos a este mismo script

        Time.timeScale = 1;//dejo que el tiempo corra
        gameOverCanvas.SetActive(false);//desactivamos el canvas gameover
        GameOverSound.SetActive(false);//desactivamos el audio del gameover
        
        levelPassedCanvas.SetActive(false);//desactivamos el canvas levelpassed
        levelPassedSound.SetActive(false);//desactivamos el audio del levelpassed
        timeCanvas=3.5f;//segundos que durara el canvas de level passed

        // inicializo a los profesores con una ubicacion determinada 
        Prof prof_01 = Instantiate(prof) as Prof; prof_01.Init(-6.92f,3.45f);
        Prof prof_02 = Instantiate(prof) as Prof; prof_02.Init(3.83f,2.67f); 
        // Prof prof_03 = Instantiate(prof) as Prof; prof_01.Init(5.0f,-2.5f);

        getExam = false;//decimos que aun no se ha recogido el examen

        Instantiate(man);
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void GameOver(){
        Sountrack.SetActive(false); // desactivamos sountrack del nivel
        gameOverCanvas.SetActive(true);//activamos el canvas de gameover
        GameOverSound.SetActive(true);// inicializamos audio del gameover

        Time.timeScale = 0;//detengo el tiempo del juego
    }

    public void LevelPassed(){
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
