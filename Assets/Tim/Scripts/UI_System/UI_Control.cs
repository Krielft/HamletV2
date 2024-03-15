using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Control : MonoBehaviour
{
    [SerializeField] private GameObject cibleReset;
    [SerializeField] private GameObject positionReset;

    [SerializeField] private GameObject selfObject;

    Vector3 originalPos;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && selfObject.activeSelf == true)
        {
            CloseUI();
        }
    }

    public void ResetPosition()
    {
        originalPos = positionReset.transform.position;
        cibleReset.transform.position = originalPos;
    }

    public void CloseUI()
    {
        selfObject.SetActive(false);
        ResetPosition();
    }
}
