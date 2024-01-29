using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{
    // Start is called before the first frame update
    public float left, right;
    public bool isRight;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // lay vi tri hien tai cua bat 
        var batX = transform.position.x;
        if (batX < left)
        {
            isRight = true;
        }
        if (batX > right)
        {
            isRight = false;
        }
        if (isRight)
        {
            transform.Translate(new Vector3(Time.deltaTime * 1, 0, 0));
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            // neu scale >0 thi scale lon hon 0 else
            transform.localScale = scale;
        }
        else
        {
            transform.Translate(new Vector3(-Time.deltaTime * 1, 0, 0));
            Vector2 scale = transform.lossyScale;
            scale.x *= scale.x >0?-1:1;
            transform.localScale = scale;
        }

    }
}
