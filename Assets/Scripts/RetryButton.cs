using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    //MainScene�̶�� �̸��� Scene�� �ε�
    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
