//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Thorn : MonoBehaviour
{
    public float m_range;
    public float m_time;
    private Vector3 m_startPos;
    private float m_leftPos;
    private float m_rightPos;
    private int m_index;

   
	
	void Start ()
    {
        m_startPos = transform.position;
        m_leftPos = m_startPos.x - m_range;
        m_rightPos = m_startPos.x + m_range;

        m_index = 0;


    }
    
    // 移向右终点
    public void Shake()
    {
        if(m_index>=3)
        {
            return;
        }

        Tweener tweener = transform.DOMoveX(m_rightPos, m_time);
        tweener.OnComplete(TweenerCall);
    }

    // 移向左终点
    void TweenerCall()
    {
        Tweener tweener = transform.DOMoveX(m_leftPos, m_time);
        tweener.OnComplete(TweenerCallStart);
    }

    // 回到原点
    void TweenerCallStart()
    {
        Tweener tweener = transform.DOMoveX(m_startPos.x, m_time);
        m_index++;

		if(m_index==3)
		{
			gameObject.AddComponent<Rigidbody>().useGravity = true;

			Destroy(gameObject,2);
		}				       
    }	

	void OnTriggerStay(Collider other)
	{
		other.gameObject.GetComponent<PatrolScript> ().StopTween ();
		other.gameObject.GetComponent<BoxCollider> ().enabled = false;
		other.gameObject.GetComponent<PrabolaSport> ().StartSport();
		Destroy (other.gameObject,4);
	}
}
