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

            // 동기 방식 씬 호출. (씬을 불러 오기 전 까지는 다른 작업이 불가능 하다)
            AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
            op.allowSceneActivation = false; // 씬이 끝나면 자동으로 해당 씬으로 이동할 것인가? - 1. 씬 로딩 속도 제어, 페이크 로딩 2. 에셋 번들을 리소스로 읽어와야 하는 상황

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
