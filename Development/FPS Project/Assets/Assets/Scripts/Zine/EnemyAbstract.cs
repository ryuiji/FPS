using UnityEngine;
using System.Collections;

public abstract class EnemyAbstract : MonoBehaviour 
{
	public int health;
	public int damage;
	public float moveSpeed;
	public bool lineOfSight;
	public float lengthOfSight;
	public NavMeshAgent agent;

	public abstract void Aggro();
	public abstract void DeAggro();
	public abstract void Chase();
	public abstract void Roam();
	public abstract void Attack();
	public abstract void TakeDamage(int damage);
	public abstract IEnumerator Death();
}
