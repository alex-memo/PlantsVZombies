using UnityEngine;

public class EnemyBullet : Bullet<IBullet>
{
	protected override string BulletTargetTag => bulletTargetTag;
	private static string bulletTargetTag = "Player";
	protected override void OnEnable()
	{
		base.OnEnable();
		rb.linearVelocity = -velocity;
	}
}
