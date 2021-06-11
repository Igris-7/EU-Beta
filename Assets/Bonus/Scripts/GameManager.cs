using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject sonido;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(sonido);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
