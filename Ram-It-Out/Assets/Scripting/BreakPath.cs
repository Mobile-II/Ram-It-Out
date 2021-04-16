using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPath : MonoBehaviour
{
    public GameObject DestroyObjectVersion;
    public BoxScript Box;
    bool isSpeedUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isSpeedUp = Box.isSpeedUp;
    }
    void OnCollisionEnter(Collision collision)
    {
        var targetObject = collision.gameObject.tag;
        if (targetObject == "Box" || isSpeedUp == true)
        {
            Instantiate(DestroyObjectVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
