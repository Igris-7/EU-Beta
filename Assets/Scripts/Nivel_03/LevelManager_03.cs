using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager_03 : MonoBehaviour
{
    public GameObject BadBookSpawner; // el objecto respawner
    public Image life01,life02,life03,life04,life05;// los corazones
    public static int health; 
    public static int nroGoldBooks; 
    public TextMeshProUGUI txtScoreBook; 
    public static LevelManager_03 lm03; 
    public GameObject Sountrack;

    public GameObject gameOverCanvas;
    public GameObject GameOverSound;

    // Start is called before the first frame update
    void Start(){
        lm03 = this;//la variable level manager la igualamos a este mismo script

        health = 5;//inicializo cantidad de vidas
        nroGoldBooks=0;//inicializo cantidad de los libros recogidos en cero

        Time.timeScale = 1;//dejo que el tiempo corra
        gameOverCanvas.SetActive(false);//desactivamos el canvas gameover
        GameOverSound.SetActive(false);//desactivamos el audio del gameover
    }

    // Update is called once per frame
    void Update(){
        //comprobamos la vida y la seteamos
        if(health>5){ health=5; } //si la vida sobrepasa los 5 lo igualamos a 5
        switch (health){//hacemos el display correspondiente a cuantos corazones tenemos
            case 5:
                life01.enabled = true;
                life02.enabled = true;
                life03.enabled = true;
                life04.enabled = true;
                life05.enabled = true;
                break;
            case 4:
                life01.enabled = true;
                life02.enabled = true;
                life03.enabled = true;
                life04.enabled = true;
                life05.enabled = false;
                break;
            case 3:
                life01.enabled = true;
                life02.enabled = true;
                life03.enabled = true;
                life04.enabled = false;
                life05.enabled = false;
                break;
            case 2:
                life01.enabled = true;
                life02.enabled = true;
                life03.enabled = false;
                life04.enabled = false;
                life05.enabled = false;
                break;
            case 1:
                life01.enabled = true;
                life02.enabled = false;
                life03.enabled = false;
                life04.enabled = false;
                life05.enabled = false;
                break;
            case 0:
                life01.enabled = false;
                life02.enabled = false;
                life03.enabled = false;
                life04.enabled = false;
                life05.enabled = false;
                GameOver();
                break;
        } 
    }

    public void GameOver(){
        Sountrack.SetActive(false); // desactivamos sountrack del nivel
        BadBookSpawner.SetActive(false) ;// desactivamos el car spawner

        gameOverCanvas.SetActive(true);//activamos el canvas de gameover
        GameOverSound.SetActive(true);// inicializamos audio del gameover

        Time.timeScale = 0;//detengo el tiempo del juego
    }

    public void SumarPuntajeBook(){
        nroGoldBooks++;//sumo al contador de libros
        txtScoreBook.text = "X " +  nroGoldBooks.ToString();//muestro en el canvas
        if(nroGoldBooks==10){//si recolecto los 10 libros, paso el nivel
            LevelPassed();
        }
    }

    public void LevelPassed(){
        Sountrack.SetActive(false); 
        BadBookSpawner.SetActive(false) ;
        SceneManager.LoadScene("GamePassed");
    }
}
