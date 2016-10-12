using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DropScript : MonoBehaviour
{

    public float m_dropSpeed;
    private bool m_isDrop;
    private Rigidbody m_rig;

    void Start()
    {
        m_rig = transform.parent.GetComponent<Rigidbody>();
        m_isDrop = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {

            //StartCoroutine("Wait");

            Destroy(transform.parent.gameObject, 3);
        }
    }

    //IEnumerator Wait()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    m_isDrop = true;
    //}

    //void Update()
    //{
    //    if (m_isDrop == true)
    //    {
    //        Drop();
    //    }
    //}

    void Drop()
    {
        transform.parent.position += Vector3.down * m_dropSpeed * Time.deltaTime;
    }
}