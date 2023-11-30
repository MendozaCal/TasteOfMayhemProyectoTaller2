using UnityEngine;
using UnityEngine.UI;

public class Ingrediente : MonoBehaviour
{
    
    public float alfaNormal = 0.0f;
    private bool estaAsesinado = false;
    private Image ingredienteImage;

    private void Start()
    {
        ingredienteImage = GetComponent<Image>();
    }
    public void AsesinarIngrediente()
    {
        // Cambiar el alfa al valor normal
        Color color = ingredienteImage.color;
        color.a = alfaNormal;
        ingredienteImage.color = color;

        estaAsesinado = true;
    }
    public bool EstaAsesinado()
    {
        return estaAsesinado;
    }
}
