using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    public GameObject bola;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - bola.transform.position;
    }

    // Update is called once per frame
    void lateUpdate()
    {
        transform.position = bola.transform.position + offset;
    }
}
