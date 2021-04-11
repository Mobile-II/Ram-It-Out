using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPath : MonoBehaviour
{
    public GameObject DestroyObjectVersion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        var targetObject = collision.gameObject.tag;
        if (targetObject == "Box" )
        {
            Instantiate(DestroyObjectVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
