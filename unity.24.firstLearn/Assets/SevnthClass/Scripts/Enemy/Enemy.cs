using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seven
{
    public class Enemy : MonoBehaviour
    {
        [Header("�� ���� ���� ����")]
        public int hitCount;
        public int maxHP = 2;
        private int currentHP;

        public Transform target;

        [Header("�� �ǰ� ���� ����")]
        public float hitBackTime = 0.5f;
        public float cameraShakeTime = 0.2f;
        private SkinnedMeshRenderer skinnedMesh;

        public Animator anim { get; private set; }
        public readonly string takeAnimName = "IsHit"; 
        public readonly string DeathAnimName = "doDeath"; 

        private void Awake()
        {
            LoadComponents();
        }


        private void LoadComponents()
        {
            skinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>();
            anim = GetComponent<Animator>();
            currentHP = maxHP;
            hitCount = 0;
        }

        private void Update()
        {
            if (target)
                LookPlayer();
        }

        public void TakeDamage()
        {
            hitCount++;
            anim.SetBool(takeAnimName, true);
            StartCoroutine(TakeDamegeEffect());

            if(hitCount >= maxHP)
            {
                hitCount = 0;
                OnDeath();
                return;
            }
        }

        IEnumerator TakeDamegeEffect() // �ڷ�ƾ�� ��ø�Ǽ� ������ �ʴ��� ��� ���ǿ� �����ϱ�
        {
            ShakeCamera.Instance.OnShakeCamera(cameraShakeTime);
            skinnedMesh.material.color = Color.red;

            yield return new WaitForSeconds(hitBackTime);

            TakeDamageOver();
            skinnedMesh.material.color = Color.white;
        }

        public void TakeDamageOver()
        {
            Debug.Log("�� ��Ʈ �ִϸ��̼� ����");
            anim.SetBool(takeAnimName, false);
        }

        public void OnDeath()
        {
            anim.SetTrigger(DeathAnimName);
        }

        public void DestoryObject()
        {
            Destroy(gameObject);
        }

        private void LookPlayer()
        {
            transform.LookAt(target); 
        }
    } 
}
