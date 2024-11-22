using UnityEngine;

public class PlayerBullet : Bullet<IBullet>
{
	protected override string BulletTargetTag => bulletTargetTag;
	private static string bulletTargetTag = "Enemy";

	protected override void OnEnable()
	{
		base.OnEnable();
		rb.linearVelocity = velocity;
	}
}
