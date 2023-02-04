using System;
using UnityEngine;

public class RTSCameraSystem : MonoBehaviour {
    [SerializeField] private Camera _camera;

    public float sppedMovement = 1f;

    private void Update() {
        var vector = InputSystem.instance.GetMovementVector();
        var offset = new Vector3(vector.x, 0, vector.y);
        var position = _camera.transform.position;
        position = Vector3.Lerp(position,
            position + offset,
            Time.deltaTime * sppedMovement);
        _camera.transform.position = position;
    }
}
