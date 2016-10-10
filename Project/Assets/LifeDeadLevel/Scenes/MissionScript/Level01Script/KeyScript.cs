//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour
{
    private GameObject m_doorWay;

    void Start()
    {

        m_doorWay = GameObject.Find("DoorWay");

    }


    void ShowDoorWay()
    {
        m_doorWay.AddComponent<BoxCollider>();
        m_doorWay.GetComponent<BoxCollider>().isTrigger = true;
        m_doorWay.GetComponent<ParticleSystem>().Play();
    }

    void OnTriggerEnter(Collider other)
    {      
        if (other.gameObject.tag.Equals("Player"))
        {
            ShowDoorWay();
            Destroy(this.gameObject, 0.2f);                   
        }
    }

   
}