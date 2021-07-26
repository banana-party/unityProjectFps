using UnityEngine;

namespace Player
{
	/// <summary>
	/// Класс для обзора с помощью мыши на игроке реализованом с помощью CharacterController
	/// </summary>
	public class PlayerControllerCamera : MonoBehaviour
	{
		[SerializeField] private GameData gameData;
		[SerializeField] private Transform body;
		private float _xRotation = 0f;
		void Start()
		{
			Cursor.lockState = CursorLockMode.Locked;
		}

		void Update()
		{
			var x = Input.GetAxis("Mouse X") * gameData.MouseSensitivity * Time.deltaTime;
			var y = Input.GetAxis("Mouse Y") * gameData.MouseSensitivity * Time.deltaTime;

			_xRotation -= y;
			_xRotation = Mathf.Clamp(_xRotation, -90, 90);


			transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
			body.Rotate(Vector3.up * x);
		}
	}
}
