# ⭐ 내일배움캠프 사전캠프 1주차 <img src="https://img.shields.io/badge/Unity-FFFFFF?style=flat&logo=Unity&logoColor=5D5D5D"/> <img src="https://img.shields.io/badge/C%23-5D5D5D?style=flat&logo=csharp&logoColor=FFFFFF"/>   
## 🖥 개발환경    

* CPU : I7-13700K 3.40Ghz    
* RAM : DDR4 64GB 3800Mhz    
* VGA : NVIDIA RTX 3090 GDDR6X 24GB    
* OS : MICROSOFT WINDOWS 11    
* Engine : UNITY 2021.3.16f1    
* IDE : MICROSOFT Visual Studio 2022    

## 💧 빗물받는 르탄이    
<img src="/IMGS/game.gif" width="50%" height="50%" title="game" alt="Game"></img>    
#### 제한시간 30초 이내에 빨간색 빗물을 피하며 파란색 빗물을 받아 최대한 높은 점수를 받는 것이 목표인 게임    
> ##### 🎮 게임 플레이
> 1. 게임이 시작되면 캐릭터가 좌우로 계속해서 움직인다.    
> 2. 하늘에서 랜덤한 빗물이 떨어지며 캐릭터를 움직여 빗물을 받을 수 있다.    
> 3. 받은 파란색 빗물은 크기에 따라 1,2,3 점을 얻고, 빨간색 빗물은 -5 점을 얻는다.    
> 4. 30초 이내에 최대한 높은 점수를 받아보자.
---
<details><summary><h2>기존 코드</h2></summary>

<details>
<summary>    
<b>GameManager.cs</b>
</summary>

```csharp
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
```
</details>

<details>
<summary><b>PlayerController.cs</b></summary>

```csharp
public class PlayerController : MonoBehaviour
{
    SpriteRenderer renderer;
    float direction = 0.05f; // 플레이어의 이동속도
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 왼클릭 시에 방향 전환
        if (Input.GetMouseButtonDown(0))
        {
            direction *= -1;
            renderer.flipX = !renderer.flipX;
        }

        //오른쪽 벽에 부딪힐 시에 방향 전환
        if (transform.position.x >= 2.6f)
        {
            direction *= -1;
            renderer.flipX = true;
        }

        // 왼쪽 벽에 부딪힐 시에 방향 전환
        if (transform.position.x <= -2.6f)
        {
            direction *= -1;
            renderer.flipX = false;
        }

        transform.position += Vector3.right * direction; // 캐릭터가 오른쪽으로 계속 이동
    }
}```    

</details>
</details>
