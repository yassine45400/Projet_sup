using UnityEngine;

[RequireComponent (typeof(PlayerMotor))]  // cv dire que playerController ne peut pas fonctionner sans PlayerMotor
public class PlayerController : MonoBehaviour
{
    [SerializeField]//pour faire apparaitre speed dans l'interface unity(car private)
    private float speed=3f;

    [SerializeField]//pour faire apparaitre mouseSensivity dans l'interface unity(car private)
    private float mouseSensivityX=3f;

    [SerializeField]
    private float mouseSensivityY = 3f;


    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();//dans motor on stock le script playerMotor
    }

    private void Update()// on calcule la vitesse du mouvement du joueur
    {
        float xMov = Input.GetAxisRaw("Horizontal");//Q touché = -1  D touché = 1
        float zMov = Input.GetAxisRaw("Vertical");// S touché = -1  Z touché = 1

        Vector3 moveHorizontal = transform.right * xMov;//Gauche droite 
        Vector3 moveVertical = transform.forward * zMov;// Haut bas

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;// le mouvement

        motor.Move(velocity);


        //on calcule les mouvements de souris
        float yRot = Input.GetAxisRaw("Mouse X");//gauche droite
        Vector3 rotation=new Vector3(0, yRot, 0)* mouseSensivityX;

        motor.Rotate(rotation);


        //on calcule les mouvements de camera
        float xRot = Input.GetAxisRaw("Mouse Y");//gauche droite
        Vector3 cameraRotation = new Vector3(xRot, 0, 0) * mouseSensivityY;

        motor.RotateCamera(cameraRotation);
    }
}
