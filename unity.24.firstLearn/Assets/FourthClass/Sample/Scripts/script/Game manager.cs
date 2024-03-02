using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    #region 싱글톤 패턴
    //Single : 클래스를 한개만 존재하도록 구성하고, 이를 참조해서 
    //다른 클래스에서 이 클래스를 불러와서 사용할 수 있게 한다.

    //싱글톤의 목적: 싱글톤을 너무 많이 사용하지 말라.
    //하나의 클래스에 너무 많은 정보를 담게 되는 단점이 있으며
    //static 싱글톤을 구현하는데, 게임이 종료될 때 까지 메모리가
    //계속 남아있는 단점이 있음.

    //[디자인패턴] 클래스 간의 좋은 설계를 할 수 있는 관계(상속관계)를
    //정해놓고 그 방식을 따라서 만들도록 하게 한 것
    //기본 문법.
    private static Gamemanager instance;

    //static 클래스 호출, 인스턴스 호출

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

    // void Awake() 함수는 모든 클래스의 void Start()보다 

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

    // static으로 선언한 변수는 클래스 이름으로 바로 접근할 수 있는 장점
    //Gamemanager 안에 있는 모든 static으로 선언된 변수가 무엇인지 알고 있어야 함
    // static으로 선언했을 때 프로그램이 종료될 때 까지 남아있음.



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
