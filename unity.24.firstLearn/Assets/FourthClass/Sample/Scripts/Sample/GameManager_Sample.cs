using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sample
{
    public class GameManager_Sample : MonoBehaviour
    {
        #region 싱글톤 패턴
        // 싱글톤 패턴이란 : 프로젝트에서 단 하나만(Single) 존재시키고
        // 전역 변수처럼 다른 모든 클래스에서 불러와 사용할 수 있습니다.
        // 하지만 싱글톤 패턴은 이러한 방식을 지양해야 한다고 말을 하고 있습니다.
        // 하나의 클래스에 너무 많은 기능과 데이터를 넣으면 프로젝트의 규모가 커졌을 때 관리가 힘들고
        // static으로 선언한 클래스는 게임이 종료되기 전 까지 메모리를 계속 점유하는 문제가 있습니다.

        // 코드 구현
        // 보안성을 위해 prviate로 선언
        private static GameManager_Sample instance;
        // private 선언한 instance에 접근할 수 있는 프로퍼티 선언
        public static GameManager_Sample Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new GameManager_Sample();
                }
                return instance;
            }
        }

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

        #endregion

        public bool isPlayerDeath = false;

        [SerializeField] private GameObject GameOverObject;

        private void SetGameSetting()
        {
            isPlayerDeath = false;
        }

        public void GameOver()
        {
            GameOverObject?.SetActive(true);
        }


        public void GameQuit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

        // 재시작을 위한 로딩창 구현

        public void GameRestart()
        {
            SetGameSetting();
            SceneManager.LoadScene("SampleScene");
        }
    }
}
