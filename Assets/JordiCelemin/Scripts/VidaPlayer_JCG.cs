using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer_JCG : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;

    private void Start()
    {
        life = hearts.Length;
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
