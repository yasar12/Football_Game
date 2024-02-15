using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_click_sound : MonoBehaviour
{
   public void button_click()
    {
        AudioSource clip = GetComponent<AudioSource>();
        clip.enabled = enabled;
        clip.Play();

    }
}
