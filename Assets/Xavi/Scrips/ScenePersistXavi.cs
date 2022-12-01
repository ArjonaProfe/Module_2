using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersistXavi : MonoBehaviour
{
    private void Awake()
    {
        int numScenePersist = FindObjectsOfType<ScenePersistXavi>().Length;
        if (numScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
