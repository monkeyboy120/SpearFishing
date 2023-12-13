using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage;
    public float fadeTime = 1f;
    public GameObject mainMenuObjects;

    public void FadeToScene(string sceneName)
    {
        print("hello");
        StartCoroutine(FadeOutIn(sceneName));
    }

    IEnumerator FadeOutIn(string sceneName)
    {
        yield return StartCoroutine(Fade(1)); // Fade out

        // Load the new scene asynchronously in the background
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false; // Prevent the scene from activating immediately

        while (!asyncLoad.isDone)
        {
            // Check if the load has finished
            if (asyncLoad.progress >= 0.9f)
            {
                yield return StartCoroutine(Fade(0)); // Fade in
                asyncLoad.allowSceneActivation = true; // Activate the new scene
            }
            yield return null;
        }

        mainMenuObjects.SetActive(true);
    }

    IEnumerator Fade(float targetAlpha)
    {
        mainMenuObjects.SetActive(false);
        float startAlpha = fadeImage.color.a;
        float time = 0f;

        while (time < fadeTime)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeTime);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            yield return null;
        }

        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, targetAlpha);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}