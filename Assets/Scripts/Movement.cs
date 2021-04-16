using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    new Rigidbody rigidbody;
    [SerializeField] float mainThrust = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(mainThrust * Vector3.up * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Q");
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
        }
    }
}
