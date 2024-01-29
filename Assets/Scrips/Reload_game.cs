using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload_game : MonoBehaviour
{
    public TextMeshProUGUI HPPlayer;
    int HPLive = 3;
    [SerializeField] float levelLoad = 0.1f;

    void HP(int HPPlay)
    {
        HPLive += HPPlay;
        HPPlayer.text = "HP :" + HPLive;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bat" || other.tag == "trai" || other.tag == "right" || other.tag == "spike" || other.tag == "fall_spike")
        {
            
            HP(-1);
            if (HPLive <= 0)
            {
                StartCoroutine(LoadLevel());
            }

        }
        if (other.tag == "play1")
        {
            StartCoroutine(LoadNextLevel());
        }
        if (other.tag == "water")
        {
            StartCoroutine(LoadLevel());
        }

    }
    IEnumerator LoadLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoad);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }
    private void Start()
    {
        HP(0);
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoad);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }
}


