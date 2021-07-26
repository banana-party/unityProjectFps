using UnityEngine;
/// <summary>
/// Класс отвечающий за взрыв обьекта. Сам при колизии выключает рендеринг, а вложенные в него объекты включаются и разлетаются в стороны.
/// Был нужен в прошлом, сейчас, кажется, не актуален.
/// </summary>
public class ExplodeByShooting : MonoBehaviour
{
	[SerializeField] private GameObject[] particles;
	[SerializeField] private float explosionForce = 1000f;
	[SerializeField] private float explosionRadius = 3f;
	public void Detonate()
	{
		//gameObject.GetComponent<MeshRenderer>().enabled = false;
		Collider[] colliders = Physics.OverlapSphere(transform.position, 3);
		foreach (var particle in particles)
			particle.SetActive(true);
		foreach (var hit in colliders)
		{
			var rb = hit.GetComponent<Rigidbody>();
			if (rb != null)
				rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
		}

	}
}