using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : Singleton<InputSystem> {
	public PLayerOneActions playerInput;

	public Action OnRightClickMouse;

	private Vector2 mousePos;
	public Vector2 GetMousePosition() => mousePos;

	public void OnEnable() {
		
		playerInput = new PLayerOneActions();
		playerInput.Enable();
		
		playerInput.Player.MoveToward.performed += MoveToward;
	}

	private void Update() {
		mousePos = playerInput.Player.MousePosition.ReadValue<Vector2>();
	}

	private void MoveToward(InputAction.CallbackContext ctx) {
		OnRightClickMouse?.Invoke();
	}

	private void OnDisable() {
		playerInput.Player.MoveToward.performed -= MoveToward;
	}
	
	
}
