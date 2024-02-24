using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class CameraMoveSample : MonoBehaviour
    {
        private Vector3 offset; // ī�޶�� ĳ���� ������ �Ÿ�
        public Transform playerPosition; // �÷��̾��� ���� ��ġ

        // Start is called before the first frame update
        void Start()
        {
            offset = transform.position - playerPosition.position;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = playerPosition.position + offset;
            offset = transform.position - playerPosition.position;
        }
    } 
}
