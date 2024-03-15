using Hamlet.Game.Runtime.Player;
using UnityEngine;

public class Panel_Activator : MonoBehaviour
{
    [SerializeField] private GameObject building;
    [SerializeField] private GameObject buildingPanel;

    [SerializeField] private Camera camera;

    Collider buildingCollider;





    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = camera.ScreenPointToRay(mousePosition);

            Debug.Log("Click");
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == building && !GameObject.FindGameObjectWithTag("BuildingPanel"))
                {
                    buildingPanel.SetActive(true);
                    zoomCamera.enabled = false;
                    Freeze();
                    Inventory.Instance.actualBuilding = building;

                    Debug.Log("Detect if Click hit Collider");
                }
            }
        }
    }

    [SerializeField] private GameObject cameraScript;

    [SerializeField] private MonoBehaviour zoomCamera;



    private void Start()
    {
        buildingCollider = building.GetComponent<Collider>();
        zoomCamera = cameraScript.GetComponent<MonoBehaviour>();
    }

    private void Update()
    {
        OnMouseDown();

    }



    private void Freeze()
    {
        zoomCamera.enabled = false;
    }

    public void UnFreeze()
    {
        zoomCamera.enabled = true;
    }
}
