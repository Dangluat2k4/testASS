using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpad : MonoBehaviour
{
    // Start is called before the first frame update
    public float doNay = 10f;
    private SpriteRenderer spriteRenderer;
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("play1")){
            collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up* doNay,ForceMode2D.Impulse);
            spriteRenderer.color = Color.red;
        }
    }
    private void OnTriggerExit2D(Collider2D collider){
        if(collider.CompareTag("play1")){
            spriteRenderer.color = Color.yellow;
        }
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
