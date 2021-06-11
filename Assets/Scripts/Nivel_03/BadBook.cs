using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        Physics2D.IgnoreLayerCollision(12 , 13, true);
    }

    // Update is called once per frame
    void Update(){
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        string tag =collision.gameObject.tag;
        if(tag=="ManLvl03" ||tag =="Piso" ){
            Destroy(gameObject,0.1f);
        }
    }
}
