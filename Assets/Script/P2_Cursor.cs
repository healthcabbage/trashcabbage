using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class P2_Cursor : MonoBehaviour
{
    private GameObject Cursor;

    private float targetAngle = 0f;
   // private float cursorRotationSpeed = 4f;

    private GameObject sphere;
    private float buttonDownTime;

    public float sphereMagnitudeX = 2.0f;
    public float sphereMagnitudeY = 3.0f;
    public float sphereFrequency = 1.0f;

    void Start()
    {
        Cursor = GameObject.Find("Cursor");
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) &&
            !EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log(string.Format("mousePosition ({0:f},{1:f})",
                Input.mousePosition.x, Input.mousePosition.y));

            targetAngle = GetRotationAngleByTargetPosition(Input.mousePosition);

            float GetRotationAngleByTargetPosition(Vector3 mousePosition)
            {
                Vector3 selfScreenPoint =
                    Camera.main.WorldToScreenPoint(Cursor.transform.position);

                Vector3 diff = mousePosition - selfScreenPoint;

                float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                Debug.Log(string.Format("angle: {0:f}", angle));

                float finalAngle = angle - 90f;
                Debug.Log(string.Format("finalAngle:{0:f}", finalAngle));
                return finalAngle;
            }
            Cursor.transform.eulerAngles = new Vector3(0, 0,
                Mathf.LerpAngle(Cursor.transform.eulerAngles.z, targetAngle,
               1)); // Time.deltaTime * cursorRotationSpeed
        }
      
    }
}
