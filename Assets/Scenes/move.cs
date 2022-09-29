using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{      
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float Hor = Input.GetAxis("Horizontal");//When you press 'a' 'd' key returns a value of [-1, 1]
        float Ver = Input.GetAxis("Vertical");//When you press 'w' 's' key returns a value of [-1, 1]
        transform.Translate(Vector3.forward * Ver * Time.deltaTime * 7);//move forward or back
        transform.Rotate(Vector3.up * Hor * 20 * Time.deltaTime);//rotate left right
}
}
