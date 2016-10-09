//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
      
    float hor;
    public float use_speed;
    public float g;

    float speed; 
    bool isjump = false;

    void Start()
    {
        speed = use_speed;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            isjump = true;
        }

        if(isjump)
        {
            speed += g;
            transform.position += transform.up * Time.deltaTime * speed;
        }
        
        hor = Input.GetAxis("Horizontal");                  
        transform.Translate(Vector3.right * hor * 3 * Time.deltaTime, Space.Self);
    }

    void OnCollisionEnter(Collision other)
    {
        isjump = false;
        speed = use_speed;       
    }
}
