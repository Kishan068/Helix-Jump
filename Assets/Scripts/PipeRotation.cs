using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeRotation : MonoBehaviour
{
    float rotateSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDrag()
    {
        float hor = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * -hor * rotateSpeed);
    }
}
