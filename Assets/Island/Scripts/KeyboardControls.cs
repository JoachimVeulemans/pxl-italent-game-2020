using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{
    public Transform capsule;

    public int positionMultiplier = 5;
    public float rotationMultiplier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
        {
            capsule.Translate(Vector3.forward * positionMultiplier * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            capsule.Translate(Vector3.right * -1 * positionMultiplier * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            capsule.Translate(Vector3.forward * -1 * positionMultiplier * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            capsule.Translate(Vector3.right * positionMultiplier * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
