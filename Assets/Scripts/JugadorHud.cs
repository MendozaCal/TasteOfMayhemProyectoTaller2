using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugadorHud : MonoBehaviour
{
    public Ingrediente[] ingredientesEnHUD;
    public Canvas hudCanvas;
    public TiempoDeEsperaCambioDeNivel tiempoDeEsperaScript; // Asigna el script desde el Inspector


    public void AsesinarEnemigoAsociado(Ingrediente ingredienteAsociado)
    {
        if (ingredienteAsociado != null)
        {
            // Asesina al enemigo asociado al ingrediente
            ingredienteAsociado.AsesinarIngrediente();

            // Verifica si todos los enemigos asociados han sido asesinados
            if (TodosEnemigosAsociadosAsesinados())
            {
                // Llama al m�todo para activar el cambio de escena despu�s de la pantalla de puntaje
                tiempoDeEsperaScript.ActivarCambioDeEscena();
            }
        }
    }
    private bool TodosEnemigosAsociadosAsesinados()
    {
        foreach (Ingrediente ingrediente in ingredientesEnHUD)
        {
            if (ingrediente != null && !ingrediente.EstaAsesinado())
            {
                // Si al menos un enemigo asociado a�n no ha sido asesinado, retorna false
                return false;
            }
        }

        // Todos los enemigos asociados han sido asesinados
        return true;
    }

   
}
