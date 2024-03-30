using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarge : MonoBehaviour
{
    public static GameStarge Instance;

    [Header("몬스터 생성 관리")]
    public int spawnEnemyCount;
    public int waveCount = 1;
    public int maxWave;
    public bool stageClear;
    public GameObject enemyPrefeb;
    public Transform[] spawnPositions;

    [Header("게임 클리어 UI")]
    public GameObject clearGameUI;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        CreateEnemy(waveCount);
    }

    private void Update()
    {
        if (spawnEnemyCount <= 0 && !stageClear)
        {
            waveCount++;
            WaveProcess();
        }

        if (stageClear) 
        {
            clearGameUI.SetActive(true);
        }
    }

    private void WaveProcess()
    {
        if(waveCount > maxWave)
        {
            stageClear = true;
            return;
        }
        else
        {
            CreateEnemy(waveCount);
        }
    }

    private void CreateEnemy(int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(enemyPrefeb, transform.position, Quaternion.identity);
            spawnEnemyCount++;
        }
        
        
    }

    private Transform SetCharacterPosition()
    {
        int seletPos = UnityEngine.Random.RandomRange(0, spawnPositions.Length);

        return spawnPositions[seletPos];
    }


    public void ReturnToTitle()
    {
        SceneManager.LoadScene("intro1");
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
