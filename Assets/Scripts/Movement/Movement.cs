using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour {
    private NavMeshAgent agent;

    public Camera camera;
    
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        InputSystem.instance.OnRightClickMouse += MoveToward;
    }

    private void MoveToward() {
        RaycastHit hit;
        
        if (Physics.Raycast(camera.ScreenPointToRay(InputSystem.instance.GetMousePosition()), out hit, 1000)) {
            agent.destination = hit.point;
        }
    }

    private void OnDisable() {
        InputSystem.instance.OnRightClickMouse -= MoveToward;
    }
}
