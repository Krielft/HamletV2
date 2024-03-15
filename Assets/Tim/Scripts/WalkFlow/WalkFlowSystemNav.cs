using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkFlowSystemNav : MonoBehaviour
{

    [SerializeField] public Transform target;
    private NavMeshAgent pnj;


    // Start is called before the first frame update
    void Start()
    {
        pnj = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        pnj.SetDestination(target.position);
    }
}
