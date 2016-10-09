//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;

public class CameraMove01 : MonoBehaviour {

    public GameObject m_girl;
	
    void Awake()
    {
        m_girl = GameObject.FindWithTag("Player");
    }

	void Start ()
    {
	
	}
	
	
	void Update ()
    {
        transform.position = new Vector3(m_girl.transform.position.x, transform.position.y, transform.position.z); 
	}
}
