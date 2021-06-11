using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject ButtonSound;
    public float delayTime = 0.3f; // tiempo delay entre scenas

    public void PlayGame(){
        Instantiate(ButtonSound);
        Invoke("DelayedPlayAction", delayTime);
    }

    void DelayedPlayAction(){
        // SceneManager.LoadScene("Nivel_01");
        // SceneManager.LoadScene(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Start is called before the first frame update
    public void QuitGame(){
        Instantiate(ButtonSound);
        Invoke("DelayedQuitAction", delayTime);
    }

    void DelayedQuitAction(){
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void RetryGame(){
        Instantiate(ButtonSound);
        Invoke("DelayedRetryAction", delayTime);
        
    }

    void DelayedRetryAction(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
