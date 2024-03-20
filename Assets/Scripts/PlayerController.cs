using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer renderer;
    float direction = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //���콺 ��Ŭ�� �ÿ� ���� ��ȯ
        if (Input.GetMouseButtonDown(0))
        {
            direction *= -1;
            renderer.flipX = !renderer.flipX;
        }

        //������ ���� �ε��� �ÿ� ���� ��ȯ
        if (transform.position.x >= 2.6f)
        {
            direction *= -1;
            renderer.flipX = true;
        }

        // ���� ���� �ε��� �ÿ� ���� ��ȯ
        if (transform.position.x <= -2.6f)
        {
            direction *= -1;
            renderer.flipX = false;
        }

        transform.position += Vector3.right * direction; // ĳ���Ͱ� ���������� ��� �̵�
    }
}