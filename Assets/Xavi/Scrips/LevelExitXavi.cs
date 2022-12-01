using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExitXavi : MonoBehaviour
{
    [SerializeField] float levelLoadDelay =1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());   
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if ( nextSceneIndex == 6)
        {
            nextSceneIndex = 4;
        }

        FindObjectOfType<ScenePersistXavi>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }


}
