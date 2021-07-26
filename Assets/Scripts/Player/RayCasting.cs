using UnityEngine;

namespace Player
{
	/// <summary>
	/// Класс отвечающий за создание луча, который, если навести на цель и нажать ЛКМ, напишет в консоль - enemy detected.
	/// </summary>
	public class RayCasting : MonoBehaviour
	{
		private RaycastHit _hit;
		[SerializeField] private GameObject enemy;
		private int layerMask;
		void Start()
		{
			layerMask = 1 << enemy.layer;
		}

		void Update()
		{
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
			{
				Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _hit.distance, Color.red);
				if (Input.GetMouseButtonDown(0))
				{
					Debug.Log("Enemy detected");
				}
			}
		}
	}
}
