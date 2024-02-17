using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletspawner : MonoBehaviour
{
    // �Ѿ��� �����ϴ� ����. �̸� ����� ��ǰ�� �ݺ��Ͽ� �����ϴ� Ŭ����

    public GameObject bullet;
    public Transform bulletTransfrom;
    public float spawnTime = 3f;
    
    void Start()
    {
        StartCoroutine(Spawnbullet());
    }
    //�Ѿ��� ������ �����ϰ� ���� ������ ���� �� ����.
    //�Ǵ� Enemy�� ���� �� ���� ��� ���� �߻�����.
    // �ڸ�ƾ�� ����Ͽ� �Ѿ� ����.
    
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
