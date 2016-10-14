using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PrabolaSport : MonoBehaviour
{
	public GameObject target;
	public float speed = 15;
	private float distanceToTarget;
	private bool move = true;


	void Start()
	{
		target = GameObject.Find ("EndDiePos");
		distanceToTarget = Vector3.Distance(this.transform.position, target.transform.position);
	}

	/// <summary>
	/// 开始运动
	/// </summary>
	public void StartSport()
	{
		StartCoroutine(Prabola());
	}
		
	/// <summary>
	/// 抛物线运动函数.
	/// </summary>
	IEnumerator Prabola()
	{
		while (move)
		{
			Vector3 targetPos = target.transform.position;
			this.transform.LookAt(targetPos);
			float angle = Mathf.Min(1, Vector3.Distance(this.transform.position, targetPos) / distanceToTarget) * 80;
			this.transform.rotation = this.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
			float currentDist = Vector3.Distance(this.transform.position, target.transform.position);

			if (currentDist < 0.5f)
				move = false;
			this.transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
			yield return null;
		}



	
	}

	void Update()
	{
		// 下落
		if(!move)
		{
			transform.position -= Time.deltaTime * Vector3.up * 10f;
		}
	}
}
