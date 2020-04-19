using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    void Start()
    {
        float rng = Random.Range(0.5f, 2f);
        transform.localScale = new Vector3(rng, rng, 1);
    }
}
