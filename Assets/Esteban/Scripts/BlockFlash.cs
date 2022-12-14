using UnityEngine;
using UnityEngine.UI;

public class BlockFlash : MonoBehaviour
{
    public float duracionBF;

    public float recargaBF;

    public Text txtContadorBF;
    private bool blockFlashBool;
    private Animator animBlockFlash;
    private BarraBlockSplash_Es barraBlockSplash;

    public bool BlockFlashBool { get => blockFlashBool; set => blockFlashBool = value; }

    //public float DuracionBF { get => duracionBF; set => duracionBF = value; }
    //public float RecargaBF { get => recargaBF; set => recargaBF = value; }

    void Start()
    {
        barraBlockSplash = GetComponent<BarraBlockSplash_Es>();
        duracionBF = 0.0f;
        recargaBF = 0.0f;
        animBlockFlash = GetComponent<Animator>();
        animBlockFlash.SetBool("circleFlash", false);
        txtContadorBF.color = Color.black;
    }
    void Update()
    {
        if (duracionBF == 0.0f && recargaBF == 0.0f)
        {
            if (BlockFlashBool == false && Input.GetKeyDown(KeyCode.X))
            {
                recargaBF = 0.0f;//Recarga a 0
                duracionBF = 5.40f;//Duración del blockFlash
                barraBlockSplash.setTiempoMaximo(duracionBF);
                blockFlashBool = true;
                animBlockFlash.SetBool("circleFlash", blockFlashBool);//Se activa la animación
                Debug.Log("BlockFlash true " + blockFlashBool);
            }
        }
        if (duracionBF > 0.0f && recargaBF == 0.0f && BlockFlashBool == true)
        {
            duracionBF -= Time.deltaTime; //Se pone en marcha el contador de duración de la animación            
            barraBlockSplash.setTiempoActual(duracionBF);
            barraBlockSplash.setColorBarrra("duracion");
            txtContadorBF.color = Color.green;
            txtContadorBF.text = duracionBF.ToString("00");//Lo seteo en el Text
        }
        if (duracionBF < 0.0f && recargaBF == 0.0f && BlockFlashBool == true)
        {
            duracionBF = 0.0f;//Duración apagada durante la recarga
            recargaBF = 10.40f;//Tiempo de recarga
            barraBlockSplash.setTiempoMaximo(recargaBF);            
            blockFlashBool = false;
            animBlockFlash.SetBool("circleFlash", blockFlashBool);//Se desactiva la animación
        }
        if (duracionBF == 0.0f && recargaBF > 0.0f && BlockFlashBool == false)
        {
            recargaBF -= Time.deltaTime;//Cuenta atrás de la recarga
            barraBlockSplash.setColorBarrra("recarga");
            barraBlockSplash.setTiempoActual(recargaBF);
            txtContadorBF.color = Color.red;
            txtContadorBF.text = recargaBF.ToString("00");//Seteo en el Text la cuenta atrás
        }
        if (duracionBF == 0.0f && recargaBF < 0.0f && BlockFlashBool == false)
        {
            recargaBF = 0.0f;//Resetear la recarga
            blockFlashBool = false;//Reseteo blockFlash
            txtContadorBF.color = Color.black;
            barraBlockSplash.setTiempoMaximo(1);
            barraBlockSplash.setTiempoActual(1);
            barraBlockSplash.setColorBarrra("defecto");
            txtContadorBF.text = "00";
        }
    }
    //public bool getStateBlockFlash()
    //{
    //    return blockFlashBool;
    //}



}
