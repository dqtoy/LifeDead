
/// <summary>
/// 碰到Player标签的物体该脚本所挂的物体会变色 每次碰到会变一种色 共有三种色
/// </summary>
/// 
using UnityEngine;
using System.Collections;

public class ChangeColorScript : MonoBehaviour
{

	// 当前变换的颜色
	private int m_colorIndex;
	// 颜色种类个数
	private int m_maxColorIndex;
	// 网格渲染器组件
	private MeshRenderer m_meshRenderer;


	// Use this for initialization
	void Start ()
	{
		m_colorIndex = 0;
		m_maxColorIndex = 2;
		m_meshRenderer = transform.GetComponent<MeshRenderer> ();
	}

	/// <summary>
	/// 碰撞器
	/// </summary>
	/// <param name="other">Other.</param>
	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag.Equals ("Player")) {
			
			if (m_colorIndex <= m_maxColorIndex) {				
				ChangeColor (m_colorIndex);
				m_colorIndex++;

			}
		}
	}

	/// <summary>
	/// 改变颜色
	/// </summary>
	/// <param name="colorIndex">Color index.</param>
	void ChangeColor (int colorIndex)
	{
		switch (colorIndex) {
		case 0:
			m_meshRenderer.material.color = Color.red;
			break;
		case 1:
			m_meshRenderer.material.color = Color.yellow;
			break;
		case 2:
			m_meshRenderer.material.color = Color.green;
			break;
		default:
			break;
		}						
	}
		
}
