using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;
    [SerializeField]
    private AudioClip jumpSound = null;
    [SerializeField]
    private AudioClip deathSound = null;
    private AudioSource source = null;
    private void Awake() => Instance = this;

    private void Start()
    {
        source = GetComponent<AudioSource>();

    }

    public void PlayJumpSound()
    {
        source.Stop();
        source.clip = jumpSound;
        source.Play();
    }
    public void PlayDeathSound()
    {
        source.Stop();
        source.clip = deathSound;
        source.Play();

    }

}
