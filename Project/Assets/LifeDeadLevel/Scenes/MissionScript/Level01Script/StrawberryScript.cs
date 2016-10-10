//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;

public class StrawberryScript : MonoBehaviour
{
    private GameObject m_key;

	
	void Start ()
    {
        m_key = GameObject.Find("key");        
    }

    void ShowKey()
    {
        m_key.GetComponent<SpriteRenderer>().enabled = true;
        m_key.AddComponent<BoxCollider>();
        m_key.GetComponent<BoxCollider>().isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            ShowKey();

            Destroy(this.gameObject, 0.1f);
        }
    }
}
