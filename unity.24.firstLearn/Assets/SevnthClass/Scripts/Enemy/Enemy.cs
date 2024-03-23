using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seven
{
    public class Enemy : MonoBehaviour
    {
        [Header("적 상태 제어 변수")]
        public int hitCount;
        public int maxHP = 2;
        private int currentHP;

        public Transform target;

        [Header("적 피격 제어 변수")]
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

        IEnumerator TakeDamegeEffect() // 코루틴이 중첩되서 사용되지 않는지 사용 조건에 유의하기
        {
            ShakeCamera.Instance.OnShakeCamera(cameraShakeTime);
            skinnedMesh.material.color = Color.red;

            yield return new WaitForSeconds(hitBackTime);

            TakeDamageOver();
            skinnedMesh.material.color = Color.white;
        }

        public void TakeDamageOver()
        {
            Debug.Log("적 히트 애니메이션 종료");
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
