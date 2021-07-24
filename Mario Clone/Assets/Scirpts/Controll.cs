using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
    public Rigidbody2D rb;
    public AudioClip jump;
    public AudioSource audioSource;
    public Animator anim = null;
    public bool isGround;
    public SpriteRenderer r;
    public Manager m;
    public bool stop;
    public bool bigver = false;
    public AudioClip deadS;
    public AudioClip killMob;
    public bool dead = false;
    public GameObject goalpool;
    int i;
    int a;
    float b;
    public bool poop = false;
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
        Dead();
        GoalMove();
        DeadCheck();
        m.player.transform.position = this.gameObject.transform.position;
    }

    void Jump()
    {
        if(stop == false)
        {
            if (Input.GetButtonDown("Jump") && isGround == true)
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
    }

    void Dead()
    {
        if(dead == true)
        {
            audioSource.PlayOneShot(deadS);
            dead = false;
        }
    }

    void DeadCheck()
    {
        if(dead == false)
        {
            if (this.gameObject.transform.position.y <= 0)
            {
                if (i == 0)
                {
                    i += 1;
                    dead = true;
                    m.gameover = true;
                    Debug.Log("this gameobject pos -y");
                }
            }
        }
    }

    void Move()
    {
        if (stop == false)
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
            }
        }
    }

    void GoalMove()
    {
        if(m.goal == true)
        {
            stop = true;
            poop = true;

            if (a == 0)
            {
                a += 1;
                this.gameObject.transform.position = goalpool.gameObject.transform.position;
            }
        }
        if (m.goaldoor == false)
        {
            if (poop == true)
            {
                transform.position += transform.right * Time.deltaTime;
                Debug.Log("true");
            }
        }

        if (m.goalDoor == true)
        {
            Debug.Log("a");
            m.gameover = false;
            m.goal = false;
            m.goaldoor = false;
            poop = false;
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
            dead = true;
            Debug.Log("dead");
        }
        if (collision.gameObject.tag == "beBig")
        {
            bigver = true;
            Debug.Log("big");
        }
        if (collision.gameObject.tag == "CanKill")
        {
            audioSource.PlayOneShot(killMob);
            Destroy(collision.gameObject.transform.parent.gameObject);
            rb.AddForce(transform.up * 120);
            Debug.Log("kill");
            m.bug = true;
        }
    }


}
