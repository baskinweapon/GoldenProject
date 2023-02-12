using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Main : Singleton<Main> {
	
	public void LoadFirstScene() {
		SceneManager.LoadScene(1);
	}
}
