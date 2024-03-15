using UnityEngine;

public class TabController : MonoBehaviour
{
    private CloseTabOnEscape tabManager;

    void Start()
    {
        // Trouver le gestionnaire d'onglets dans la scène
        tabManager = FindObjectOfType<CloseTabOnEscape>();
    }

    // Méthode appelée lorsque cet onglet devient actif
    public void ActivateTab()
    {
        // Marquer cet onglet comme actuel en appelant la méthode du gestionnaire d'onglets
        if (tabManager != null)
        {
            tabManager.SetCurrentTab(gameObject);
        }
    }
}
