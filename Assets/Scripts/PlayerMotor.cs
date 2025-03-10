using UnityEngine;

[RequireComponent(typeof(Rigidbody))]  // cv dire que playerMotor ne peut pas fonctionner sans Rigidbody
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity;//la meme que dans playerController
    private Vector3 rotation;
    private Vector3 cameraRotation ;
    private Rigidbody rb;

    private void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate (Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    private void FixedUpdate()// la meme que update mais delais entre chaque appel fixe
    {
        PerformMouvement();
        PerformRotation();
    }

    private void PerformMouvement()//fonction qui fait bouger le rigidbody
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity *Time.fixedDeltaTime);
        }
    }
    
   private void PerformRotation()
    {
        rb.MoveRotation(rb.rotation*Quaternion.Euler(rotation));
        cam.transform.Rotate(-cameraRotation);
    }
}
