using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    private  Rigidbody2D rbBackground;
    private  BoxCollider2D bgCollider;
    private float bgHorizontalLength;
    // Start is called before the first frame update

    private void Awake(){
        rbBackground = GetComponent<Rigidbody2D>();
        bgCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        rbBackground.velocity = new Vector2(-5.0f,0);
        bgHorizontalLength = bgCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<= -bgHorizontalLength){
            RepositionBackground();
        }
    }

    private void RepositionBackground(){
        transform.Translate(Vector2.right*bgHorizontalLength*2);
    }
}
