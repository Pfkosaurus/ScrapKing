using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oven : MonoBehaviour
{
	public int price = 1;
	public int upgrade = 1;
	public Text button_upgrade;
	public int max_scrap_to_make_steel_plate = 10;
	public int num;
	public float timeToInvoke = 10f;
	public float timeToWork;
	private float timer_1;
	public GameObject invoke_point_out;
	public GameObject scrap_prefab_out;
	
	
	public GameObject economicManager;
	
    // Start is called before the first frame update
    void Start()
    {
		economicManager = GameObject.FindGameObjectWithTag("EconomicManager");
		/*
        if(this.gameObject.tag == "oven")
		{
			this.gameObject.tag = "oven";
		}
		*/
    }
	
	public void Upgrade()
	{
		upgrade++;
		button_upgrade.text = "Upgrade Oven \n"+upgrade;
		economicManager.GetComponent<Economic_manager>().coins--;		
	}

    // Update is called once per frame
    void Update()
    {
        if(num >= max_scrap_to_make_steel_plate )
		{
			if(timeToWork > (timeToInvoke/upgrade))
			{
				//if(timer_1 > timeToInvoke_1)
				//{
					GameObject go = Instantiate(scrap_prefab_out, invoke_point_out.transform.position, invoke_point_out.transform.rotation);
					go.transform.localScale = new Vector3 ( 1.0f, 1.0f, 1.0f);
					go.GetComponent<Scrap>().price = price;
					go.GetComponent<SpriteRenderer>().color = new Color(0,0,0,1);
					Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
					rb.velocity = new Vector2 (0,1);
					timer_1 = 0f;
					timeToWork = 0f;
					num -= max_scrap_to_make_steel_plate;
				//} else {
				//	timer_1 += Time.deltaTime;
				//}
			} else {
				timeToWork += Time.deltaTime;
			}
		}
		else
		{
			timeToWork = 0f;
		}
    }
}
