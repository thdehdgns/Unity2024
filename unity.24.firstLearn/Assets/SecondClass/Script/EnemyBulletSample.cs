using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Sample
{
    public class EnemyBulletSample : MonoBehaviour
    {
        // "생성될 때" 플레이어 위치를 감지해서 해당 방향으로 총알의 속도로 발사된다.
        // 이 총알은 다른 사물과 충돌했을 때 이벤트가 발생하고 이 게임 오브젝트를 제거한다.

        // (1) 플레이어 위치 감지하는 기능 
        public Transform targetTransform;

        // (2) 총알의 이동 속도 x 방향으로 총알의 움직임을 구현하기
        public float bulletSpeed;
        public float spawnTime = 3f;

        Vector3 caulateDirection;

        // (3) 충돌 이벤트를 구현 1

        // (4) 총알의 생명을 다해서 죽음에 해당하는 부분을 구현할겁니다. 총알 삭

        private void Start()
        {
            Initialize();
        }

        void Update()
        {
            BulletMove();
        }

        void OnEnable()
        {
            Initialize();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log($"충돌한 게임 오브젝트의 이름 {collision.gameObject.name}");
                // 플레이어의 체력을 떨어뜨리는 기능.
                // 총알을 맞았을 때 바로 게임오버 기능.

                collision.gameObject.GetComponent<PlayerController>().PlayerDeath();

                OnDestroy();
            }
        }

        private void OnDestroy()
        {
            Destroy(gameObject);
        }

        public void Initialize()
        {
            Destroy(gameObject, spawnTime);

            targetTransform = GameObject.Find("Player").transform;
            caulateDirection = (targetTransform.position - transform.position).normalized;
        }

        private void BulletMove()
        {
            transform.position += bulletSpeed * caulateDirection * Time.deltaTime;
        }

        // 총알이 충돌했을 때 충돌한 오브젝트랑 상호작용을 할 수 있는 기능입니다.
        // 물리적인 충돌이 있을 때만 상호작용이 일어나는 이벤트이구요.
        // Rigidbody, Collider가 반드시 하나 이상의 오브젝트에 존재해야 작동한다.
    } 
}
