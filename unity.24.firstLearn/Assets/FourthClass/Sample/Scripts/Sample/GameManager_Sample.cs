using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sample
{
    public class GameManager_Sample : MonoBehaviour
    {
        #region �̱��� ����
        // �̱��� �����̶� : ������Ʈ���� �� �ϳ���(Single) �����Ű��
        // ���� ����ó�� �ٸ� ��� Ŭ�������� �ҷ��� ����� �� �ֽ��ϴ�.
        // ������ �̱��� ������ �̷��� ����� �����ؾ� �Ѵٰ� ���� �ϰ� �ֽ��ϴ�.
        // �ϳ��� Ŭ������ �ʹ� ���� ��ɰ� �����͸� ������ ������Ʈ�� �Ը� Ŀ���� �� ������ �����
        // static���� ������ Ŭ������ ������ ����Ǳ� �� ���� �޸𸮸� ��� �����ϴ� ������ �ֽ��ϴ�.

        // �ڵ� ����
        // ���ȼ��� ���� prviate�� ����
        private static GameManager_Sample instance;
        // private ������ instance�� ������ �� �ִ� ������Ƽ ����
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

        // ������� ���� �ε�â ����

        public void GameRestart()
        {
            SetGameSetting();
            SceneManager.LoadScene("SampleScene");
        }
    }
}
