using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall_Trap : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
        public GameObject panel, button, text;
    private bool daRoi = false;
    // diem roi song sau 1 thoi gian se hoi phuc
    public Transform diemKhoiPhuc;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D conliision)
    {
        if (conliision.CompareTag("play1") && !daRoi)
        {
            rb.isKinematic = false;
            daRoi = true;
            Invoke("KhoiPhuc", 2f);
        }
    }
    private void KhoiPhuc()
    {
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        rb.angularDrag = 0;
        transform.position = diemKhoiPhuc.position;
        daRoi = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
