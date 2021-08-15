using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;
    float lerpTime = 1f;
    float currentLerpTime;
    public bool IsMoving;
    public float Spin;
    public string Type;
    // Move to the target end position.
    void Update()
    {
        if (IsMoving){
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) {
            currentLerpTime = lerpTime;
            IsMoving = false;
        }
 
        //lerp!
        float perc = currentLerpTime / lerpTime;
        switch (Type)
        {
            case "Normal":
                break;
            case "Decelerates":
                perc = Mathf.Sin(perc * Mathf.PI * 0.5f);
                break;
            case "Accelerates":
                perc = 1f - Mathf.Cos(perc * Mathf.PI * 0.5f);
                break;
        }
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, perc);}
        if (Spin != 0) transform.Rotate(new Vector3(0f,0f,Spin), Space.Self);
    }
    public void AssignMarkers(Transform start, Transform end, float speed, float spin, string type)
    {
        startMarker = start;
        endMarker = end;
        currentLerpTime = 0f;
        lerpTime = speed;
        Spin = spin;
        Type = type;
        IsMoving = true;
    }
}