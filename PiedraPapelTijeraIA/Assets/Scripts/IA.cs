using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IA : MonoBehaviour {


    public int windowSize;
    public Text IAsays;
    public Text tasaAciertos;
    public Text decisiones;
    public Text ultimasDecisiones;
    public GameObject GIAsays;
    public GameObject GTasaAciertos;
    public GameObject GDecisiones;
    public GameObject GUltimasDecisiones;
    string opcion = "";
    string totalElecciones = "", eleccionesPredecir = "", eleccionesRegistrar = "";
    int total = 0, acierto = 0;
    string prediccion;
    //rock paper scissors
    Predictor predictor = new Predictor("rps");
    // Use this for initialization
    void Start () {

        desactivateTexts();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string getPrediccion()
    {
        return prediccion;
    }

    public void desactivateTexts()
    {
        GIAsays.SetActive(false);
        GTasaAciertos.SetActive(false);
        GDecisiones.SetActive(false);
        GUltimasDecisiones.SetActive(false);
    }

    public void IApredictions(int option)
    {
        //predictor.PrintData();
        //0 papel   1 tijera   2 piedra
        //guardamos la opcion que ha elegido el jugador
        if (option == 0)
        {
            opcion = "p";
        }
        else if (option == 1)
        {
            opcion = "s";
        }
        else if (option == 2)
        {
            opcion = "r";
        }

        total++;

        prediccion = predictor.GetMostLikely(eleccionesPredecir);
        IAsays.text = "LA IA DICE QUE HAS ELEGIDO :  " + prediccion;
        GIAsays.SetActive(true);


        if (prediccion == opcion)
        {
            acierto++;
            //Console.WriteLine("La IA ha acertado");
            tasaAciertos.text = "La IA ha acertado.  La tasa de aciertos es: " + (100 * (float)acierto / total) + "%";
            GTasaAciertos.SetActive(true);
        }

        else
        {
            //Console.WriteLine("la IA ha fallado");
            tasaAciertos.text = "La IA ha fallado.  La tasa de aciertos es: " + (100 * (float)acierto / total) + "%";
            
            GTasaAciertos.SetActive(true);
            
        }

        //acumulo la ultima opcion q he elegido
        totalElecciones += opcion;
        //acumulo la ultima opcion q ha hecho concatenando cn la penultima
        eleccionesPredecir += opcion;
        if (totalElecciones.Length - windowSize < 0)
        {
            eleccionesPredecir += opcion;
        }

        else
        {
            eleccionesPredecir = totalElecciones.Substring(totalElecciones.Length - windowSize);
        }

        if (totalElecciones.Length - windowSize - 1 < 0)
        {
            eleccionesRegistrar += opcion;
        }

        else
        {
            eleccionesRegistrar = totalElecciones.Substring(totalElecciones.Length - (windowSize + 1));
            predictor.RegisterSequence(eleccionesRegistrar);
        }

        decisiones.text = "Total decisiones: " + totalElecciones;
        GDecisiones.SetActive(true);
        ultimasDecisiones.text = "  Ultimas decisiones: " + eleccionesPredecir;
        GUltimasDecisiones.SetActive(true);

    }
}
