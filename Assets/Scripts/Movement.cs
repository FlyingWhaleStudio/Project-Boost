using UnityEngine;

public class Movement : MonoBehaviour
{
    new Rigidbody rigidbody;
    AudioSource audioSource;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

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
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            } 
        } else {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            ApplyRotation(rotationThrust);
        }

        if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rigidbody.freezeRotation = true;
        transform.Rotate(rotationThisFrame * Vector3.forward * Time.deltaTime);
        rigidbody.freezeRotation = false;
    }
}
