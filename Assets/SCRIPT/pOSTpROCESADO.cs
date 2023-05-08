using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class pOSTpROCESADO : MonoBehaviour
{
    //VARIABLES
    private Volume volume; 
    private Vignette vignette; //efecto -->PostProccesing

    private void Awake()
    {
        volume = GetComponent<Volume>(); 
        //establecer referencia // en caso de cargar otros valores como enemigo
        //y player la misma linea peor en el start
    }
    private void Start()
    {
        volume.profile.TryGet(out vignette); //encontrar efecto viñeta y la devuelve ''out''
      
        //modificar el efecto
        vignette.intensity.value = 0.5f;
        vignette.color.value = Color.yellow;

        StartCoroutine(Desactive());
    }

    private IEnumerator Desactive()
    {
        yield return new WaitForSeconds(3);
        vignette.intensity.value = 1f;
        vignette.color.value = Color.red;

        yield return new WaitForSeconds(2);
        vignette.active = false;
    }
}
