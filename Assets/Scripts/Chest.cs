using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject canvas;
    public Transform chestTop;
    public int canvasLerpingSpeed = 1;
    public int chestLerpingSpeed = 1;

    private bool open = false;
    private bool busy = false;
    private Quaternion chestTopOpenPosition = Quaternion.Euler(-120, 0, 0);
    private Vector3 canvasOpenPosition;
    private bool finished = false;
    private float timeLeft = 60;

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(CloseCanvas());
        canvasOpenPosition = canvas.transform.localPosition;
        canvas.transform.localPosition = Vector3.zero;
    }

    private void Touched()
    {
        if (!busy)
        {
            if (open)
            {
                Close();
            }
            else
                StartCoroutine(OpenCanvas());
        }
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.K))
            // Touched();
        if (open)
        {
            timeLeft -= Time.deltaTime;
            Debug.Log(timeLeft);
            if (timeLeft < 0)
            {
                if (open)
                {
                    Close();
                }
            }
        }
    }

    private void Close()
    {
        open = false;
        timeLeft = 60;
        StartCoroutine(CloseCanvas());
        if (!finished)
        {
            finished = true;
            FindObjectOfType<Finished>().ChestFinished();
        }
    }

    public void ChestClicked()
    {
        Touched();
    }

    private IEnumerator OpenCanvas()
    {
        open = true;
        busy = true;
        yield return null;
        while (Quaternion.Angle(chestTop.localRotation, chestTopOpenPosition) > 3)
        {
            chestTop.localRotation = Quaternion.Lerp(chestTop.localRotation, chestTopOpenPosition, Time.deltaTime * chestLerpingSpeed);
            yield return null;
        }
        while (Vector3.Distance(canvas.transform.localScale, Vector3.one) > 0.1 || canvas.transform.localPosition.y < 4.9)
        {
            canvas.transform.localScale = Vector3.Lerp(canvas.transform.localScale, Vector3.one, Time.deltaTime * canvasLerpingSpeed);
            canvas.transform.localPosition = Vector3.Lerp(canvas.transform.localPosition, canvasOpenPosition, Time.deltaTime * canvasLerpingSpeed);
            yield return null;
        }
        busy = false;
    }

    private IEnumerator CloseCanvas()
    {
        open = false;
        busy = true;
        yield return null;
        while (Vector3.Distance(canvas.transform.localScale, Vector3.zero) > 0.1 || canvas.transform.localPosition.y > 0.1)
        {
            canvas.transform.localScale = Vector3.Lerp(canvas.transform.localScale, Vector3.zero, Time.deltaTime * canvasLerpingSpeed);
            canvas.transform.localPosition = Vector3.Lerp(canvas.transform.localPosition, Vector3.zero, Time.deltaTime * canvasLerpingSpeed);
            yield return null;
        }
        while (Quaternion.Angle(chestTop.localRotation, Quaternion.identity) > 3)
        {
            chestTop.localRotation = Quaternion.Lerp(chestTop.localRotation, Quaternion.identity, Time.deltaTime * chestLerpingSpeed);
            yield return null;
        }
        busy = false;
    }
}
