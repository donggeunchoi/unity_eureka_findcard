using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Card : MonoBehaviour
{
    public int idx = 0;

    public SpriteRenderer frontim;

    public GameObject front;
    public GameObject back;
    public Animator anim;

    public AudioClip clip;
    public AudioSource audiosource;



    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setting(int number)
    {
        idx = number;
        frontim.sprite = Resources.Load<Sprite>($"first{idx}");
    }

    public void opencard()
    {
        audiosource.PlayOneShot(clip);

        anim.SetBool("isopen", true);
        front.SetActive(true);
        back.SetActive(false);

        if(GameManager.instance.onecard == null)
        {
            GameManager.instance.onecard = this;
        }
        else
        {
            GameManager.instance.secondcard = this;
            GameManager.instance.matched();
        }
    }


    public void destroycard()
    {
        Invoke("destroycardinvoke", 1.0f);
    }

    void destroycardinvoke()
    {
        Destroy(gameObject);
    }


    public void closecard()
    {
        Invoke("closecardinvoke", 1.0f);
    }

    void closecardinvoke()
    {
        anim.SetBool("isopen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
