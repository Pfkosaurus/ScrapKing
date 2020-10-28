using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_manager : MonoBehaviour
{
	
	public Camera m_camera;
	public bool m_click;
	public float speed = 10f;
	private Vector3 mouseOrigin;
	private GameObject go;
    // Start is called before the first frame update
    void Start()
    {
		go = GameObject.FindGameObjectWithTag("HUB_Manager");
        m_camera = GetComponent<Camera>();
    }
	
	public void Update()
	{
		if(!go.GetComponent<HUB_Manager>().storage_hub.active)
		{
			Display_unlock();
		}
	}
	
	public void ZoomIn()
	{
			if(m_camera.orthographicSize > 7f)
			{
				m_camera.orthographicSize -= 0.25f;
			}
			else
			{
				m_camera.orthographicSize -= 0.10f;
			}
			
	}
	public void ZoomOut()
	{
			if(m_camera.orthographicSize > 7f)
			{
				m_camera.orthographicSize += 0.25f;
			}
			else
			{
				m_camera.orthographicSize += 0.10f;
			}
	}
	
    // Update is called once per frame
    public void Display_unlock()
    {
		if (Input.GetMouseButtonDown(0))
		{
			 mouseOrigin = Input.mousePosition;
		}
		
		if (Input.GetMouseButton(0))
		{
			
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

	        //Vector3 move = new Vector3(pos.x * speed, pos.y * speed, 0);
	        //transform.Translate(move, Space.Self);
			pos.z = 0;
			transform.position += pos;
		}
		
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && m_camera.orthographicSize < 15f)
		{
			if(m_camera.orthographicSize > 7f)
			{
				m_camera.orthographicSize += 0.25f;
			}
			else
			{
				m_camera.orthographicSize += 0.10f;
			}
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0 && m_camera.orthographicSize > 3.5f)
		{
			if(m_camera.orthographicSize > 7f)
			{
				m_camera.orthographicSize -= 0.25f;
			}
			else
			{
				m_camera.orthographicSize -= 0.10f;
			}
		}
    }
}
