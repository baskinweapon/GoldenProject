using UnityEngine;

public class RTSCameraSystem : MonoBehaviour {
    [SerializeField] private Camera _camera;

    public float speedMovement = 1f;

    private void OnEnable() {
        InputSystem.instance.OnScroolWheel += Zoom;
    }

    private void Update() {
        var vector = InputSystem.instance.GetMovementVector();
        var offset = new Vector3(vector.x, 0, vector.y);
        var position = _camera.transform.position;
        position = Vector3.Lerp(position,
            position + offset,
            Time.deltaTime * speedMovement);
        _camera.transform.position = position;


        if (zooming) {
            var vec = new Vector3();
            vec.y = -currentZoomValue;
            position = Vector3.Lerp(position,
                position + vec,
                Time.deltaTime * timeZoomingSpeed);
            _camera.transform.position = position;
        }
    }
    
    private bool zooming;
    private float currentZoomValue;
    public float speedZooming;
    public float timeZoomingSpeed;
    private void Zoom(float value) {
        zooming = true;
        currentZoomValue = value * speedZooming;
    }
    

    private void OnDisable() {
        InputSystem.instance.OnScroolWheel -= Zoom;
    }
}
