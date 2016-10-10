//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MoveRockScript : MonoBehaviour {
	
    public GameObject m_endPos;
    public float m_moveSpeed;
    private Vector3 m_startPos;

	void Start ()
    {
        m_startPos = transform.position;
        MoveToEndPos();
    }
	
	
	

    void MoveToEndPos()
    {        
        Tweener tweener = transform.DOMove(m_endPos.transform.position, m_moveSpeed);           
        tweener.OnComplete(MoveToStartPos);                                      
    }

    void MoveToStartPos()
    {
        Tweener tweener = transform.DOMove(m_startPos, m_moveSpeed);
        tweener.OnComplete(MoveToEndPos);
    }
}
