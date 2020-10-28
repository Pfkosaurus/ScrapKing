using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Belt : MonoBehaviour
{
	
	public GameObject arrow;
	public Vector2 standart_speed = new Vector2 (0,0);
	public int upgrade,level;
	private float speed;
	public Vector2 currentSpeed;
	public Text button_upgrade;
	public float speed_work = 1.0f; // default 1 
	public float KWh = 0.5f; // naklady
	public float kwh_timer;
	public float costs;
	public float costs_t;
	public int coins; //zisk
	public GameObject economicManager;
	
	public int upgrade_cost = 115;
	public float koeficient_upgrade = 3f;
	
    // Start is called before the first frame update
    void Start()
    {
		economicManager = GameObject.FindGameObjectWithTag("EconomicManager");
		costs_t = economicManager.GetComponent<Economic_manager>().electric_costs_KWh_1hod * KWh;
		if(button_upgrade != null)
		button_upgrade.text = "Belt lvl "+upgrade;	
    }
	
	public double dlb;
	public void Upgrade()
	{
		if(coins >= upgrade_cost)
		{
			KWh += (KWh*1.25f);
			dlb = System.Math.Round(KWh,2);
			KWh = (float)dlb;
			upgrade++;
			economicManager.GetComponent<Economic_manager>().coins-= upgrade_cost;
			upgrade_cost += (int)(upgrade_cost/koeficient_upgrade);
			if(button_upgrade != null)
			button_upgrade.text = "Belt lvl "+upgrade;
		}	
	}
	
    // Update is called once per frame
    void Update()
    {
		level = upgrade;
		coins = economicManager.GetComponent<Economic_manager>().coins;
		if(coins > 0) speed = 0.2f; else speed = 0f;
		if(coins >= upgrade_cost && level < 100){ arrow.SetActive(true); } else {  arrow.SetActive(false); }
		
		costs_t = economicManager.GetComponent<Economic_manager>().electric_costs_KWh_1hod * KWh;
		
		kwh_timer += Time.deltaTime/60;
			if(kwh_timer > 1.0f)
			{
				kwh_timer -= 1.0f;
				costs += costs_t;
				if(costs >= 1.0f){
					costs -= 1.0f;
					economicManager.GetComponent<Economic_manager>().coins--;
				}
			} 
			
        currentSpeed.x = 0.5f+standart_speed.x * upgrade * speed;
    }
}
