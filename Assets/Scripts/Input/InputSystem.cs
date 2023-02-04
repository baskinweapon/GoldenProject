using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : Singleton<InputSystem> {
	public PLayerOneActions playerInput;

	public Action OnRightClickMouse;

	private Vector2 mousePos;
	private Vector2 movement;
	public Vector2 GetMousePosition() => mousePos;
	public Vector2 GetMovementVector() => movement;

	public void OnEnable() {
		
		playerInput = new PLayerOneActions();
		playerInput.Enable();
		
		playerInput.Player.MoveToward.performed += MoveToward;
		playerInput.Player.Move.performed += Move;
	}

	private void Move(InputAction.CallbackContext ctx) {
		Debug.Log(ctx.ReadValue<Vector2>());
	}

	private void Update() {
		mousePos = playerInput.Player.MousePosition.ReadValue<Vector2>();
		movement = playerInput.Player.Move.ReadValue<Vector2>();
	}

	private void MoveToward(InputAction.CallbackContext ctx) {
		OnRightClickMouse?.Invoke();
	}

	private void OnDisable() {
		playerInput.Player.MoveToward.performed -= MoveToward;
		playerInput.Player.Move.performed -= Move;
	}
	
	
}
