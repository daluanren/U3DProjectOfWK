using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private FadeSprite m_blackScreenCover;
    [SerializeField]
    private float m_minDuration = 1.5f;


    void Start()
    {

    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    StartCoroutine(LoadSceneAsync(sceneName));
        //}
    }

    public void StartCoroutineToLoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    /// <summary>
    /// 加载指定场景
    /// </summary>
    /// <param name="sceneName">指定场景</param>
    /// <returns></returns>
    public IEnumerator LoadSceneAsync(string sceneName)
    {

        Debug.Log("!!!Start change to scene:" + sceneName);
        // 黑屏淡入
        yield return StartCoroutine(m_blackScreenCover.FadeIn());

        //加载Loading场景
        yield return Application.LoadLevelAsync("02-LoadingScene");

        // 自动删除旧场景

        // 黑屏淡出
        yield return StartCoroutine(m_blackScreenCover.FadeOut());

        float endTime = Time.time + m_minDuration;

        // 加载制定场景
        yield return Application.LoadLevelAdditiveAsync(sceneName);

        Debug.Log("!!!time.time:"+Time.time+",,end time :"+endTime);
        while (Time.time < endTime)
            yield return null;


        // 黑屏淡入
        yield return StartCoroutine(m_blackScreenCover.FadeIn());

        // !!! 卸载loading场景
        LoadingSceneManager.m_instence.UnloadLoadingScene();

        // 黑屏淡出
        yield return StartCoroutine(m_blackScreenCover.FadeOut());
    }


}
