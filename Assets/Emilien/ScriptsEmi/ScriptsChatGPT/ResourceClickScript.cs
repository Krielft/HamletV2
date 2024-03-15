using UnityEngine;

public class ResourceClickScript : MonoBehaviour
{
    public int resourceId = 1; // ID de la ressource � modifier

    public void MultiplyResourceValue()
    {
        // Multiplie la valeur de l'incr�ment de base par 2
        AutoIncrementScript autoIncrementScript = FindObjectOfType<AutoIncrementScript>();
        if (autoIncrementScript != null)
        {
            autoIncrementScript.baseIncrement *= 2;
        }
        else
        {
            Debug.LogError("AutoIncrementScript introuvable dans la sc�ne.");
        }
    }
}
