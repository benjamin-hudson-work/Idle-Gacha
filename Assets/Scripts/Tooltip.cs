using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 public class Tooltip : MonoBehaviour
 {
     public static Tooltip instance;
     private void Awake() => instance = this;
     public bool IsActive = true;
 
     Camera cam;
     Vector3 min, max;
     RectTransform rect;
     float offset = 10f;
     public TMP_Text MainText;
     public TMP_Text FlavorText;
 
     // Start is called before the first frame update
     void Start()
     {
         cam = Camera.main;
         rect = GetComponent<RectTransform>();
         min = new Vector3(0, 0, 0);
         max = new Vector3(cam.pixelWidth, cam.pixelHeight, 0);
     }
 
     // Update is called once per frame
     void Update()
     {
         if (IsActive)
         {
             //get the tooltip position with offset
             Vector3 position = new Vector3(Input.mousePosition.x + rect.rect.width, Input.mousePosition.y - (rect.rect.height / 2 + offset), 0f);
             //clamp it to the screen size so it doesn't go outside
             transform.position = new Vector3(Mathf.Clamp(position.x, min.x + rect.rect.width/2, max.x - rect.rect.width/2), Mathf.Clamp(position.y, min.y + rect.rect.height / 2, max.y - rect.rect.height / 2), transform.position.z);
         }
             
     }
     void TurnOn(string m, string f)
     {
         IsActive = true;
         MainText.text = m;
         FlavorText.text = f;
     }
     void TurnOff() => IsActive = false;
 }