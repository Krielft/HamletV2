using UnityEngine;

public class ResourceClickScript : MonoBehaviour
{
    public int resourceId = 1; // ID de la ressource à modifier

    public void MultiplyResourceValue()
    {
        // Multiplie la valeur de l'incrément de base par 2
        AutoIncrementScript autoIncrementScript = FindObjectOfType<AutoIncrementScript>();
        if (autoIncrementScript != null)
        {
            autoIncrementScript.baseIncrement *= 2;
        }
        else
        {
            Debug.LogError("AutoIncrementScript introuvable dans la scène.");
        }
    }
}
