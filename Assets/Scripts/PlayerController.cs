using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer renderer;
    //float direction = 0.05f;
    float direction = 3.0f; // 플레이어의 이동속도
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 10;
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

        //transform.position += Vector3.right * direction; // 캐릭터가 오른쪽으로 계속 이동
        transform.position += Vector3.right * direction * Time.deltaTime; // 캐릭터가 오른쪽으로 계속 이동, Time.DeltaTIme을 적용해 프레임과 관계없이 같은 속도로 이동하도록 수정
        Debug.Log(Time.deltaTime);
    }
}