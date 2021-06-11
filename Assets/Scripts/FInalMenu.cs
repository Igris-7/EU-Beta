using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FInalMenu : MonoBehaviour
{
    public GameObject ButtonSound;
    public float delayTime = 0.3f; // tiempo delay entre scenas

    // Start is called before the first frame update
    public void MenuGame(){
        Instantiate(ButtonSound);
        Invoke("DelayedMenuAction", delayTime);
    }

    void DelayedMenuAction(){
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame(){
        Instantiate(ButtonSound);
        Invoke("DelayedQuitAction", delayTime);
    }

    void DelayedQuitAction(){
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
