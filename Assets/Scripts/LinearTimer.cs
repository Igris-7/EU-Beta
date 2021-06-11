using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LinearTimer : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 30.0f; // tiempo maximo del nivel
    float timeLeft;
    // public GameObject LevelPassScene;

    // Start is called before the first frame update
    void Start(){
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update(){
        if(timeLeft > 0){ // vamos disminuyendo el tiempo
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }else{
            if(SceneManager.GetActiveScene().name == "Nivel_01"){
                // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                LevelManager_01.lm01.LevelPassed();
            }else if(SceneManager.GetActiveScene().name == "Nivel_02"){
                LevelManager_02.lm02.GameOver();//aqui tenemos que cambiar por la scena siguiente o un canvas de nivel pasado
            }
        }
    }
}
