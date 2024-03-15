using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToBuildPanel_Activator : MonoBehaviour
{
    [SerializeField] private GameObject toBuildPanel;

    [SerializeField] private GameObject toBuildBuilding;
    [SerializeField] private GameObject buildedBuilding;

    public ParticleSystem smokeEffect;

    [SerializeField] private Camera camera;

    private void Awake()
    {
        smokeEffect = GameObject.Find("Smoke_Effect").GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        OnMouseDown();
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = camera.ScreenPointToRay(mousePosition);

            Debug.Log("Click");
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.tag == "toBuild")
                {
                    toBuildPanel.SetActive(true);
                    Debug.Log("Click hit ToBuild Collider");
                }
            }
        }
    }

    public void Build()
    {
        smokeEffect.Play();
        toBuildPanel.SetActive(false);
        toBuildBuilding.SetActive(false);
        buildedBuilding.SetActive(true);
    }
}
