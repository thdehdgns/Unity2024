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
        // 1. �÷��̾��� �̵��� �޴´�.
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
        // ���� ��ȿ������ ��� 
        // 2. ���� �Ű����� ��ġ�� �޴´�.
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horizontal, 0, vertical);

        // 3. �÷��̾ �̵���Ų��.

        this.gameObject.transform.position = gameObject.transform.position + MoveSpeed * dir * Time.deltaTime;

    }
    // rigidbody ������Ʈ�� �о� �� ����� ����.
    // ������Ʈ���̶�� ���� Ŭ������ ������ ������ ����մϴ�.
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
        //�ӵ��� �̿��� �̵����
        rigidbody.velocity = dir * MoveSpeed * Time.deltaTime;

        //���� �Է��� �̵����:
    }
}


//Ʈ���� �� = ��ǥ�� �����Ͽ� �̵���Ű�� ��� -> ���� ���������� �վ����
//������ �ٵ� = ����ȿ���� �޾� �����̱� ������ colider�� �����ϴ� ������Ʈ�̸� �浹�� �߻���