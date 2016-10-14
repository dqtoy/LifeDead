using UnityEngine;
using System.Collections;
using DG.Tweening;


public class LV3MoveWall : MonoBehaviour {

    public GameObject m_endPos;

    public float m_speed;
	
    void Start()
    {
        Move();
    }
	public void Move()
    {
        transform.DOMoveY(m_endPos.transform.position.y, m_speed);
    }     
}
