using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;
    [SerializeField]
    private GameObject[] walls = null;
    private float minDistance = 50f;
    private float lastPosSpawned = 50f;

    void Update()
    {
        if (player.transform.position.x > lastPosSpawned)
        {
            int rng = Random.Range(1, 31);
            if(rng == 1)
            {
                lastPosSpawned = player.transform.position.x + minDistance;
                Instantiate(walls[Random.Range(0, 2)], new Vector3(lastPosSpawned, 0, 0),Quaternion.identity, gameObject.transform);
            }

        }

    }
}
