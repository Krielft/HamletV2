using UnityEngine;

public class AutoIncrementScript : MonoBehaviour
{
    private float timer = 0f;

    public int baseIncrement = 1; // Valeur de base à incrémenter par seconde

    void Update()
    {
        // Incrémente les ressources par seconde avec la formule modifiée
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            DataManager.Instance.resource1 += baseIncrement;
            DataManager.Instance.resource2 += baseIncrement;
            DataManager.Instance.resource3 += baseIncrement;
            DataManager.Instance.resource4 += baseIncrement;
            timer = 0f; // Réinitialise le timer
        }
    }
}
