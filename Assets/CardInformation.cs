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

        Quaternion startRotation = transform.rotation; 
        Quaternion endRotation = Quaternion.Euler(transform.eulerAngles + Vector3.up * rotationAngle); 

        float t = 0f; 

        while (t < 1f)
        {
            t += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }

        isRotating = false; 
    }
}
