using UnityEngine;

public class SunflowerEnemy : EnemyFactory<IDamageable>, IDamageable
{
		protected override float speed => m_speed;
	private static float m_speed = 3f;
	protected override void specialDeathEffect()
	{
		
	}
}
