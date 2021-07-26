using UnityEngine;

namespace Player
{
	/// <summary>
	/// Класс отвечаюший за перемещение персонажа по позиции.
	/// </summary>
	public class PlayerPositionMovement : MonoBehaviour
	{
		[SerializeField] private GameData gameData;
		private float _movementSpeed;

		private void Start()
		{
			_movementSpeed = gameData.MovementSpeed;
			GetComponent<Collider>().enabled = false;
			GetComponent<Rigidbody>().useGravity = false;
		}

		void Update()
		{
			Move();
		}
		private void Move()
		{
			var vector = new Vector3
			{
				x = Input.GetAxis("Horizontal") * _movementSpeed * Time.deltaTime,
				z = Input.GetAxis("Vertical") * _movementSpeed * Time.deltaTime
			};
			transform.Translate(vector.x, 0, vector.z, Space.Self);
		}
	}
}
