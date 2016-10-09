//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;

public class CameraLevelScript : MonoBehaviour
{
    private GameObject m_player;
    private float m_offestPos;
    private Vector3 m_playerPos;
    private Vector3 m_cameraPos;
    private bool m_isCameraMove;
    private Vector3 m_cameraStartPos;
    private Vector3 m_cameraEndPos;

    void Awake()
    {
        m_isCameraMove = false;
        
    }
	
	void Start ()
    {
        m_player = GameObject.FindWithTag("Player");
        m_playerPos = m_player.transform.position;
        m_cameraPos = transform.position;
        m_offestPos = m_cameraPos.x - m_playerPos.x;
        m_cameraStartPos = GameObject.FindWithTag("CameraStartPos").transform.position;
        m_cameraEndPos = GameObject.FindWithTag("CameraEndPos").transform.position;

    }
	
	
	void Update ()
    {
        m_playerPos = m_player.transform.position;
               
        if (m_playerPos.x < m_cameraEndPos.x && m_playerPos.x > m_cameraStartPos.x)
        {
            m_isCameraMove = true;
           
        }
        else
        {           
            m_isCameraMove = false;
        }
      
        if (m_isCameraMove)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(m_player.transform.position.x, transform.position.y, transform.position.z), 0.1f);           
        }
        
    }
}
