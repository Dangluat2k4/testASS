using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
public class dichuyen : MonoBehaviour
{
    [SerializeField] GameObject cong;
    public Animator animator;
    public bool isRight = true;
    private bool nen;
    public GameObject panel, button, text;
    public TextMeshProUGUI diemText;

    public Rigidbody2D rb;
    public GameObject PSBrick;
    private bool isGrounded = false;
    int tong = 0;

    private bool isJumping = false;
    // tao bien chua am thanh coin
    private AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    
    void tinhTong(int score)
    {
        tong += score;
        diemText.text = "Diem :" + tong;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        tinhTong(0);
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;
            animator.SetBool("isRunning", true);
            transform.Translate(Time.deltaTime * 5, 0, 0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            // neu scale >0 thi scale lon hon 0 else
            transform.localScale = scale;
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = false;
            animator.SetBool("isRunning", true);
            transform.Translate(-Time.deltaTime * 5, 0, 0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            // neu scale >0 thi scale lon hon 0 else
            transform.localScale = scale;
        }

        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            if (nen == true && isGrounded)
            {
                if (isRight == true)
                {
                    rb.AddForce(new Vector2(0, 6f), ForceMode2D.Impulse);
                    Vector2 scale = transform.localScale;
                    scale.x = Mathf.Abs(scale.x); // Set the x scale to its absolute value
                    transform.localScale = scale;
                }
                else
                {
                    // animator.SetBool("isRunning", true);
                    //transform.Translate(-Time.deltaTime * 1, 2.0f, 0);
                    rb.AddForce(new Vector2(0, 6f), ForceMode2D.Impulse);
                    Vector2 scale = transform.localScale;
                    scale.y = Mathf.Abs(scale.y); // Set the x scale to its absolute value
                    transform.localScale = scale;

                }
                nen = false;
                isJumping = true;
            }
        }
        // if(isJumping && Input.GetKeyUp(KeyCode.Space)){
        //     isJumping = false;
        // }
        if (cong != null)
        {
            transform.position = cong.GetComponent<congdichchuyen>().GetDiemDichChuyen().position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "nen_dat")
        {
            nen = true;
            isJumping = false;
            isGrounded = true;
        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "nen_dat")
        {
            isGrounded = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "top")
        {
            // Ngăn nhân vật xuyên qua "top" bằng cách đặt lại vận tốc Y của nhân vật thành 0
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
            Debug.Log("o lai voi");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "tren")
        {
            // nam die
            var name = collision.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            tinhTong(10);
            Debug.Log("va cham");
        }
        if(collision.gameObject.tag=="chuyen_man"){
            Debug.Log("chuyen man");
        }
        // if (collision.gameObject.tag == "trai")
        // {
        //     // nguoi die, game over, replace lai man choi
        //     Time.timeScale = 0;// dung sence lai
        //     panel.SetActive(true);// show panel
        //     button.SetActive(true);// show button
        //     text.SetActive(true);// show text

        // }
        // if (collision.gameObject.tag == "right")
        // {
        //     // nguoi die, game over, replace lai man choi
        //     Time.timeScale = 0;// dung sence lai
        //     panel.SetActive(true);// show panel
        //     button.SetActive(true);// show button
        //     text.SetActive(true);// show text
        // }
        // if (collision.gameObject.tag == "button")
        // {
        //     Time.timeScale = 0;
        //     panel.SetActive(true);
        //     button.SetActive(true);
        //     text.SetActive(true);
        // }
        // if (collision.gameObject.tag == "spike")
        // {
        //     Time.timeScale = 0;
        //     panel.SetActive(true);
        //     button.SetActive(true);
        //     text.SetActive(true);
        // }
        // if (collision.gameObject.tag == "bat")
        // {
        //     Time.timeScale = 0;
        //     panel.SetActive(true);
        //     button.SetActive(true);
        //     text.SetActive(true);
        // }
        // if (collision.gameObject.tag == "fall_spike")
        // {
        //     Time.timeScale = 0;
        //     panel.SetActive(true);
        //     button.SetActive(true);
        //     text.SetActive(true);
        // }
        if (collision.gameObject.tag == "coin")
        {
            audioManager.PlaySFX(audioManager.coinClip);
            var name = collision.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            tinhTong(1);
        }
        if (collision.gameObject.tag == "brick")
        {
            var name = collision.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            Instantiate(PSBrick,
            collision.gameObject.transform.position,
            collision.gameObject.transform.localRotation
            );
        }
        if (collision.CompareTag("congdichchuyen"))
        {
            cong = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("congdichchuyen"))
        {
            cong = null;
        }
    }

}
// Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,0.2f);
// foreach(Collider2D collider in colliders){
//     if(collider.CompareTag("top")){
//         Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
//         rigidbody.velocity = new Vector2(rigidbody.velocity.x,0f);
//         break;
//     }
// }