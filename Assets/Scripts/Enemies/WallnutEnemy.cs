using UnityEngine;

public class WallnutEnemy : EnemyFactory<IDamageable>, IDamageable
{
	protected override float speed => m_speed;
	private static float m_speed = 1f;
	protected override void specialDeathEffect()
	{

	}
}
