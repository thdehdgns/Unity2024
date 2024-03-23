using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("�� �ǰ� �ִϸ��̼� ���� ����")]
    public float hitBackTime = 0.5f;        //�ǰ� ȿ�� �߻� �� ���� ���·� ���ư��� �ð�
    public int hitCount = 0;                //��� ���� �޾Ҵ��� �����ϴ� ����
    public int currentHP;                   // ���� ������ ü��
    public int maxHp = 3;                   // ������ �ִ� ü��
    private SkinnedMeshRenderer skinMeshRenderer; //�ǰݽ� ������ �������ֱ� ���� ������ �����ϴ� �Լ�
    [Header("�ִϸ��̼� ������ ���� �ʿ��� ����")]
    private Animator anim;
    private NavMeshAgent navMeshAgent;      // ��ã�� �븮�� Ŭ������ �����ϴ� ����

    [Header("��ã�� ����")]
    public Transform target;

    [Header("������ �ൿ ���� ����")]
    public float findDistance;         //Ÿ���� Ž�� �����ϴ� �ִ�Ÿ�
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

        // �ʱ�ȭ = �����͸� ó�� �Ҵ� ���ִ� ��
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        skinMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    private void Update()
    {
        //�÷��̾ Ž���ϴ� ��� = Ž�� �ִ� �Ÿ� ���� �÷��̾ �ִ°�?

        target = FindAnyObjectByType<PlayerController>().gameObject.transform;

        if (findDistance >= Vector3.Distance(transform.position, target.position))
        {
            Debug.Log(Vector3.Distance(transform.position, target.position));

            navMeshAgent.SetDestination(target.position);   //�÷��̾ �i�� ��� 
        }


        //���� ���� ��� =
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

        hitCount++;             //���� �ǰݵ� ���� 1 ����
        anim.SetBool(takeDamageAnimationName, true);         //�ǰ� �ִϸ��̼� ����
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

    public void DestoryGameObjct()          //�ִϸ��̼� �̺�Ʈ �Լ��� ����Ѵ�. �ִϸ����̼� Ư�� ��ġ�� ȣ���� �� �ִ�. 
    {
        Destroy(gameObject);
    }
}
