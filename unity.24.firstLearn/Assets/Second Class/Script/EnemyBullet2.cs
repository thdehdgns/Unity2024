using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // "생성될 때" 플레이어 위치를 감지해서 해당 방향으로 총알의 속도로 발사된다.
    // 이 총알은 다른 사물과 충돌했을 때 이벤트가 발생하고 이 게임 오브젝트를 제거한다.

    // (1) 플레이어 위치 감지하는 기능 
    private Transform PlayerTransform;

    // (2) 총알의 이동 속도 x 방향으로 총알의 움직임을 구현하기
    public float bulletSpeed;
    // (3) 충돌 이벤트를 구현 

    // (4) 총알의 생명을 다해서 죽음에 해당하는 부분을 구현할겁니다. 총알 삭

    // Start is called before the first frame update
    void Start()
    {
        // 플레이어의 위치를 받아오는지 테스트 해본다. 
        Debug.Log($"현재 플레이어의 위치 : {PlayerTransform}");

        PlayerTransform = GameObject.Find("Player").transform;

        Vector3 playerDirection = new Vector3(PlayerTransform.position.x, 0, PlayerTransform.position.z);
        caulateDirection = (playerDirection - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }

    Vector3 caulateDirection;

    private void BulletMove()
    {


        transform.position += bulletSpeed * caulateDirection * Time.deltaTime;
        //transform.Translate(bulletSpeed * playerDirection * Time.deltaTime);
    }

    public void Test()
    {
        Debug.Log("총알이 발사되었음");
    }

    //rigidbody, collider 가 있어야함
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"충돌한 게임 오브젝트의 이름 {collision.gameObject.name}");
        }
    }
}
