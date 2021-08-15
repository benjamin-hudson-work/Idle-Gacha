using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GachaManager : MonoBehaviour
{
    public static GachaManager instance;
    private void Awake() => instance = this;
    Methods methods;
    public GameObject Capsule;
    public GameObject CapsuleBottom;
    public GameObject CapsuleTop;
    public GameObject CapsuleContents;
    public GameObject Pedistal;
    public GameObject Shadow;
    public Transform[] Point;
    public GameObject Menu;
    public void GachaAnimation() 
    {
        CapsuleBottom.transform.position = Capsule.transform.position;
        CapsuleTop.transform.position = Capsule.transform.position;
        CapsuleContents.transform.position = Capsule.transform.position;
        StartCoroutine(waitForGachaAnimation1());
    } 
    public void ResetObjectPositions()
    {
        Capsule.GetComponent<Transform>().position = Point[0].position;
        CapsuleBottom.transform.position = Capsule.transform.position;
        CapsuleTop.transform.position = Capsule.transform.position;
        CapsuleContents.transform.position = Capsule.transform.position;
    }
    IEnumerator waitForGachaAnimation1() 
    {
        Menu.SetActive(false);
        Shadow.SetActive(true);
        Capsule.GetComponent<Transform>().SetSiblingIndex(0);
        Pedistal.GetComponent<ObjectMover>().AssignMarkers(Point[3], Point[2], .3f, 0, "Decelerates");
        Capsule.GetComponent<ObjectMover>().AssignMarkers(Point[0], Point[1], 2, 2f, "Decelerates");
        yield return new WaitWhile(() => (Capsule.GetComponent<ObjectMover>().IsMoving));
        StartCoroutine(waitForGachaAnimation2());
    }
    IEnumerator waitForGachaAnimation2() 
    {
        Capsule.GetComponent<Transform>().SetSiblingIndex(1);
        Capsule.GetComponent<ObjectMover>().AssignMarkers(Point[1], Point[2], 2, -1.5f, "Accelerates");
        yield return new WaitWhile(() => (Capsule.GetComponent<ObjectMover>().IsMoving));
        StartCoroutine(waitForGachaAnimation3());
    }
    IEnumerator waitForGachaAnimation3() 
    {
        Shadow.SetActive(false);
        Capsule.GetComponent<Transform>().SetSiblingIndex(2);
        Capsule.GetComponent<ObjectMover>().Spin = 0f;
        Capsule.GetComponent<Transform>().eulerAngles = new Vector3(0f, 0f, 0f);
        CapsuleBottom.GetComponent<ObjectMover>().AssignMarkers(Point[2], Point[3], 2, 0, "Normal");
        CapsuleTop.GetComponent<ObjectMover>().AssignMarkers(Point[2], Point[4], 2, 0, "Normal");
        Pedistal.GetComponent<ObjectMover>().AssignMarkers(Point[2], Point[3], 2, 0, "Normal");
        yield return new WaitWhile(() => (CapsuleBottom.GetComponent<ObjectMover>().IsMoving && CapsuleTop.GetComponent<ObjectMover>().IsMoving));
        Menu.SetActive(true);
    }
}
