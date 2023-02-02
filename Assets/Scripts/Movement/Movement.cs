using System;
using UnityEngine;
using UnityEngine.AI;


public class Movement : MonoBehaviour {
    private NavMeshAgent agent;

    public Camera camera;

    private void OnEnable() {
        InputSystem.instance.OnRightClickMouse += MoveToward;
    }

    
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void MoveToward() {
        RaycastHit hit;
        
        if (Physics.Raycast(camera.ScreenPointToRay(InputSystem.instance.GetMousePosition()), out hit, 100)) {
            agent.destination = hit.point;
        }
    }

    private void OnDisable() {
        InputSystem.instance.OnRightClickMouse -= MoveToward;
    }
}
