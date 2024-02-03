using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Vector3 Direction;
    public float MoveSpeed = 10f;
    public bool IsRigidbody;
    private void Update()
    {
        if (IsRigidbody)
        {
            Move();
        }
        else
        {
            RigidbodyMove();
        }
        
    }
   
    


    private void Move()
    {
        // 1. 플레이어의 이동을 받는다.
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    float dirValue = 1;
        //}
        //else if (Input.GetKeyUp(KeyCode.A))
        //{
        //    float dirValue = -1;
        //}
        //else if (Input.GetKeyUp(KeyCode.S))
        //{
        //    float dirValue = -1;
        //}
        //else if (Input.GetKeyUp(KeyCode.D))
        //{
        //    float dirValue = 1;
        //}
        // 아주 비효율적인 방법 
        // 2. 어디로 옮겨질지 위치를 받는다.
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horizontal, 0, vertical);

        // 3. 플레이어를 이동시킨다.

        this.gameObject.transform.position = gameObject.transform.position + MoveSpeed * dir * Time.deltaTime;

    }
    // rigidbody 컴포넌트를 읽어 올 방법이 없음.
    // 컴포넌트들이라는 것을 클래스에 가저온 다음에 사용합니다.
    public Rigidbody rigidbody;

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void RigidbodyMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horizontal, 0, vertical);
        //속도를 이용한 이동방법
        rigidbody.velocity = dir * MoveSpeed * Time.deltaTime;

        //힘을 입력한 이동방법:
    }
}


//트랜스 폼 = 좌표를 변경하여 이동시키는 방식 -> 벽을 마주했을때 뚫어버림
//리지드 바디 = 물리효과를 받아 움직이기 때문에 colider가 존재하는 오브젝트이면 충돌이 발생함