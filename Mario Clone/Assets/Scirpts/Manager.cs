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
    // Start is called before the first frame update
    void Start()
    {
        OnRuntimeMethodLoad();
        c = player.GetComponent<Controll>();
    }

    private void Awake()
    {
        TilemapRenderer a = bugObject.GetComponent<TilemapRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
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
            deadScreen.SetActive(true);
            audioSource.Stop();
            Debug.Log("a");
            gameover = false;
        }
    }

    void Restart()
    {
        player.gameObject.transform.position = new Vector3(4.623f, 0.674f, 0);
        deadScreen.SetActive(false);
        audioSource.Play();
    }
}
