using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audiosource;
    public AudioClip clip;

   

    

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();

        audiosource.clip = this.clip;
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StopAudio()
    {
        audiosource.Stop();
    }


    
}
