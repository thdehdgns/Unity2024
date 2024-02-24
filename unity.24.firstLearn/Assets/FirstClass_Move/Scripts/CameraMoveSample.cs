using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class CameraMoveSample : MonoBehaviour
    {
        private Vector3 offset; // 카메라와 캐릭터 사이의 거리
        public Transform playerPosition; // 플레이어의 현재 위치

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
