using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get { return instance; }
        
    }

    public AudioSource manager; // an object that can play music within its clip class member field

    private void Awake()
    {
        if (instance == null && instance != this) // if instance does not exist, set it
        {
            instance = this;
        }
        else {
            Debug.Log("Cannot have more than 1 singleton"); // if it does, destroy this
            Destroy(this.gameObject);
        }
    }

    public void PlayAudio(AudioClip clipp)
    {
        manager.clip = clipp;
        manager.Play();
    }


}
