using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nam : MonoBehaviour
{
    // Start is called before the first frame update
    public float left,right;
    private bool isRight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // lay vi tri x hien tai cua nam 
        var namX = transform.position.x;
        if(namX<left){
            isRight = true;
        }
        if(namX >right){
            isRight = false;
        }
        if(isRight){
            transform.Translate (new Vector3 (Time.deltaTime *1,0,0));
        }
        else{
            transform.Translate(new Vector3(-Time.deltaTime *1,0,0));
        }
    }
}
