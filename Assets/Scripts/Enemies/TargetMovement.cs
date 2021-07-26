using Spawners;
using UnityEngine;

namespace Enemies
{
	/// <summary>
	/// Класс отвечающий за перемещение цели для стрельбы.
	/// </summary>
	public class TargetMovement : MonoBehaviour
	{
		private TargetSpawner _spawner;
		private Vector3 _destroyPosition;
		private void Start()
		{
			_spawner = FindObjectOfType<TargetSpawner>();
			_destroyPosition = RandomYAxisPosition(_spawner.DestroyPosition);
		}

		/// <summary>
		/// Отправляет объект с указанной скоростью к конечной точке, долетев в которую уничтожается.
		/// </summary>

		private void FixedUpdate()
		{
			gameObject.transform.position = Vector3.MoveTowards(transform.position, _destroyPosition, _spawner.TargetSpeed * Time.timeScale);
			if (transform.position == _destroyPosition)
				gameObject.SetActive(false);
		}

		/// <summary>
		/// Генерирует случайную точку координаты Y
		/// </summary>
		private Vector3 RandomYAxisPosition(Vector3 position)
		{
			position.y += Random.Range(-2.5f, 2.5f);
			return position;
		}
	}
}
