using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    //add sounds to this file and play them in the game
    [SerializeField]
    public AudioClip startSound;
    public AudioSource audioSource;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayStartSound()
    {
        audioSource.clip = startSound;
        audioSource.Play();
    }
}