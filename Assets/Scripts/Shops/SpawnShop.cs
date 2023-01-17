using UnityEngine;
using UnityEngine.UI;

public class SpawnShop : Shop {
		[SerializeField] private Canvas _canvasUI;
		[SerializeField] private Button _openShopButton;

		private void OnEnable() {
			_openShopButton.onClick.AddListener(OpenShopUI);
		}

		public override void OpenShopUI() {
			_canvasUI.gameObject.SetActive(!_canvasUI.gameObject.activeSelf);
		}

		public override void Buy() {
		}

		private void OnDisable() {
			_openShopButton.onClick.RemoveListener(OpenShopUI);
		}
}
