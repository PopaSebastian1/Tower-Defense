using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public AudioClip backgroundMusic;
    public AudioSource audioSource;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.Play();
        audioSource.loop = true;
        audioSource.volume = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {

    }
  
}
