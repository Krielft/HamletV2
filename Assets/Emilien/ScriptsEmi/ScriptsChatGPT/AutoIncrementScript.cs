using UnityEngine;

public class AutoIncrementScript : MonoBehaviour
{
    private float timer = 0f;

    public int baseIncrement = 1; // Valeur de base � incr�menter par seconde

    void Update()
    {
        // Incr�mente les ressources par seconde avec la formule modifi�e
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            DataManager.Instance.resource1 += baseIncrement;
            DataManager.Instance.resource2 += baseIncrement;
            DataManager.Instance.resource3 += baseIncrement;
            DataManager.Instance.resource4 += baseIncrement;
            timer = 0f; // R�initialise le timer
        }
    }
}
