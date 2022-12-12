using UnityEngine;
using UnityEngine.UI;

public class BarraBlockSplash_Es : MonoBehaviour
{

    public Image barraProgreso;
    private float tiempoActual;
    private float tiempoMaximo;
    //private BlockFlash blockFlash;
    private void Start()
    {
        //blockFlash= GetComponent<BlockFlash>();
        tiempoActual = 1;
        tiempoMaximo = 1;
    }

    void Update()
    {
        //tiempoActual = blockFlash.duracionBF;
        //tiempoMaximo = blockFlash.recargaBF;
        barraProgreso.fillAmount = tiempoActual / tiempoMaximo;
    }
    public void setTiempoActual(float t1)
    {
        tiempoActual = t1;
    }
    public void setTiempoMaximo(float t2)
    {
        tiempoMaximo = t2;
    }
    public void setColorBarrra(string tipoProgreso)
    {
        if (tipoProgreso == "duracion")
        {
            barraProgreso.color = new Color32(171, 176, 11,255);

        }
        else if (tipoProgreso == "recarga")
        {
            barraProgreso.color = new Color32(202, 14, 14,255);
        }
        else if (tipoProgreso == "defecto")
        {
            barraProgreso.color = new Color32(14, 159, 202,255);
        }
    }
}
