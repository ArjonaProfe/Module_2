using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControlOscar : MonoBehaviour
{
    public Camera Me;
    public Transform Target, StartTar;
    public Vector3 Adapt, StartAdapt, CurrAdapt;
    public float Speed, CurrSize, StartSize;

    // Start is called before the first frame update
    void Start()
    {
        Me = GetComponent<Camera>();
        CurrSize = StartSize;
        CurrAdapt = StartAdapt;
        Target = StartTar;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(Target.position.x + (Adapt.x * Target.localScale.x), Target.position.y + Adapt.y, -10), Speed * Time.deltaTime);
        }

        if(CurrSize != Me.orthographicSize)
        {
            Me.orthographicSize = Mathf.Lerp(Me.orthographicSize, CurrSize, 0.01f);
        }
        if(Adapt != CurrAdapt)
        {
            Adapt = Vector3.Lerp(Adapt, CurrAdapt, 0.01f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CamModOscar>() != null)
        {
            CurrSize = collision.GetComponent<CamModOscar>().Size;
            CurrAdapt = collision.GetComponent<CamModOscar>().Pos;
            if(collision.GetComponent<CamModOscar>().CustomPos != null)
            {
                Target = collision.GetComponent<CamModOscar>().CustomPos;
            }
            if(collision.GetComponent<CamModOscar>().ToAppear.Count > 0)
            {
                for (int i = 0; i < collision.GetComponent<CamModOscar>().ToAppear.Count; i++)
                {
                    collision.GetComponent<CamModOscar>().ToAppear[i].SetActive(true);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<CamModOscar>() != null)
        {
            CurrSize = StartSize;
            CurrAdapt = StartAdapt;
            Target = StartTar;
            if (collision.GetComponent<CamModOscar>().ToAppear.Count > 0)
            {
                for (int i = 0; i < collision.GetComponent<CamModOscar>().ToAppear.Count; i++)
                {
                    collision.GetComponent<CamModOscar>().ToAppear[i].SetActive(false);
                }
            }
        }
    }
}
