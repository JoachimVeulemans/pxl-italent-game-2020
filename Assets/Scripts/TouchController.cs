using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public FixedJoystick joystick1;
    public FixedJoystick joystick2;
    public Transform capsule;

    public int positionMultiplier = 5;
    public float rotationMultiplier = 1.5f;

    void Update()
    {
        capsule.Rotate(0, joystick2.Horizontal * rotationMultiplier, 0);
        transform.Rotate(-joystick2.Vertical * rotationMultiplier, 0, 0);

        Quaternion q = transform.localRotation;
        q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0);
        transform.localRotation = q;
        
        capsule.Translate(Vector3.forward * (joystick1.Vertical) * positionMultiplier * Time.deltaTime);
        capsule.Translate(Vector3.right * (joystick1.Horizontal) * positionMultiplier * Time.deltaTime);

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {

                    GameObject touchedObject = hit.transform.gameObject;

                    if (touchedObject.GetComponent<ChestPiece>() != null)
                    {
                        touchedObject.GetComponent<ChestPiece>().chest.ChestClicked();
                    }
                }
            }
        }
    }
}
