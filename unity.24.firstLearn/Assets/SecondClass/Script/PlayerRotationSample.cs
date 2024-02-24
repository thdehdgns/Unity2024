using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class PlayerRotationSample : MonoBehaviour
    {
        // ȸ�� �ϴ� ����� �����غ��̴ϴ�.

        public float rotateSpeed = 200f;

        private void Update()
        {
            RotatePlayer();
        }

        public void RotatePlayer()
        {
            // A�� DŰ�� �Է����� �� �ش� �������� ȸ���ϴ� ����� ����

            // �Է� ����
            float horizontal = Input.GetAxis("Horizontal"); // -1 ~ 1���� ��ȯ���ִ� ���
                                                            // ȸ�� ���� -> ��� �������� ȸ���� ���Ѿ� ����?

            float yaw = horizontal * rotateSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, yaw, Space.World); // ���� ��ǥ�� ��� ��ǥ
        }
    } 
}
