using UnityEngine;

public class DaveController : MonoBehaviour, IDamageable
{
	private int hp = 5;

	private void Update()
	{
		inputManager();
	}
	private void inputManager()
	{
		movement();
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			shoot();
		}
	}
	private void movement()
	{
		int _vertical = 0;
		bool _input = false;
		if (Input.GetKeyDown(KeyCode.W))
		{
			_vertical = 1;
			_input = true;
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			_vertical = -1;
			_input = true;
		}
		if (!_input) { return; }
		var _desiredPos = transform.position;
		_desiredPos.z += _vertical;
		_desiredPos.z = Mathf.Clamp(_desiredPos.z, -2, 2);
		transform.position = _desiredPos;
	}
	private void shoot()
	{
		var _bullet = Instantiate(GameManager.Instance.BulletPrefab, transform.position, Quaternion.identity);
	}

	public void TakeDamage(int _damage)
	{
		hp -= _damage;
		GameManager.Instance.OnHealthChanged?.Invoke(hp);

		if (hp > 0) { return; }
		Death();
	}
	private void Death()
	{
		gameObject.SetActive(false);
		Debug.Log("Defeat");
		GameManager.Instance.OnEndGame?.Invoke(false);
	}
}
