using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;

    // Variables pour chaque ressource
    public int resource1 = 0;
    public int resource2 = 0;
    public int resource3 = 0;
    public int resource4 = 0;

    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DataManager>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("DataManagerSingleton");
                    _instance = singletonObject.AddComponent<DataManager>();
                }
            }

            return _instance;
        }
    }

    // ... (autres méthodes et fonctionnalités, si nécessaire)
}
