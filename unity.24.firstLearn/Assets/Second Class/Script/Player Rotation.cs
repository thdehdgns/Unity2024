using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    //ȸ����� ���� 


    public float rotateSpeed = 200f;




 
    void Update()
    {
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        // a�� dŰ�� �Է����� �� ȸ���ϴ� ���

        // �Է� ����, ȸ�� ����

        float horizontal = Input.GetAxis("Horizontal");  // -1 ~ 1 ���� ���� ��ȯ ���ִ� ���

        float yaw = horizontal * rotateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, yaw, Space.World); // ���� ��ǥ�� �����ǥ 
    }
}