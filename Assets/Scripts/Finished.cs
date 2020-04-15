using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Finished : MonoBehaviour
{
    public GameObject controllers;
    public GameObject camera;
    public GameObject letters;
    public float lerpingSpeed = 1;

    public TextMeshProUGUI P;
    public TextMeshProUGUI X;
    public TextMeshProUGUI L;
    public TextMeshProUGUI F1;
    public TextMeshProUGUI F2;
    public TextMeshProUGUI F3;
    public TextMeshProUGUI F4;
    public TextMeshProUGUI FACTOR;

    private int finishedChests;
    private int chestsToFinish = 4;
    private Vector3 cameraPosition1 = new Vector3(-300, 500, 0);
    private Quaternion cameraRotation1 = Quaternion.Euler(90, 0, -180);

    private void Start()
    {
        // ChestFinished();

        StartCoroutine(FadeTextToZeroAlpha(1f, X));
        StartCoroutine(FadeTextToZeroAlpha(1f, P));
        StartCoroutine(FadeTextToZeroAlpha(1f, L));
        StartCoroutine(FadeTextToZeroAlpha(1f, F1));
        StartCoroutine(FadeTextToZeroAlpha(1f, F2));
        StartCoroutine(FadeTextToZeroAlpha(1f, F3));
        StartCoroutine(FadeTextToZeroAlpha(1f, F4));
        StartCoroutine(FadeTextToZeroAlpha(1f, FACTOR));
    }

    public void ChestFinished()
    {
        finishedChests++;
        Debug.Log("Added finished chest");
        if (finishedChests >= chestsToFinish)
        {
            // Show endscreen
            camera.transform.parent.GetComponent<TouchController>().enabled = false;
            controllers.SetActive(false);
            letters.SetActive(true);
            camera.transform.parent.localPosition = Vector3.zero;
            camera.transform.parent.localRotation = Quaternion.identity;
            camera.transform.parent.parent.localPosition = Vector3.zero;
            camera.transform.parent.parent.localRotation = Quaternion.identity;
            StartCoroutine(MoveCamera());
        }
    }

    private IEnumerator MoveCamera()
    {
        yield return null;
        while (Vector3.Distance(camera.transform.localPosition, cameraPosition1) > 1 || Quaternion.Angle(camera.transform.localRotation, cameraRotation1) > 1)
        {
            camera.transform.localPosition = Vector3.Lerp(camera.transform.localPosition, cameraPosition1, Time.deltaTime * lerpingSpeed);
            camera.transform.localRotation = Quaternion.Lerp(camera.transform.localRotation, cameraRotation1, Time.deltaTime * lerpingSpeed);
            yield return null;
        }

        StartCoroutine(FadeTextToFullAlpha(1f));
    }

    public IEnumerator FadeTextToFullAlpha(float t)
    {
        var i = X;
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }

        i = F1;
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }

        i = F2;
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }

        i = F3;
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }

        i = F4;
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }

        i = P;
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }

        i = L;
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }

        i = FACTOR;
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
