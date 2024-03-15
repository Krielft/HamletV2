using UnityEngine;

public class TabController : MonoBehaviour
{
    private CloseTabOnEscape tabManager;

    void Start()
    {
        // Trouver le gestionnaire d'onglets dans la sc�ne
        tabManager = FindObjectOfType<CloseTabOnEscape>();
    }

    // M�thode appel�e lorsque cet onglet devient actif
    public void ActivateTab()
    {
        // Marquer cet onglet comme actuel en appelant la m�thode du gestionnaire d'onglets
        if (tabManager != null)
        {
            tabManager.SetCurrentTab(gameObject);
        }
    }
}
