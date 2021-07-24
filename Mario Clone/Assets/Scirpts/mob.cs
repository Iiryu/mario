using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob : MonoBehaviour
{
    bool a;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("A", 3f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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


    void A()
    {
        a = !a;
    }


}
