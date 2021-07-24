using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuckoffUnity : MonoBehaviour
{
    public Manager m;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m.goaldoor = true;
        m.goalDoor = true;
    }
}
