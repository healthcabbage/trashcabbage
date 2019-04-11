using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Chapter01 : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject capsule;
    private float targetAngle = 0f;
    public float capsuleRotationSpeed = 4f;

    private GameObject sphere;
    private float ButtonDownTime;
    public float sphereMagnitudeX = 2f;
    public float sphereMagnitudeY = 2f;
    public float sphereFrequency = 1f;
    void Start()
    {
        capsule = GameObject.Find("passage");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&!EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log(string.Format("MousePosition ({0:f}, {1:f})",Input.mousePosition.x, Input.mousePosition.y));
            targetAngle = GetRotationAngleByTargetPosition(Input.mousePosition);
            //sphere = SpawnSphereAt(Input.mousePosition);
            ButtonDownTime = Time.time;
        }
        capsule.transform.eulerAngles = new Vector3(0,0,Mathf.LerpAngle(capsule.transform.eulerAngles.z,targetAngle,Time.deltaTime * capsuleRotationSpeed));
        
        if (sphere != null) {
			sphere.transform.position = new Vector3(sphere.transform.position.x + (capsule.transform.position.x - sphere.transform.position.x) * Time.deltaTime * sphereMagnitudeX,
				Mathf.Abs(Mathf.Sin ((Time.time - ButtonDownTime) * (Mathf.PI * 2) * sphereFrequency) * sphereMagnitudeY),
			    0
			);
		}
    }
    //캡슐의 위치를 월드 좌표에서 스크린 좌표로 변환. mouse 포인트가 스크린 좌표로 전달되기 때문.
    float GetRotationAngleByTargetPosition(Vector3 mousePosition)
    {
        Vector3 selfScreenPoint = Camera.main.WorldToScreenPoint(capsule.transform.position);
        
        Vector3 diff = mousePosition - selfScreenPoint;

        float angle = Mathf.Atan2(diff.y, diff.x)* Mathf.Rad2Deg;
        Debug.Log(string.Format("angle : {0:f}",angle));

        float finalAngle = angle-90;//최종적으로 구하는 각도는 Atan2로 구한 각도에서 90을 뺀 숫자기 때문
        Debug.Log(string.Format("finalAngle : {0:f}",finalAngle));

        return finalAngle;
    }

    GameObject SpawnSphereAt(Vector3 mousePosition)//클릭한 곳에 생성
    {
        GameObject sp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		Vector3 selfScreenPoint = Camera.main.WorldToScreenPoint(capsule.transform.position);
		Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, selfScreenPoint.z));
		sp.transform.position = new Vector3(position.x, position.y, 0);
		return sp;    
        }
}
