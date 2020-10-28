using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Garbage_room : MonoBehaviour
{
	//public GameObject in_1;
	private float t;
	
	public string factory;
	public string scrap_name;
	public float size_scrap;
	public int num;
	public GameObject economicManager;
	public GameObject warehouse;
	public GameObject arrow;
	public Text level_txt;

	public bool m_buy;
	public int level;
	public int upgrade_cost = 115;
	public float koeficient_upgrade = 3f;
    private float timer;
	public float timeToInvoke = 3f;
	public GameObject invoke_point_in;
	
	public GameObject[] scrap_prefab_in;
	public float invoke_2 = 5.0f;
	public float speed_work = 1.0f; // default 1 
	public float KWh = 2.5f; // naklady
	public float kwh_timer;
	public float costs;
	public float costs_t;
    // Start is called before the first frame update
    void Start()
    {
		economicManager = GameObject.FindGameObjectWithTag("EconomicManager");
		warehouse = GameObject.FindGameObjectWithTag("Warehouse");
        level_txt.text = "Garbage"+"\n"+"lvl "+level.ToString();
    }
	
	private bool m_created;
	
	
	public double dlb;
	public void UpgradeRoom()
	{
		if(economicManager.GetComponent<Economic_manager>().coins >= upgrade_cost && m_buy)
		{
			timeToInvoke = invoke_2/speed_work;
			KWh += (KWh*1.25f);
			dlb = System.Math.Round(KWh,2);
			KWh = (float)dlb;
			economicManager.GetComponent<Economic_manager>().coins -= upgrade_cost;
			level++;
			upgrade_cost += (int)(upgrade_cost/koeficient_upgrade);
			level_txt.text = "Garbage"+"\n"+"lvl "+level.ToString();
			speed_work = level;
		}
		else
		{
			if(economicManager.GetComponent<Economic_manager>().coins >= 100)
			{
				economicManager.GetComponent<Economic_manager>().coins -= 100;
				level++;
				level_txt.text = "Garbage"+"\n"+"lvl "+level.ToString();
				m_buy = true;
			}
		}
	}
	
    // Update is called once per frame
    public void Update()
    {
		int coins = economicManager.GetComponent<Economic_manager>().coins;
		if((coins >= upgrade_cost && level < 100) || (coins >= 100 && level < 1) ){ arrow.SetActive(true); } else {  arrow.SetActive(false); }
		Separator();
    }
	
	public void Separator()
	{
		
		if(warehouse.GetComponent<Warehouse>().m_garbage > 2 && warehouse.GetComponent<Warehouse>().garbage_recycle)
		{
			if(level > 0)
			{
				m_buy = true;
			}
		}
		else
		{
			m_buy = false;
		}
		
		costs_t = economicManager.GetComponent<Economic_manager>().electric_costs_KWh_1hod * KWh;
		
		if(m_buy && economicManager.GetComponent<Economic_manager>().coins > 0)
		{
			
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

			if(timer > timeToInvoke)
			{
				int color_1 = Random.Range(0,255);
				int color_2 = Random.Range(0,255);	
				int color_3 = Random.Range(0,255);
				int x = scrap_prefab_in.Length;
				GameObject go = Instantiate(scrap_prefab_in[Random.Range(0,x)], invoke_point_in.transform.position, invoke_point_in.transform.rotation);
				go.transform.position -= new Vector3 ( 0.0f, 0.0f, -0.5f);
				go.transform.localScale = new Vector3 ( size_scrap, size_scrap, size_scrap);
				go.GetComponent<Rigidbody2D>().velocity = new Vector2 ( 2.5f , 0f );
				go.GetComponent<SpriteRenderer>().color = new Color(color_1,color_2,color_3,1);
				go.GetComponent<Scrap>().m_garbage = true;
				go.GetComponent<Scrap>().factory = factory;
				go.GetComponent<Scrap>().scrap_name = scrap_name;
				timer = 0f;
				//timeToInvoke = Random.Range(0.0f,invoke_2/speed_work);
				timeToInvoke = invoke_2/speed_work;
				num++;
				warehouse.GetComponent<Warehouse>().m_garbage -= 3;
				m_created = true;
			} else {
				timer += Time.deltaTime;
			}
		}
	}
	
	
}