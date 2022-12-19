using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer_JCG : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    public GameObject Reiniciar;
    public Text GameOver;
    private void Start()
    {
        life = hearts.Length;

        GameOver.enabled = false;
        Reiniciar.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(life < 1) 
        {
            Destroy(hearts[0].gameObject);
        }
        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
        }

    }   
   public void TakeDamage(int damage)
    {
        life -= damage;
        if (life < 0)
        {
            Destroy(gameObject);
            Reiniciar.gameObject.SetActive(true); //cuando se muera salga reiniciar
            GameOver.enabled = true;
        }
        
    }   
    public int GetHearts()
    {
        return hearts.Length;
    }
    public void SetHealth(int playerHealth)
    {
        life = playerHealth;
        TakeDamage(0);
       
    }
}
