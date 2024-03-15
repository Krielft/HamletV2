using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceDisplayScript : MonoBehaviour
{
    public TextMeshProUGUI resource1Text;
    public TextMeshProUGUI resource2Text;
    public TextMeshProUGUI resource3Text;
    public TextMeshProUGUI resource4Text;

    void Update()
    {
        // Met à jour les textes avec les valeurs actuelles des ressources
        if (resource1Text != null) resource1Text.text = "Gold : " + DataManager.Instance.resource1;
        if (resource2Text != null) resource2Text.text = "Food : " + DataManager.Instance.resource2;
        if (resource3Text != null) resource3Text.text = "Wood : " + DataManager.Instance.resource3;
        if (resource4Text != null) resource4Text.text = "Stone : " + DataManager.Instance.resource4;
    }
}
