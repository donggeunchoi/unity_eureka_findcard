using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{

    //카드에 대한 변수
    public Transform cards; // 카드들을 넣으 부모 오브젝트
    public GameObject card; // 카드 프리

    public float spreadTime = 0.5f;//카드가 펼쳐지는 시간
    public Vector2 startPosition = new Vector2(0, 0);//시작하는 위치

    void Start()
    {
        //랜덤으로 배열을 만들기 위한 변수선언 및 랜덤 뽑기
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
        arr = arr.OrderBy(x => Random.Range(0f, 9f)).ToArray();

        StartCoroutine(SpreadCard(arr));
        //카드 생성 코루틴 시작 (배열 전달)

        GameManager.instance.cardcount = arr.Length;
        //게임 오브젝트의 카드 카운터는 위에 배열의 길이입니다.
    }

    //퍼지는 카드에 대한 배열자 
    IEnumerator SpreadCard(int[] cardArray)
    {
        for (int i = 0; i < 20; i++)
        { 
            GameObject go = Instantiate(card, startPosition, Quaternion.identity, this.transform);
            go.transform.parent = cards;

            //card스크립트 불러오기, 카드 타입 설정 
            go.GetComponent<Card>().setting(cardArray[i]);

            //목표 위치 계산
            float targetx = (i % 4) * 1.4f - 2.1f;
            float targety = (i / 4) * 1.4f - 3.5f;
            Vector2 targetPos = new Vector2(targetx, targety);

            //이동 애니메이션 시
            StartCoroutine(MoveCard(go.transform, targetPos));
            yield return new WaitForSeconds(0.01f);//카드 간 간격

        }
    }

    //움직이는 카드에 대한 배열자 
    IEnumerator MoveCard(Transform card, Vector2 targetPos)
    {
        float timer = 0;
        Vector2 startPos = card.position;

        while (timer < spreadTime)
        {
            timer += Time.deltaTime;
            card.position = Vector2.Lerp(startPos, targetPos, timer / spreadTime);
            yield return null;
        }
        card.position = targetPos; // 정확한 위치 보정
    }
}
