using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    private AudioSource explosion;

    private void Start()
    {
        explosion = GetComponent<AudioSource>();
    }

    public void PlayExplosion()
    {
        explosion.Play();
    }
}
