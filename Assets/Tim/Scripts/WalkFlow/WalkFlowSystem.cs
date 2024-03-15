using System.Collections.Generic;
using UnityEngine;

public class WalkFlowSystem : MonoBehaviour
{
    [SerializeField] public List<Transform> waypoints; // Liste des waypoints à suivre
    [SerializeField] public float vitesse = 1f; // Vitesse de déplacement
    [SerializeField] public float vitesseRotation = 5f; // Vitesse de rotation

    [SerializeField] private int indexWaypoint = 0; // Indice du waypoint actuel

    void Update()
    {
        if (waypoints.Count == 0)
        {
            Debug.LogWarning("Aucun waypoint défini.");
            return;
        }

        // Calculer la direction vers le prochain waypoint
        Vector3 direction = waypoints[indexWaypoint].position - transform.position;
        direction.Normalize();

        // Calculer la rotation cible
        Quaternion rotationCible = Quaternion.LookRotation(direction);

        // Effectuer une rotation progressive vers la rotation cible
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationCible, vitesseRotation * Time.deltaTime);

        // Déplacer l'objet dans la direction du waypoint
        transform.Translate(Vector3.forward * vitesse * Time.deltaTime);

        // Si l'objet est proche du waypoint, passer au waypoint suivant
        if (Vector3.Distance(transform.position, waypoints[indexWaypoint].position) < 0.1f)
        {
            indexWaypoint++;

            // Si l'indice dépasse le nombre de waypoints, réinitialiser à zéro pour boucler
            if (indexWaypoint >= waypoints.Count)
            {
                indexWaypoint = 0;
            }
        }
    }


}
