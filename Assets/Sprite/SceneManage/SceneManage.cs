using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneManage : MonoBehaviour
{
    public CanvasGroup canvas;
    public float fadeTime;
    public bool isFade;
    public static SceneManage instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        canvas.alpha = 0;
        canvas.interactable=false;
        canvas.blocksRaycasts = false;
    }
    public void SenceChange(string scene)
    {
        if(isFade)return;
        StartCoroutine(FadeAndLoadRoutine(scene));
    }
    private IEnumerator FadeAndLoadRoutine(string scene)
    {
        isFade= true;
        canvas.blocksRaycasts = true;
        yield return canvas.DOFade(1f, fadeTime)
           .SetEase(Ease.InOutQuad)
           .SetUpdate(true)          // 不受 Time.timeScale 影响
           .WaitForCompletion();
        AsyncOperation op = SceneManager.LoadSceneAsync(scene);
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            yield return null;
        }
        op.allowSceneActivation = true;
        while (!op.isDone)
        {
            yield return null;
        }
        yield return null;
        yield return canvas.DOFade(0f, fadeTime)
          .SetEase(Ease.InOutQuad)
          .SetUpdate(true)          // 不受 Time.timeScale 影响
          .WaitForCompletion();
        isFade = false;
        canvas.blocksRaycasts = false ;
    }
}
