using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    float size;
    int score;

    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        float x = Random.Range(-2.7f, 2.7f); // 생성될 X좌표 랜덤 생성
        float y = Random.Range(3.0f, 5.0f); // 생성될 y좌표 랜덤 생성
        transform.position = new Vector3(x, y, 0); // 오브젝트의 랜덤 좌표 설정

        int type = Random.Range(1, 5);

        // 랜덤 정수 type의 값에 따라 색, 크기, 사이즈 설정
        // 1~3은 플러스 점수를 주는 푸른색 빗방울, 4는 마이너스 점수를 주는 붉은색 빗방울
        if (type == 1)
        {
            size = 0.8f;
            score = 1;
            renderer.color = new Color(100 / 255f, 100 / 255f, 1f, 1f);
        }
        else if (type == 2)
        {
            size = 1.0f;
            score = 2;
            renderer.color = new Color(130 / 255f, 130 / 255f, 1f, 1f);
        }
        else if (type == 3)
        {
            size = 1.2f;
            score = 3;
            renderer.color = new Color(150 / 255f, 150 / 255f, 1f, 1f);
        }
        else if (type == 4)
        {
            size = 0.8f;
            score = -5;
            renderer.color = new Color(255 / 255.0f, 100.0f / 255.0f, 100.0f / 255.0f, 255.0f / 255.0f); ;
        }

        // type에 따라 설정된 사이즈로 오브젝트 사이즈 설정
        transform.localScale = new Vector3(size, size, 0);
    }

    // Ground 태그를 가진 오브젝트와 충돌 시에 오브젝트 Destroy
    // Player 태그를 가진 오브젝트와 충돌 시에 오브젝트 Destroy 및 GameManager 인스턴스의 score에 점수 추가
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(score);
            Destroy(this.gameObject);
        }
    }
}
