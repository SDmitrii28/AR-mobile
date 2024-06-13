using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class CardInformation : MonoBehaviour
{
    public string cardName;

    public string cardInfo;

    public TextMeshProUGUI infoText;
    public float rotationAngle = 360f;
    public float rotationSpeed = 90f;

    private bool isRotating = false;

    public void OnMouseDown()
    {
        infoText.text = "Карта: " + cardName + "\n" + cardInfo;
        if (isRotating)
            return;

        StartCoroutine(RotateObject());
    }

    IEnumerator RotateObject()
    {
        isRotating = true;

        float startRotationY = transform.eulerAngles.y;
        float targetRotationY = startRotationY + rotationAngle;

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * rotationSpeed / Mathf.Abs(rotationAngle);
            float newYRotation = Mathf.Lerp(startRotationY, targetRotationY, t);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, newYRotation, transform.eulerAngles.z);
            yield return null;
        }

        isRotating = false;
    }
}
