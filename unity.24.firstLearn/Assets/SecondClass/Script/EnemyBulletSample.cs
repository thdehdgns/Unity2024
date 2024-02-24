using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Sample
{
    public class EnemyBulletSample : MonoBehaviour
    {
        // "������ ��" �÷��̾� ��ġ�� �����ؼ� �ش� �������� �Ѿ��� �ӵ��� �߻�ȴ�.
        // �� �Ѿ��� �ٸ� �繰�� �浹���� �� �̺�Ʈ�� �߻��ϰ� �� ���� ������Ʈ�� �����Ѵ�.

        // (1) �÷��̾� ��ġ �����ϴ� ��� 
        public Transform targetTransform;

        // (2) �Ѿ��� �̵� �ӵ� x �������� �Ѿ��� �������� �����ϱ�
        public float bulletSpeed;
        public float spawnTime = 3f;

        Vector3 caulateDirection;

        // (3) �浹 �̺�Ʈ�� ���� 1

        // (4) �Ѿ��� ������ ���ؼ� ������ �ش��ϴ� �κ��� �����Ұ̴ϴ�. �Ѿ� ��

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
                Debug.Log($"�浹�� ���� ������Ʈ�� �̸� {collision.gameObject.name}");
                // �÷��̾��� ü���� ����߸��� ���.
                // �Ѿ��� �¾��� �� �ٷ� ���ӿ��� ���.

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

        // �Ѿ��� �浹���� �� �浹�� ������Ʈ�� ��ȣ�ۿ��� �� �� �ִ� ����Դϴ�.
        // �������� �浹�� ���� ���� ��ȣ�ۿ��� �Ͼ�� �̺�Ʈ�̱���.
        // Rigidbody, Collider�� �ݵ�� �ϳ� �̻��� ������Ʈ�� �����ؾ� �۵��Ѵ�.
    } 
}
