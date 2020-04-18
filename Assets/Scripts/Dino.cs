using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb = null;
    [SerializeField]
    private float speed = 10f;
    void Start()
    {

    }

    void Update()
    {
        Vector2 vel = new Vector2(speed, 0);

        rb.velocity = vel;
    }
}
