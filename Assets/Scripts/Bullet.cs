using UnityEngine;

public abstract class Bullet<T> : MonoBehaviour where T : IBullet
{
	protected Rigidbody rb;
	protected static Vector3 velocity = new(10, 0, 0);
	protected abstract string BulletTargetTag { get; }
	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}
	protected virtual void OnEnable()
	{
		Invoke("Destroy", 2);
	}
	private void Destroy()
	{
		gameObject.SetActive(false);
	}
	private void OnTriggerEnter(Collider _coll)
	{
		if (!_coll.CompareTag(BulletTargetTag)) { return; }
		if (!_coll.TryGetComponent<IDamageable>(out var _damageable)) { return; }
		_damageable.TakeDamage(1);
		Destroy();

	}
}
