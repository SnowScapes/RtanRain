using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    //MainScene이라는 이름의 Scene을 로드
    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
