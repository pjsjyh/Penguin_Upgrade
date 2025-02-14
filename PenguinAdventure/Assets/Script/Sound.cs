using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    AudioClip clickSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clickSound = GetComponent<AudioClip>();
    }

    public void PlaySound()
    {
        // 사운드 재생 (한 번만 재생됨)
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
