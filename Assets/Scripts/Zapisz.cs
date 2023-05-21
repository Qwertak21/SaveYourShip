using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Zapisz : MonoBehaviour
{
   
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    public AudioClip[] letterSounds;

    private AudioSource audioSource;
    [HideInInspector]
    public Slider slider;
    private float _multiplier;
   
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            PlayLetterSound(0); // Przyk�ad: Odtwarzanie d�wi�ku dla litery A
        }
        
        // Dodaj instrukcje warunkowe dla innych liter klawiatury, tak jak w przypadku litery A.
    }

    private void PlayLetterSound(int index)
    {
        if (index >= 0 && index < letterSounds.Length)
        {
            audioSource.clip = letterSounds[index];
            audioSource.Play();
            // Odczytaj aktualn� warto�� g�o�no�ci z miksera d�wi�ku
           float _volumeValue ;// na poc�tku pobieramy zapisane parametry dzwi�ku
           
           // 
            if (mixer.GetFloat(volumeParameter, out _volumeValue))
            {
                // Przelicz warto�� g�o�no�ci dla audioSource na podstawie warto�ci z miksera
                float soundVolume = Mathf.Pow(10f, _volumeValue / _multiplier);
                audioSource.volume = soundVolume;
            }
        }
    }
    
}


