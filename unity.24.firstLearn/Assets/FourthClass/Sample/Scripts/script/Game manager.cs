using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    #region �̱��� ����
    //Single : Ŭ������ �Ѱ��� �����ϵ��� �����ϰ�, �̸� �����ؼ� 
    //�ٸ� Ŭ�������� �� Ŭ������ �ҷ��ͼ� ����� �� �ְ� �Ѵ�.

    //�̱����� ����: �̱����� �ʹ� ���� ������� ����.
    //�ϳ��� Ŭ������ �ʹ� ���� ������ ��� �Ǵ� ������ ������
    //static �̱����� �����ϴµ�, ������ ����� �� ���� �޸𸮰�
    //��� �����ִ� ������ ����.

    //[����������] Ŭ���� ���� ���� ���踦 �� �� �ִ� ����(��Ӱ���)��
    //���س��� �� ����� ���� ���鵵�� �ϰ� �� ��
    //�⺻ ����.
    private static Gamemanager instance;

    //static Ŭ���� ȣ��, �ν��Ͻ� ȣ��

    public static Gamemanager Instance
    {
        get
        { 
            if(null == instance)
            {
                instance = new Gamemanager();
            }

            return instance; 
        }
    }

    public object ScenManeger { get; private set; }

    // void Awake() �Լ��� ��� Ŭ������ void Start()���� 

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public bool IsPlayerDeath;

    // static���� ������ ������ Ŭ���� �̸����� �ٷ� ������ �� �ִ� ����
    //Gamemanager �ȿ� �ִ� ��� static���� ����� ������ �������� �˰� �־�� ��
    // static���� �������� �� ���α׷��� ����� �� ���� ��������.



    #endregion

    public GameObject[] GameOverObjects;

    private void SetGameSetting()
    {
        IsPlayerDeath = false;

        GameOverObjects[0] = GameObject.Find("Background");
        GameOverObjects[1] = GameObject.Find("GameOver");
    }

    public void GameOver()
    {
        foreach(GameObject obj in GameOverObjects)
        {
            obj.SetActive(true);
        }
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void GameRestart()
    {
        SetGameSetting();
        SceneManager.LoadScene("GameScene2");
    }

}
