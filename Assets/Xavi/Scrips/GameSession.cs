using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLifes = 3;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

   public void ProcessPlayerDeath()
    {
        if ( playerLifes > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();

        }
    }

    void TakeLife()
    {
        playerLifes--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(3);
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

}
