using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CloseTabOnEscape : MonoBehaviour
{
    private GameObject currentTab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Vérifier si le joueur a actuellement un onglet ouvert
            if (currentTab != null)
            {
                // Fermer l'onglet actuel
                CloseCurrentTab();
            }
        }
    }

    void CloseCurrentTab()
    {
        // Vérifier si l'onglet actuel a un bouton de fermeture
        Button closeButton = currentTab.GetComponentInChildren<Button>();
        if (closeButton != null)
        {
            // Simuler un clic sur le bouton de fermeture pour fermer l'onglet
            ExecuteEvents.Execute(closeButton.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        }
        else
        {
            // Si aucun bouton de fermeture n'est trouvé, simplement désactiver l'onglet
            currentTab.SetActive(false);
        }

        // Réinitialiser la référence de l'onglet actuel
        currentTab = null;
    }

    public void SetCurrentTab(GameObject tab)
    {
        // Définir l'onglet actuel sur celui qui a été passé en argument
        currentTab = tab;
    }
}

