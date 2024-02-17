using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletspawner : MonoBehaviour
{
    // 총알을 생성하는 공장. 미리 등록한 제품을 반복하여 생성하는 클래스

    public GameObject bullet;
    public Transform bulletTransfrom;
    public float spawnTime = 3f;
    
    void Start()
    {
        StartCoroutine(Spawnbullet());
    }
    //총알은 게임이 시작하고 나서 게임이 끝날 때 까지.
    //또는 Enemy가 어질 때 까지 계속 총을 발사할지.
    // 코르틴을 사용하여 총알 생성.
    
    IEnumerator Spawnbullet()
    {
        while (true)
        {
            GameObject enemyBullet = Instantiate(bullet, bulletTransfrom.position, Quaternion.identity);
            EnemyBulletspawner bulletControl = enemyBullet.GetComponent<EnemyBulletspawner>();
            

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
