
/// <summary>
/// 这个脚本实现了物体从起点到终点的往复巡逻运动
/// </summary>

using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PatrolScript : MonoBehaviour
{
	// 物体起始点
	private Vector3 m_startPos;
	// 物体交换点
	private Vector3 m_tempPos;
	// 终点位置对象
	public GameObject m_endPosGameObject;
	// 物体移动到终点的时间
	public float m_moveDelay;

	void Start ()
	{	
		Init ();
	}

	/// <summary>
	/// 初始化
	/// </summary>
	void Init ()
	{
		m_startPos = transform.position;
		m_tempPos = m_endPosGameObject.transform.position;
		Patrol ();
	}

	/// <summary>
	/// 巡逻
	/// </summary>
	void Patrol ()
	{
		Tweener tweener = transform.DOMove (m_tempPos, m_moveDelay);
		tweener.OnComplete (ChangePos);
	}

	/// <summary>
	/// 切换巡逻点
	/// </summary>
	void ChangePos ()
	{
		Vector3 m_endPos = m_endPosGameObject.transform.position;
		m_tempPos = (m_tempPos == m_endPos) ? (m_tempPos = m_startPos) : (m_tempPos = m_endPos);
		Patrol ();
	}
}
