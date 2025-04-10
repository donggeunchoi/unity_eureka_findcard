using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{

    //카드에 대한 변수
    public Transform cards;
    public GameObject card;

    public float spreadTime = 0.5f; //카드가 퍼지는 시간
    public Vector2 startPosition = new Vector2(0, 0); // 시작 위치

    // Start is called before the first frame update
    void Start()
    {
        //랜덤으로 배열을 만들기 위한 변수선언 및 랜덤 뽑기
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
        arr = arr.OrderBy(x => Random.Range(0f, 9f)).ToArray();

        for (int i = 0; i < 20; i++)
        {
            GameObject go = Instantiate(card, this.transform);
            go.transform.parent = cards;

            //카드 배열
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.5f;

            go.transform.position = new Vector2(x, y);


            //card스크립트 불러오기
            go.GetComponent<Card>().setting(arr[i]);
            Debug.Log(arr[i]);


            GameManager.instance.cardcount = arr.Length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
