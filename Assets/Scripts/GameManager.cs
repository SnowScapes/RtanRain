using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject rain;
    public GameObject endPanel;

    public Text totalScoreText;
    public Text timeText;

    int totalScore;
    float totalTime = 30.0f;

    void Awake()
    {
        Instance = this; //instance를 static으로 선언해서 다른 오브젝트에서도 접근 가능 (싱글톤)
        Time.timeScale = 1.0f; // 게임속도. 1이면 정상속도
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeRain", 0, 1f); // MakeRain 함수를 0초 후에 1초마다 실행
    }

    void Update()
    {
        totalTime -= Time.deltaTime; // 남은 시간 감소
        timeText.text = totalTime.ToString("N2"); // 남은 시간을 String으로 변환하여 timeText에 적용
        if (totalTime > 0f)
        {
            totalTime -= Time.deltaTime;
        }
        else
        {
            Time.timeScale = 0.0f;
            endPanel.SetActive(true); // 남은 시간이 0이 되면 게임종료 패널을 표시하기
            totalTime = 0.0f; // 게임속도 0. 일시정지 효과
        }
        timeText.text = totalTime.ToString("N2");
    }

    void MakeRain()
    {
        Instantiate(rain); // rain prefab을 불러와 Scene에 생성
    }

    public void AddScore(int score)
    {
        totalScore += score;
        totalScoreText.text = totalScore.ToString(); // totalScore에 매개변수 score를 더해주고 totalScoreText에 적용
    }
}
