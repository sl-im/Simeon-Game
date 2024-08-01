using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager Instance {get; private set;}
    
    public Sound[] sounds;

    // Update is called once per frame
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else 
        {
            Destroy(gameObject);
        }
    

        DontDestroyOnLoad(gameObject);


        foreach (Sound s in sounds)
        {
            
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;   
        }
    }


    private void Start()
    {
        PlaySound("MainTheme");
    }


    public void PlaySound(string name)
    {
        Sound sound = System.Array.Find(sounds, sound => sound.name == name);


        if (sound == null)
        {
            Debug.LogWarning("could not find" + name + "sound!");
            return;
        }

        sound.audioSource.Play();    
    }


    public void StopSound(string name)
    {
        Sound sound = System.Array.Find(sounds, sound => sound.name == name);

        if(sound == null)
        {
            Debug.LogWarning("Could not find" + name + " sound!");
            return;

        }

        sound.audioSource.Stop();
    }
}