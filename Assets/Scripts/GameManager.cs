using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //시간 구현
    public Text timeTxt;
    float time = 40.0f;

    public static GameManager instance;

    // 카드비교를 위한 변수선언 
    public Card onecard;
    public Card secondcard;

    //마무리되는 과정의 변수선
    public int cardcount = 0;
    public GameObject EndTxt;
    public GameObject EndPanel;

    //소리변수선언
    public AudioClip TB;
    public AudioClip FB;
    public AudioClip EB;
    public AudioClip LB;
    public AudioSource audioSource;

    private bool isEBPlayed = false;// 긴급한 소리를 불값 false를 사용해서 유무파악 변수 생성.


    private AudioManager audioManager;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        
    }


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();// 오디오 소스에 오디오 소스를 불러온다.

        audioManager = AudioManager.Instance; // 오디오 매니저를 참조로 불러온다.

        //오디오 매니저에 있는 BgPlay를 들고오면 게임 재시작 하더라도 소리가 계속 나올 수 있다.
        audioManager.BgPlay();

    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0.0f)
        {
            time -= Time.deltaTime;// 시간은 감소한다.

        }

        else
        {

            if(isEBPlayed)
            {
                audioSource.Stop();
                isEBPlayed = false;
            }


            audioSource.PlayOneShot(LB);

            time = 40f;
            EndPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        
        timeTxt.text = time.ToString("n2");

        if (time <= 10.0f && !isEBPlayed)
        {

            //audioManager.StopAudio();
            // EB 소리가 아직 재생되지 않았다면 재생
            audioSource.PlayOneShot(EB);
            isEBPlayed = true;

           
         }

        if (time == 0.0f && isEBPlayed)
        {
            isEBPlayed = false;
           
        }


    }

    public void matched()
    {
        if(onecard.idx == secondcard.idx)
        {
            audioSource.PlayOneShot(TB);

            onecard.destroycard();
            secondcard.destroycard();
            cardcount -= 2;


            if (cardcount == 0)
            {
                EndTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            audioSource.PlayOneShot(FB);

            onecard.closecard();
            secondcard.closecard();
        }

        onecard = null;
        secondcard = null;
    }

 
}
