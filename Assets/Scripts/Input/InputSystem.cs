using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : Singleton<InputSystem> {
	[SerializeField]
	private PLayerOneActions playerInput;

	public Action OnRightClickMouse;
	public Action<float> OnScroolWheel;

	private Vector2 mousePos;
	private Vector2 movement;
	public Vector2 GetMousePosition() => mousePos;
	public Vector2 GetMovementVector() => movement;

	public void OnEnable() {
		
		playerInput = new PLayerOneActions();
		playerInput.Enable();
		
		playerInput.Player.MoveToward.performed += MoveToward;
		playerInput.Player.Move.performed += Move;
		playerInput.Player.ScrollWheel.performed += ScroolWheel;
	}

	private void Move(InputAction.CallbackContext ctx) {
	}

	private void Update() {
		mousePos = playerInput.Player.MousePosition.ReadValue<Vector2>();
		movement = playerInput.Player.Move.ReadValue<Vector2>();
	}

	private void MoveToward(InputAction.CallbackContext ctx) {
		OnRightClickMouse?.Invoke();
	}

	private void ScroolWheel(InputAction.CallbackContext ctx) {
		var value = ctx.ReadValue<Vector2>().y;
		value /= 240f; 
		OnScroolWheel?.Invoke(value);
	} 

	private void OnDisable() {
		playerInput.Player.MoveToward.performed -= MoveToward;
		playerInput.Player.Move.performed -= Move;
		playerInput.Player.ScrollWheel.performed -= ScroolWheel;
	}
	
	
}
