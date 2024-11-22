using UnityEngine;

public abstract class EnemyFactory<T> : MonoBehaviour where T : IDamageable
{
	protected Rigidbody rb;
	protected static Vector3 direction = new(-1, 0, 0);
	protected abstract float speed { get; }
	protected int hp;
	protected static int maxHp = 1;
	public void TakeDamage(int _damage)
	{
		hp -= _damage;
		if (hp > 0) { return; }
		Death();
	}
	protected virtual void Death()
	{
		gameObject.SetActive(false);
		specialDeathEffect();
	}
	protected abstract void specialDeathEffect();
	protected virtual void Awake()
	{
		rb = GetComponent<Rigidbody>();
		hp = maxHp;
	}
	protected virtual void OnEnable()
	{
		//rb.linearVelocity = velocity;
	}
	protected virtual void Update()
	{
		rb.linearVelocity = direction * speed;
		if (transform.position.x < -10)
		{
			gameObject.SetActive(false);
			Debug.Log("Defeat");
		}
	}
	protected virtual void OnCollisionEnter(Collision _coll)
	{
		if (!_coll.collider.CompareTag("Player")) { return; }
		if (!_coll.collider.TryGetComponent<IDamageable>(out var _damageable)) { return; }
		_damageable.TakeDamage(2);
		Death();
	}

}
