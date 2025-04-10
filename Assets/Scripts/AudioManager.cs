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
        if(Instance == null) // 해당 칸이 비어있다면
        {
            Instance = this; // 싱글톤을 만들었고
            DontDestroyOnLoad(gameObject); // 깨지지 말라고

        }
        else
        {
            Destroy(gameObject); //중복되면 깨지도록 구현.
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();// 오디오 소스에 오디오 소스를 가져온다.(이러면 유니티안에서 오디오 소스를 따로 설정 하지 않아도 된다.)

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
public void BgPlay()// 브금 플레이 변수를 만들어주고.
    {
        audiosource.Stop();// 일단 어떤 오디오 소스가 나올지 모르니 일단 멈춤

        audiosource.clip = clip;// 해당 클립이라는 오디오 소스를 그대로 가져올꺼고.

        audiosource.Play();// 진행시킬꺼에요 -> 이제 게임 매니저로 넘어가서 BgPlay를 Start에 넣어주면 되지 않을까.
    }

    
}
