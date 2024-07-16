using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartCanvasControler : MonoBehaviour
{
    public Button StratButton;
    public Button IntroButton;

    public Button CloseButton;

    public GameObject IntroCanvas;
    // Start is called before the first frame update
    void Start()
    {
        IntroCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonClick()
    {
        LoadSceneAsync("SampleScene");
    }

    public void OnIntroButtonClick()
    {
        IntroCanvas.SetActive(true);
    }

    public void OnCloseButtoClick()
    {
        IntroCanvas.SetActive(false);
    }

    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {

        // 开始异步加载场景
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // 激活场景
            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
