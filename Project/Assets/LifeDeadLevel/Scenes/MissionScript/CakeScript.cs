//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;

public class CakeScript : MonoBehaviour {

    private GameObject m_strawberry;
   


    void Start ()
    {
        m_strawberry = GameObject.Find("strawberry");      
    }
	
    void ShowStrawberry()
    {
        m_strawberry.GetComponent<SpriteRenderer>().enabled = true;
        m_strawberry.AddComponent<BoxCollider>();
        m_strawberry.GetComponent<BoxCollider>().isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {       
        if(other.gameObject.tag.Equals("Player"))
        {
            ShowStrawberry();

            Destroy(this.gameObject,0.1f);
        }
    }
}
