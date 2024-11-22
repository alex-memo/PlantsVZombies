using UnityEngine;

public class PeashooterEnemy : EnemyFactory<IDamageable>, IDamageable
{
		protected override float speed => m_speed;
	private static readonly float m_speed = 3f;
	private static readonly float fireRate = 2.5f;
	private float lastFireTime;
	protected override void specialDeathEffect()
	{

	}
	protected override void Update()
	{
		base.Update();
		if (Time.time - lastFireTime > fireRate)
		{
			lastFireTime = Time.time;
			Shoot();
		}
	}
	private void Shoot()
	{
		var _bullet = Instantiate(GameManager.Instance.EnemyBulletPrefab, transform.position, Quaternion.identity);
	}
}
