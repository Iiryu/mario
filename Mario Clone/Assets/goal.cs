using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class goal : MonoBehaviour
{
    public AudioClip goalAudio;
    public AudioSource audioSource;
    public Manager m;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
    }

    void WhenStart()
    {
        this.gameObject.GetComponent<TilemapRenderer>().enabled = false;
        this.gameObject.GetComponent<TilemapRenderer>().enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (m.goaldoor == true)
        {
            i = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(i == 0)
        {
            Debug.Log("goal");
            audioSource.PlayOneShot(goalAudio);
            Invoke("Goal", 10f);
            m.goal = true;
            i += 1;
        }
    }

    void Goal()
    {

    }

}
