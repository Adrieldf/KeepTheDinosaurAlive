using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Master : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;
    private float nextPosition = 450f;
    private float posToInsert = 490f;
    private float increaseAmount = 500f;
    [SerializeField]
    private GameObject groundParent = null;
    [SerializeField]
    private GameObject ground = null;
    [SerializeField]
    private GameObject skyParent = null;
    [SerializeField]
    private GameObject sky = null;
    [SerializeField]
    private TextMeshProUGUI score = null;


    private void FixedUpdate()
    {
        if (player.transform.position.x > nextPosition)
        {
            nextPosition += increaseAmount;
            Instantiate(sky, new Vector3(posToInsert, 0f, 0f), Quaternion.identity, skyParent.transform);
            Instantiate(ground, new Vector3(posToInsert, 0.02f, 0f), Quaternion.identity, groundParent.transform);
            posToInsert += increaseAmount;
        }
    }
    private void Update()
    {
        score.text = player.transform.position.x.ToString("N0");
    }
}
