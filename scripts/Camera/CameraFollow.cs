using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float RotationSpeed = 1;
    public Transform Target,Player;

    float mouseX,mouseY;

    // public float smoothing = 5f;

    // Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
       // offset = transform.position - target.position;
    }

   

    void FixedUpdate()
    {

        CamControl();

      //  Vector3 targetCamPos = target.position + offset;

      //  transform.position = Vector3.Lerp(transform.position,targetCamPos,smoothing * Time.deltaTime);

    }

    void CamControl(){
        
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        if (Input.GetKey(KeyCode.C)){
          Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
       else{

          
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX ,0);
            
        }
    }

}
