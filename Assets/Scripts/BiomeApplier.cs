using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeApplier : MonoBehaviour
{
    [SerializeField]
    private bool isGround = false;
    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private Sprite groundCity  = null;
    [SerializeField]
    private Sprite wallCity = null;
    [SerializeField]
    private Sprite groundFlorest = null;
    [SerializeField]
    private Sprite wallFlorest = null;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        switch (Master.Instance.BiomeSelected)
        {
            default:
            case 0:
                //desert

                break;
            case 1:
                //city
                if (isGround)
                {
                    spriteRenderer.sprite = groundCity;
                }
                else
                {
                    spriteRenderer.sprite = wallCity;
                }
                break;
            case 2:
                //florest

                if (isGround)
                {
                    spriteRenderer.sprite = groundFlorest;
                }
                else
                {
                    spriteRenderer.sprite = wallFlorest;
                }
                break;


        }
    }

}
