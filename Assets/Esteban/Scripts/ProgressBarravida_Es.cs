using UnityEngine;
using UnityEngine.UI;

public class ProgressBarravida_Es : MonoBehaviour
{

    private Image imageBarraProgresoVida;
    private float vidaActual;
    private float vidaMaxima;
    //private BlockFlash blockFlash;
    private void Start()
    {
        imageBarraProgresoVida = transform.Find("ProgressVida").GetComponent<Image>();
        vidaActual = 1;
        vidaMaxima = 1;
    }

    void Update()
    {
        //tiempoActual = blockFlash.duracionBF;
        //tiempoMaximo = blockFlash.recargaBF;
        imageBarraProgresoVida.fillAmount = vidaActual / vidaMaxima;
    }
    public void setVidaActual(float t1)
    {
        //Debug.Log("Vida Actual" + t1);
        vidaActual = t1;
    }
    public void setVidaMaxima(float t2)
    {
        //Debug.Log("Vida Máxima" + t2);
        vidaMaxima = t2;
    }
    public void setColorBarrra(string tipoProgreso)
    {
        if (tipoProgreso == "duracion")
        {
            imageBarraProgresoVida.color = new Color32(171, 176, 11, 255);

        }
        else if (tipoProgreso == "recarga")
        {
            imageBarraProgresoVida.color = new Color32(202, 14, 14, 255);
        }
        else if (tipoProgreso == "defecto")
        {
            imageBarraProgresoVida.color = new Color32(14, 159, 202, 255);
        }
    }
}
