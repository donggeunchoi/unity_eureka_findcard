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

    private bool isEBPlayed = false;


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
        audioSource = GetComponent<AudioSource>();

        audioManager = AudioManager.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0.0f)
        {
            time -= Time.deltaTime;

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
