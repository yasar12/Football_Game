using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource src;
    public AudioClip whistle;
    public AudioClip kick;

    private static AudioManager instance;

    private void Awake()
    {
        instance = this;
        //src = GetComponent<AudioSource>();
    }
    private void Start()
    {
        PlayWhistleSound();
    }
    public static void PlayWhistleSound()
    {
        instance.src.clip = instance.whistle;
       instance.src.Play();
    }

    public static void PlayKickSound()
    {
        instance.src.clip = instance.kick;
        instance.src.Play();
    }
}
