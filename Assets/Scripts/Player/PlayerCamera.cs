using UnityEngine;

namespace Player
{
	/// <summary>
	/// Класс отвечаюший за обзор персонажа, без применения CharacterController
	/// </summary>
	public class PlayerCamera : MonoBehaviour
	{
		[SerializeField] private GameData gameData;
		private float _camSensitivity;
		private Quaternion _origin;
		private float _angleHorizontal, _angleVertical;
		private Camera _camera;

		void Start()
		{
			_camera = GetComponentInChildren<Camera>();
			_camSensitivity = gameData.MouseSensitivity;
			_origin = transform.rotation;
			Cursor.lockState = CursorLockMode.Locked;
		}

		void Update()
		{
			Watch();
		}

		private void Watch()
		{
			_angleHorizontal += Input.GetAxis("Mouse X") * _camSensitivity;
			_angleVertical += Input.GetAxis("Mouse Y") * _camSensitivity;
			_angleVertical = Mathf.Clamp(_angleVertical, -90, 90);

			Quaternion yRotation = Quaternion.AngleAxis(_angleHorizontal, Vector3.up);
			Quaternion xRotation = Quaternion.AngleAxis(-_angleVertical, Vector3.right);

			transform.rotation = _origin * yRotation;
			_camera.transform.localRotation = xRotation;
		}
	}
}
