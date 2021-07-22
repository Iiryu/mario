using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
    float horizontal = 0f;
    public Rigidbody2D rb;
    public AudioClip jump;
    public AudioSource audioSource;
    public bool dead;
    public Animator anim = null;
    public bool isGround;
    public SpriteRenderer r;
    public Manager m;
    public bool bigver = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        r = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
        m.player.transform.position = this.gameObject.transform.position;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump")&& isGround == true)
        {
            audioSource.PlayOneShot(jump);
            rb.AddForce(transform.up * 190);
            anim.SetBool("Jump", true);
        }
        if (isGround == true)
        {
            anim.SetBool("Jump", false);
        }
    }

    void Move()
    {
        if (Input.GetKey("a"))
        {
            r.flipX = true;
            anim.SetBool("Run", true);
            transform.position -= transform.right * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            r.flipX = false;
            anim.SetBool("Run", true);
            transform.position += transform.right * Time.deltaTime;
        }
        else
        {
            anim.SetBool("Run", false);
            Debug.Log("a");
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        isGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGround = false;
        Debug.Log("jump");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MOB")
        {
            m.gameover = true;
            Debug.Log("mob");
        }
        if (collision.gameObject.tag == "beBig")
        {
            bigver = true;
            Debug.Log("big");
        }
    }


}
