using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Sample
{
    public class LoadingSceneController : MonoBehaviour
    {
        static string nextScene;

        [SerializeField] private Image progressBar;

        public static void LoadScene(string sceneName)
        {
            nextScene = sceneName;
            SceneManager.LoadScene("LoadingScene");
        }

        private void Start()
        {
            StartCoroutine(LoadSceneProcess());
        }

        IEnumerator LoadSceneProcess()
        {
            yield return new WaitForSeconds(0.3f);

            // ���� ��� �� ȣ��. (���� �ҷ� ���� �� ������ �ٸ� �۾��� �Ұ��� �ϴ�)
            AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
            op.allowSceneActivation = false; // ���� ������ �ڵ����� �ش� ������ �̵��� ���ΰ�? - 1. �� �ε� �ӵ� ����, ����ũ �ε� 2. ���� ������ ���ҽ��� �о�;� �ϴ� ��Ȳ

            float timer = 0f;
            while (!op.isDone)
            {
                yield return null;

                if (op.progress < 0.9f)
                {
                    progressBar.fillAmount = op.progress;
                }
                else
                {
                    timer += Time.unscaledDeltaTime;
                    progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                    if (progressBar.fillAmount >= 1f)
                    {
                        yield return new WaitForSeconds(1.7f);
                        op.allowSceneActivation = true;
                    }
                    yield return null;
                }
            }
        }
    } 
}
