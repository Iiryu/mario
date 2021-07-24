using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Manager : MonoBehaviour
{
    public GameObject bugObject;
    public GameObject player;
    public Controll c;
    public bool gameover;
    public GameObject deadScreen;
    public AudioSource audioSource;
    public GameObject g;
    public GameObject mob;
    public AudioClip deadS;
    public bool bug;
    GameObject[] mobs;
    public List<Vector3> mobsPos = new List<Vector3>();
    public bool goal;
    public bool goaldoor;
    public bool goalDoor;
    // Start is called before the first frame update
    void Start()
    {
        OnRuntimeMethodLoad();
        c = player.GetComponent<Controll>();
        WhenStart();
        gameover = false;
        GetMobPos();
    }

    private void Awake()
    {
        TilemapRenderer a = bugObject.GetComponent<TilemapRenderer>();
    }


    void WhenStart()
    {
        g.GetComponent<TilemapRenderer>().enabled = false;
        g.GetComponent<TilemapRenderer>().enabled = true;
    }

    void OtherScriptCheck()
    {
        if(bug == true)
        {
            WhenStart();
            bug = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        GameOver();
        OtherScriptCheck();
        Goal();
    }

    static void OnRuntimeMethodLoad()
    {
        Screen.SetResolution(1000, 1000, false, 60);
    }

    void GameOver()
    {
        if(gameover == false)
        {
            return;
        }
        else
        {
            Debug.Log("gameover true");
            Invoke("gameOver", 2);
            AudioStop();
            player.gameObject.transform.Translate(0, 0.001f, 0);
            Destroy(player.GetComponent<CapsuleCollider2D>());
            gameover = false;
            goal = false;
        }
    }
    
    void gameOver()
    {
        GameObject[] mobsList = GameObject.FindGameObjectsWithTag("MOB");
        deadScreen.SetActive(true);
        gameover = false;
        Debug.Log("gameOver run");
        foreach (GameObject mobs in mobsList)
        {
            Destroy(mobs);
        }
        goal = false;
    }

    void Goal()
    {
        if(goal == true)
        {
            Debug.Log("goal = true");
            AudioStop();
            Invoke("gameOver", 5f);
            goal = false;
        }
    }

    void AudioStop()
    {
        audioSource.Stop();
    }

    void GetMobPos()
    {
        mobs = GameObject.FindGameObjectsWithTag("MOB");

        for (int i = 0; i < mobs.Length; i++)
        {
            mobsPos.Add(mobs[i].gameObject.transform.position);
        }
    }

    public void Restart()
    {
        goaldoor = false;
        goal = false;
        player.AddComponent <CapsuleCollider2D>();
        player.GetComponent<Controll>().stop = false;
        player.GetComponent<Controll>().poop = false;
        player.gameObject.transform.position = new Vector3(4.623f, 0.674f, 0);
        deadScreen.SetActive(false);
        audioSource.Play();
        Invoke("WhenStart", 0.01f);
        Invoke("WhenStart", 0.02f);
        for (int i = 0; i < mobsPos.Count; i++)
        {
            GameObject a = Instantiate(mob, mobsPos[i], Quaternion.identity);
        }
    }
}
