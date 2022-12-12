using System.Collections;
using UnityEngine;

public class Destructible_Object_Es : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    public void Damage(int damage)
    {
        vida -= damage;
        Debug.Log(vida);
        if (vida > 0)
        {
            StartCoroutine(ColorBlancoRojo());
            //spriteRenderer.color = new Color(255, 255, 255, (vida / (100 - damage)));

            Debug.Log("VIDA DE OBJECT " + (vida / (100 - damage)));
        }
        else if (vida <= 0)
        {
            Muerte();
        }
    }
    public void Muerte()
    {
        Debug.Log("Muerte");
        Debug.Log(spriteRenderer.gameObject.tag);
        Destroy(spriteRenderer.gameObject);
    }
    IEnumerator ColorBlancoRojo()
    {
        yield return new WaitForSeconds(0.2f);
       spriteRenderer.color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = new Color(255, 255, 255);
    }
}
