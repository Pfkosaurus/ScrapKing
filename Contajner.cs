using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contajner : MonoBehaviour
{
	public int price = 5;
	public string factory;
	public GameObject bokL;
	public GameObject bokR;
	
	public GameObject wheel_1;
	public GameObject wheel_2;
	public GameObject wheel_3;
	public GameObject wheel_4;
	public GameObject wheel_5;
	public GameObject wheel_6;
	
	public Text button_upgrade;
	public int upgrade = 1;
	
	public int num; 
	private float timeToWork;
    private float timer;
	public float timeToInvoke = 3f;
	
	public GameObject invoke_point_in;
	//public GameObject invoke_point_in_2;
	public GameObject scrap_prefab_in;
	
	private float timer_1;
	public float timeToInvoke_1;
	public GameObject invoke_point_out;
	public GameObject[] scrap_prefab_out;
	
	public int num_srot;
	public int max_scrap = 10;
	public float invoke_1 = 0.5f;
	public float invoke_2 = 5.0f;
	
	public float speed_work = 1.0f; // default 1 
	public float KWh = 1000; // naklady
	public float kwh_timer;
	public float costs;
	public float costs_t;
	public int coins; //zisk
	public float sec_float;
	public int sec;
	public GameObject economicManager;
	public GameObject warehouse;
	public bool m_buy;
	public float size_scrap;
	float speed;
	
	float t;
	Vector3 pos_bok;
	Vector3 last_posL;
	Vector3 last_posR;
	
    // Start is called before the first frame update
    void Start()
    {
		
		//button_upgrade.text = "Upgrade Input \n"+"1";	
		
		economicManager = GameObject.FindGameObjectWithTag("EconomicManager");
		warehouse = GameObject.FindGameObjectWithTag("Warehouse");
        
		last_posL = bokL.transform.position;
		last_posR = bokR.transform.position;
    }
	
	public void Update()
	{
		if(warehouse.GetComponent<Warehouse>().metal_recycle){m_buy = true;}else{ m_buy = false;}

		if(speed < 0.0f)
		{
			speed = 0f;
		}
		else if(speed >= 2.5f)
		{
			speed = 2.5f;
		}
		wheel_1.transform.Rotate(0f, 0f, -speed);
		wheel_2.transform.Rotate(0f, 0f, speed);
		wheel_3.transform.Rotate(0f, 0f, -speed*2);
		wheel_4.transform.Rotate(0f, 0f, speed*2);
		wheel_5.transform.Rotate(0f, 0f, speed*3);
		wheel_6.transform.Rotate(0f, 0f, -speed*3);
		
		// out scrap
		speed += 0.1f;
	}
	
	public void Upgrade_input()
	{
		upgrade++;
		speed_work = upgrade;
		button_upgrade.text = "Upgrade Input \n"+upgrade;	
		economicManager.GetComponent<Economic_manager>().coins--;
	}
	
	private int x;
    // Update is called once per frame
    public void FixedUpdate()
    {
		
		coins = economicManager.GetComponent<Economic_manager>().coins;
		costs_t = economicManager.GetComponent<Economic_manager>().electric_costs_KWh_1hod * KWh;
		
		if(num > 0 && economicManager.GetComponent<Economic_manager>().coins > 0 )
		{
		
			if(kwh_timer > 1.0f)
			{
				kwh_timer -= 1.0f;
				costs += costs_t/60/60;
				if(costs >= 1.0f){
					costs -= 1.0f;
					economicManager.GetComponent<Economic_manager>().coins--;
				}
			} 
			
			if(timeToWork > 1.25f )
			{
				if(timer_1 > timeToInvoke_1)
				{
					for(int y = 0; y <= 0; y++ )
					{
						//Debug.Log("pocet"+y);
						int color_1 = Random.Range(0,255);
						int color_2 = Random.Range(0,255);	
						int color_3 = Random.Range(0,255);
						float pos_x = Random.Range(-0.2f,0.2f);	
						x = scrap_prefab_out.Length;
						Vector3 m_pos = invoke_point_out.transform.position;
						m_pos.x += pos_x;
						int x_1 = Random.Range(0,x);
						GameObject go = Instantiate(scrap_prefab_out[x_1], m_pos, invoke_point_out.transform.rotation);
					
						go.transform.localScale = new Vector3 ( size_scrap, size_scrap, size_scrap);
						go.GetComponent<SpriteRenderer>().color = new Color(color_1,color_2,color_3,1);
						go.GetComponent<Scrap>().factory = factory;
						go.GetComponent<Scrap>().m_garbage = false;
						go.GetComponent<Scrap>().price = price;
						string scrap_name = "";
						if(x_1 == 0){ scrap_name = "wood";}
						if(x_1 == 1){ scrap_name = "metal";}
						if(x_1 == 2){ scrap_name = "paper";}
						if(x_1 == 3){ scrap_name = "paper";}
						if(x_1 == 4){ scrap_name = "plastic";}
						if(x_1 == 5){ scrap_name = "gum";}
						if(x_1 == 6){ scrap_name = "glass";}
						if(x_1 == 7){ scrap_name = "bio";}
						if(x_1 >= 8){ scrap_name = "metal";}
						//Debug.Log(scrap_name);
						go.GetComponent<Scrap>().scrap_name = scrap_name;
						Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
						rb.velocity = new Vector2 ( 0f , 0f );
					
						timer_1 = 0f;
						num_srot++;
					}
					if(num_srot > (max_scrap+upgrade))
					{
						num_srot = 0;
						num--;
					}
				} else {
					timer_1 += Time.deltaTime;
				}
			} else {
				timeToWork += Time.deltaTime;
			}
		}
		else
		{
			//speed -= 0.1f;
			timeToWork = 0f;
		}
		
		// input scrap
		if(m_buy){
		if(timer > timeToInvoke){
			/* if you have money */
			if(warehouse.GetComponent<Warehouse>().m_metal > 0){
				Instantiate(scrap_prefab_in, invoke_point_in.transform.position, invoke_point_in.transform.rotation);
				timer = 0f;
				//timeToInvoke = Random.Range(0.0f,invoke_2/speed_work);
				timeToInvoke = invoke_2/speed_work;
				warehouse.GetComponent<Warehouse>().m_metal--;
			}
		} else {
			timer += Time.deltaTime;
		}
		}
    }
}