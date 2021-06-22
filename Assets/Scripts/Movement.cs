using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainThrustParticle;
    [SerializeField] ParticleSystem leftThrustParticle;
    [SerializeField] ParticleSystem rightThrustParticle;

    Rigidbody rb;  
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            StartThrusting();
        }
        else {
            audioSource.Stop();
        }
    }

        void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            RotateLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(mainThrust * Vector3.up * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        mainThrustParticle.Play();
    }

    private void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        rightThrustParticle.Play();
    }

    private void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        leftThrustParticle.Play();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(rotationThisFrame * Vector3.forward * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
