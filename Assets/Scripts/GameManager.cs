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
        Instance = this; //instance�� static���� �����ؼ� �ٸ� ������Ʈ������ ���� ���� (�̱���)
        Time.timeScale = 1.0f; // ���Ӽӵ�. 1�̸� ����ӵ�
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeRain", 0, 1f); // MakeRain �Լ��� 0�� �Ŀ� 1�ʸ��� ����
    }

    void Update()
    {
        totalTime -= Time.deltaTime; // ���� �ð� ����
        timeText.text = totalTime.ToString("N2"); // ���� �ð��� String���� ��ȯ�Ͽ� timeText�� ����
        if (totalTime > 0f)
        {
            totalTime -= Time.deltaTime;
        }
        else
        {
            Time.timeScale = 0.0f;
            endPanel.SetActive(true); // ���� �ð��� 0�� �Ǹ� �������� �г��� ǥ���ϱ�
            totalTime = 0.0f; // ���Ӽӵ� 0. �Ͻ����� ȿ��
        }
        timeText.text = totalTime.ToString("N2");
    }

    void MakeRain()
    {
        Instantiate(rain); // rain prefab�� �ҷ��� Scene�� ����
    }

    public void AddScore(int score)
    {
        totalScore += score;
        totalScoreText.text = totalScore.ToString(); // totalScore�� �Ű����� score�� �����ְ� totalScoreText�� ����
    }
}
