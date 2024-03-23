using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("적 피격 애니메이션 제어 변수")]
    public float hitBackTime = 0.5f;        //피격 효과 발생 후 원래 상태로 돌아가는 시간
    public int hitCount = 0;                //몇번 공격 받았는지 저장하는 변수
    public int currentHP;                   // 현제 몬스터의 체력
    public int maxHp = 3;                   // 몬스터의 최대 체력
    private SkinnedMeshRenderer skinMeshRenderer; //피격시 색상을 변경해주기 위한 정보를 저장하는 함수
    [Header("애니메이션 실행을 위해 필요한 변수")]
    private Animator anim;
    private NavMeshAgent navMeshAgent;      // 길찾기 대리인 클래스를 저장하는 변수

    [Header("길찾기 변수")]
    public Transform target;

    [Header("몬스터의 행동 제어 변수")]
    public float findDistance;         //타겟을 탐색 시작하는 최대거리
    public float attackRange;

    private bool isDeath;

    private readonly string takeDamageAnimationName = "IsHit";
    private readonly string DreatAnimationName = "doDeath";
    private void Awake()
    {
        LoadComponet();

    }

    private void LoadComponet()
    {

        // 초기화 = 데이터를 처음 할당 해주는 것
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        skinMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    private void Update()
    {
        //플레이어를 탐색하는 기능 = 탐색 최대 거리 내에 플레이어가 있는가?

        target = FindAnyObjectByType<PlayerController>().gameObject.transform;

        if (findDistance >= Vector3.Distance(transform.position, target.position))
        {
            Debug.Log(Vector3.Distance(transform.position, target.position));

            navMeshAgent.SetDestination(target.position);   //플레이어를 쫒는 기능 
        }


        //적의 공격 기능 =
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, target.position);

        Gizmos.DrawWireSphere(transform.position, findDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

    }

    public void TakeDamage()
    {
        if (isDeath == true)
        {
            return;
        }

        hitCount++;             //적이 피격된 수가 1 증가
        anim.SetBool(takeDamageAnimationName, true);         //피격 애니메이션 실행
        StartCoroutine(TakeDamageEffect());

        if (hitCount >= maxHp)
        {
            hitCount = 0;
            OnDeath();
        }
    }

    IEnumerator TakeDamageEffect()
    {
        ShakeCamera.Instance.OnShakeCamera(0.2f, 0.2f);
        skinMeshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(hitBackTime);

        anim.SetBool(takeDamageAnimationName, false);
        skinMeshRenderer.material.color = Color.white;
    }

    private void OnDeath()
    {
        anim.SetTrigger(DreatAnimationName);
        isDeath = true;
    }

    public void DestoryGameObjct()          //애니메이션 이벤트 함수로 사용한다. 애니메이이션 특정 위치에 호출할 수 있다. 
    {
        Destroy(gameObject);
    }
}
