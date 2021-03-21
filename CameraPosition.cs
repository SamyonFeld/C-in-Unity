using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject _camera;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(transform.position.x - 4, transform.position.y - 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _camera.transform.position = gameObject.transform.position + position;
    }
}
