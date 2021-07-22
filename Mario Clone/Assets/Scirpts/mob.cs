using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob : MonoBehaviour
{
    bool a;
    public Manager m;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DeadCheck();
    }

    void Move()
    {
        if(a == true)
        {
            this.gameObject.transform.Translate(0.001f, 0, 0);
        }
        else
        {
            this.gameObject.transform.Translate(-0.001f, 0, 0);
        }
    }

    void DeadCheck()
    {
        if (m.gameover == false)
        {
            Move();
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        a = true;
    }
}
