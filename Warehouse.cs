using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warehouse : MonoBehaviour
{
	public GameObject garbage_rooms, paper_rooms,bio_rooms,metal_rooms,glass_rooms,plastic_rooms,build_mat_rooms,electric_rooms,woods_rooms,tires_rooms,vehicles_rooms,oil_rooms,chemicals_rooms;
	//public Button warehouseLevel_BTN;
	public GameObject arrow_warehouseLevel_BTN;
	
	public GameObject arrow_CarLevel_BTN;
	
	/* is open window */
	public Button warehouseUpgradeBTN;
	public Button carsUpgradeBTN;
	
	public Button garbage_BTN_1t,garbage_BTN_10t,garbage_BTN_50t,garbage_BTN_max,garbage_BTN_separate;
	public Button paper_BTN_1t,paper_BTN_10t,paper_BTN_50t,paper_BTN_max,paper_BTN_separate;
	public Button bio_BTN_1t,bio_BTN_10t,bio_BTN_50t,bio_BTN_max,bio_BTN_separate;
	public Button metal_BTN_1t,metal_BTN_10t,metal_BTN_50t,metal_BTN_max,metal_BTN_separate;
	public Button glass_BTN_1t,glass_BTN_10t,glass_BTN_50t,glass_BTN_max,glass_BTN_separate;
	public Button plastic_BTN_1t,plastic_BTN_10t,plastic_BTN_50t,plastic_BTN_max,plastic_BTN_separate;
	public Button build_mat_BTN_1t,build_mat_BTN_10t,build_mat_BTN_50t,build_mat_BTN_max,build_mat_BTN_separate;
	public Button electric_BTN_1t,electric_BTN_10t,electric_BTN_50t,electric_BTN_max,electric_BTN_separate;
	public Button woods_BTN_1t,woods_BTN_10t,woods_BTN_50t,woods_BTN_max,woods_BTN_separate;
	public Button tires_BTN_1t,tires_BTN_10t,tires_BTN_50t,tires_BTN_max,tires_BTN_separate;
	public Button vehicles_BTN_1t,vehicles_BTN_10t,vehicles_BTN_50t,vehicles_BTN_max,vehicles_BTN_separate;
	public Button oil_BTN_1t,oil_BTN_10t,oil_BTN_50t,oil_BTN_max,oil_BTN_separate;
	public Button chemicals_BTN_1t,chemicals_BTN_10t,chemicals_BTN_50t,chemicals_BTN_max,chemicals_BTN_separate;
	
	private GameObject economicManager; 
	private int coins;
	
	/* uroven skladu */
	public Text cost_upgrade_warehouse;
	public Text warehouse_level;
	public Text warehouse_levelup;
	public Text warehouse_level_btn;
	public int level;
	public int warehouse_cost = 502;
	/* uroven auta */
	public int cars_level;
	public Text cost_upgrade_cars;
	public Text cars_level_text;
	public Text cars_levelup;
	public Text cars_levelup_2;
	public int cars_cost = 350;
	public int cars_tons;
	/* celkova a aktualna kapacita skladu */
	public Text total_storage;
	public int max_storage = 50;
	public int current_storage;
	
	/* povolenie na prijem*/
	public bool garbage,paper,metal,bio,glass,plastic,build_mat,electric,woods,tires,vehicles,oil,chemicals;
	
	/* pocet na sklade */
	public int m_garbage,m_paper,m_metal,m_bio,m_glass,m_plastic,m_build_mat,m_electric,m_woods,m_tires,m_vehicles,m_oil,m_chemicals;
	public int crush_metal;
	
	public int disposal_cost_garbage_1T = 25;
	public int disposal_cost_garbage_10T = 200;
	public int disposal_cost_garbage_50T = 850;
	
	public int disposal_cost_paper_1T = 21;
	public int disposal_cost_paper_10T = 166;
	public int disposal_cost_paper_50T = 918;
	
	public int disposal_cost_bio_1T = 25;
	public int disposal_cost_bio_10T = 213;
	public int disposal_cost_bio_50T = 986;
	
	public int disposal_cost_metal_1T = 25;
	public int disposal_cost_metal_10T = 213;
	public int disposal_cost_metal_50T = 986;
	
	public int disposal_cost_glass_1T = 25;
	public int disposal_cost_glass_10T = 213;
	public int disposal_cost_glass_50T = 986;
	
	public int disposal_cost_plastic_1T = 25;
	public int disposal_cost_plastic_10T = 213;
	public int disposal_cost_plastic_50T = 986;
	
	public int disposal_cost_build_mat_1T = 25;
	public int disposal_cost_build_mat_10T = 213;
	public int disposal_cost_build_mat_50T = 986;
	
	public int disposal_cost_electric_1T = 25;
	public int disposal_cost_electric_10T = 213;
	public int disposal_cost_electric_50T = 986;
	
	public int disposal_cost_woods_1T = 25;
	public int disposal_cost_woods_10T = 213;
	public int disposal_cost_woods_50T = 986;
	
	public int disposal_cost_tires_1T = 25;
	public int disposal_cost_tires_10T = 213;
	public int disposal_cost_tires_50T = 986;
	
	public int disposal_cost_vehicles_1T = 25;
	public int disposal_cost_vehicles_10T = 213;
	public int disposal_cost_vehicles_50T = 986;
	
	public int disposal_cost_oil_1T = 25;
	public int disposal_cost_oil_10T = 213;
	public int disposal_cost_oil_50T = 986;
	
	public int disposal_cost_chemicals_1T = 25;
	public int disposal_cost_chemicals_10T = 213;
	public int disposal_cost_chemicals_50T = 986;
	
	public bool garbage_recycle,paper_recycle,bio_recycle,metal_recycle,glass_recycle,plastic_recycle,build_mat_recycle,electric_recycle,woods_recycle,tires_recycle,vehicles_recycle,oil_recycle,chemicals_recycle;
	
	private GameObject garbage_go,paper_go,bio_go,metal_go,glass_go,plastic_go,build_mat_go,electric_go,woods_go,tires_go,vehicles_go,oil_go,chemicals_go;
	
	public GameObject truck;
    // Start is called before the first frame update
    void Start()
    {
		
		garbage_BTN_1t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("garbage_1t"); });
		garbage_BTN_10t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("garbage_10t"); });
		garbage_BTN_50t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("garbage_50t"); });
		garbage_BTN_max.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("garbage_max"); });
		garbage_BTN_separate.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("garbage_separate"); });
		
		paper_BTN_1t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("paper_1t"); });
		paper_BTN_10t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("paper_10t"); });
		paper_BTN_50t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("paper_50t"); });
		paper_BTN_max.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("paper_max"); });
		paper_BTN_separate.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("paper_separate"); });
		
		bio_BTN_1t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("bio_1t"); });
		bio_BTN_10t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("bio_10t"); });
		bio_BTN_50t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("bio_50t"); });
		bio_BTN_max.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("bio_max"); });
		bio_BTN_separate.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("bio_separate"); });
		
		metal_BTN_1t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("metal_1t"); });
		metal_BTN_10t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("metal_10t"); });
		metal_BTN_50t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("metal_50t"); });
		metal_BTN_max.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("metal_max"); });
		metal_BTN_separate.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("metal_separate"); });
		
		glass_BTN_1t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("glass_1t"); });
		glass_BTN_10t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("glass_10t"); });
		glass_BTN_50t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("glass_50t"); });
		glass_BTN_max.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("glass_max"); });
		glass_BTN_separate.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("glass_separate"); });
		
		plastic_BTN_1t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("plastic_1t"); });
		plastic_BTN_10t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("plastic_10t"); });
		plastic_BTN_50t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("plastic_50t"); });
		plastic_BTN_max.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("plastic_max"); });
		plastic_BTN_separate.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("plastic_separate"); });
		
		build_mat_BTN_1t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("build_mat_1t"); });
		build_mat_BTN_10t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("build_mat_10t"); });
		build_mat_BTN_50t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("build_mat_50t"); });
		build_mat_BTN_max.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("build_mat_max"); });
		build_mat_BTN_separate.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("build_mat_separate"); });
		
		electric_BTN_1t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("electric_1t"); });
		electric_BTN_10t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("electric_10t"); });
		electric_BTN_50t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("electric_50t"); });
		electric_BTN_max.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("electric_max"); });
		electric_BTN_separate.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("electric_separate"); });
		
		woods_BTN_1t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("woods_1t"); });
		woods_BTN_10t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("woods_10t"); });
		woods_BTN_50t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("woods_50t"); });
		woods_BTN_max.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("woods_max"); });
		woods_BTN_separate.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("woods_separate"); });
		
		tires_BTN_1t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("tires_1t"); });
		tires_BTN_10t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("tires_10t"); });
		tires_BTN_50t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("tires_50t"); });
		tires_BTN_max.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("tires_max"); });
		tires_BTN_separate.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("tires_separate"); });
		
		vehicles_BTN_1t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("vehicles_1t"); });
		vehicles_BTN_10t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("vehicles_10t"); });
		vehicles_BTN_50t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("vehicles_50t"); });
		vehicles_BTN_max.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("vehicles_max"); });
		vehicles_BTN_separate.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("vehicles_separate"); });
		
		oil_BTN_1t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("oil_1t"); });
		oil_BTN_10t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("oil_10t"); });
		oil_BTN_50t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("oil_50t"); });
		oil_BTN_max.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("oil_max"); });
		oil_BTN_separate.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("oil_separate"); });
		
		chemicals_BTN_1t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("chemicals_1t"); });
		chemicals_BTN_10t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("chemicals_10t"); });
		chemicals_BTN_50t.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("chemicals_50t"); });
		chemicals_BTN_max.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("chemicals_max"); });
		chemicals_BTN_separate.GetComponent<Button>().onClick.AddListener(delegate {Storage_disposal("chemicals_separate"); });
	
		if(level < 1)
		{
			truck.SetActive(false);
		}
		economicManager = GameObject.FindGameObjectWithTag("EconomicManager");
        garbage = true;
		
		/* buttons as gameObject */
		garbage_go = garbage_BTN_separate.transform.gameObject;
		paper_go = paper_BTN_separate.transform.gameObject;
		bio_go = bio_BTN_separate.transform.gameObject;
		metal_go = metal_BTN_separate.transform.gameObject;
		glass_go = glass_BTN_separate.transform.gameObject;
		plastic_go = plastic_BTN_separate.transform.gameObject;
		build_mat_go = build_mat_BTN_separate.transform.gameObject;
		electric_go = electric_BTN_separate.transform.gameObject;
		woods_go = woods_BTN_separate.transform.gameObject;
		tires_go = tires_BTN_separate.transform.gameObject;
		vehicles_go = vehicles_BTN_separate.transform.gameObject;
		oil_go = oil_BTN_separate.transform.gameObject;
		chemicals_go = chemicals_BTN_separate.transform.gameObject;
		
		/* zvysenie kapacity upgrade*/
		int max_storages = max_storage/2;
		warehouse_levelup.text = "+"+max_storages.ToString() + "t";
		
		cost_upgrade_warehouse.text = "+"+ warehouse_cost.ToString(); // cena za upgrade
		cost_upgrade_cars.text = "+"+cars_cost.ToString();
		
		
		//int m_cars_cost = cars_cost;
		//cars_cost = m_cars_cost +=(m_cars_cost/2);
		double g = 351+(351/2)*cars_level;
		double j = 351+((351/2)*(cars_level+1));
		double h = g/100; // current
		h = h*2;
		double k = j-g;
		double l = k/100;       // to upgrade;
		l = l*2;
		int gd;
		if(cars_level < 1)
		{
			cars_level = 1;
		}
		cars_levelup_2.text = "level "+cars_level.ToString() + " / " + h.ToString() + "t";
		cars_levelup.text = "+"+l.ToString() + "t";
		
	}
	
	public void UpgradeWarehouse()
	{
		
			economicManager.GetComponent<Economic_manager>().coins -= warehouse_cost;
			level++;
			max_storage += max_storage/2;
			warehouse_cost +=(warehouse_cost/2);
			cost_upgrade_warehouse.text = "+"+warehouse_cost.ToString();
			int max_storages = max_storage/2;
			warehouse_levelup.text = "+"+max_storages.ToString() + "t";		
			warehouse_level.text = "level "+level.ToString() + " / " + max_storage.ToString()+"t";
	}
	public void UpgradeCars()
	{
		economicManager.GetComponent<Economic_manager>().coins -= cars_cost;
		cars_level++;
		
		int m_cars_cost = cars_cost;
		cars_cost = m_cars_cost +=(m_cars_cost/2);
		cost_upgrade_cars.text = "+"+cars_cost.ToString();
		double g = 351+(351/2)*cars_level;
		double j = 351+((351/2)*(cars_level+1));
		double h = g/100; // current
		h = h*2;
		double k = j-g;
		double l = k/100;       // to upgrade;
		l = l*2;
		cars_levelup_2.text = "level "+cars_level.ToString() + " / " + h.ToString() + "t";
		cars_levelup.text = "+"+l.ToString() + "t";
		
	}
	
	private float nums;
	private float helper;
	private int helper_1;
	private int disposal_cost_50T,disposal_cost_10T,disposal_cost_1T;
	private int pocet;
	private string stor_dis;
	private string txt;
	private int coin_current;
	private int coin_current_2;
	private int scrap_current;
	private int i;
	private float d;
		
	public void Storage_disposal(string txt)
	{
		
		coins = economicManager.GetComponent<Economic_manager>().coins;
		/* garbage */
		if(txt == "garbage_1t"){ m_garbage -= 100; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_garbage_1T; }
		if(txt == "garbage_10t"){ m_garbage -= 1000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_garbage_10T; }
		if(txt == "garbage_50t"){ m_garbage -= 5000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_garbage_50T; }
		if(txt == "garbage_separate" && level > 1) { if(garbage_recycle){garbage_recycle = false;}else{garbage_recycle = true; } }
		
		/* paper */
		if(txt == "paper_1t"){ m_paper -= 100; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_paper_1T; }
		if(txt == "paper_10t"){ m_paper -= 1000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_paper_10T; }
		if(txt == "paper_50t"){ m_paper -= 5000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_paper_50T; }
		if(txt == "paper_separate") {if(paper_recycle){paper_recycle = false;}else{paper_recycle = true; } }
		/* bio */
		if(txt == "bio_1t"){ m_bio -= 100; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_bio_1T; }
		if(txt == "bio_10t"){ m_bio -= 1000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_bio_10T; }
		if(txt == "bio_50t"){ m_bio -= 5000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_bio_50T; }
		if(txt == "bio_separate") {if(bio_recycle){bio_recycle = false;}else{bio_recycle = true;} }
		
		/* metal */
		if(txt == "metal_1t"){ m_metal -= 100; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_metal_1T; }
		if(txt == "metal_10t"){ m_metal -= 1000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_metal_10T; }
		if(txt == "metal_50t"){ m_metal -= 5000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_metal_50T; }
		if(txt == "metal_separate") {if(metal_recycle) {metal_recycle = false; }else {metal_recycle = true; }}
		
		/* glass */
		if(txt == "glass_1t"){ m_glass -= 100; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_glass_1T; }
		if(txt == "glass_10t"){ m_glass -= 1000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_glass_10T; }
		if(txt == "glass_50t"){ m_glass -= 5000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_glass_50T; }
		if(txt == "glass_separate") {if(glass_recycle){glass_recycle = false;}else{glass_recycle = true;}}
		
		/* plastic */
		if(txt == "plastic_1t"){ m_plastic -= 100; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_plastic_1T; }
		if(txt == "plastic_10t"){ m_plastic -= 1000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_plastic_10T; }
		if(txt == "plastic_50t"){ m_plastic -= 5000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_plastic_50T; }
		if(txt == "plastic_separate") {if(plastic_recycle){plastic_recycle = false;}else{plastic_recycle = true;}}
		
		/* build_mat */
		if(txt == "build_mat_1t"){ m_build_mat -= 100; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_build_mat_1T; }
		if(txt == "build_mat_10t"){ m_build_mat -= 1000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_build_mat_10T; }
		if(txt == "build_mat_50t"){ m_build_mat -= 5000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_build_mat_50T; }
		if(txt == "build_mat_separate") {if(build_mat_recycle){build_mat_recycle = false;}else{build_mat_recycle = true;}}
		
		/* electric */
		if(txt == "electric_1t"){ m_electric -= 100; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_electric_1T; }
		if(txt == "electric_10t"){ m_electric -= 1000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_electric_10T; }
		if(txt == "electric_50t"){ m_electric -= 5000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_electric_50T; }
		if(txt == "electric_separate")
		{ 
			if(electric_recycle) { electric_recycle = false; } else { electric_recycle = true; }
			
			int percentage = 0;
			percentage = Random.Range(0,1); // papier
			percentage = m_electric/100*percentage;
			m_paper += percentage;
			m_electric -= percentage;
			
			helper_1 = m_electric;
			percentage = Random.Range(25,50); // plastic
			percentage = helper_1/100*percentage;
			if(m_electric > percentage) { m_plastic += percentage; m_electric -= percentage; } else { m_plastic = m_electric; m_electric = 0; }
			
			helper_1 = m_woods;
			percentage = Random.Range(0,10); // woods
			percentage = helper_1/100*percentage;
			if(m_woods > percentage) { m_woods += percentage; m_electric -= percentage; } else { m_woods = m_electric; m_electric = 0; }
			
			percentage = Random.Range(25,50); // metal
			percentage = helper_1/100*percentage;
			if(m_electric > percentage) { m_metal += percentage; m_electric -= percentage; } else { m_metal = m_electric; m_electric = 0; }
			
			percentage = Random.Range(0,25); // glass
			percentage = helper_1/100*percentage;
			if(m_electric > percentage) { m_glass += percentage; m_electric -= percentage; } else { m_glass = m_electric; m_electric = 0; }
			
			percentage = Random.Range(0,5); // build_materials
			percentage = helper_1/100*percentage;
			if(m_electric > percentage) { m_build_mat += percentage; m_electric -= percentage; } else { m_build_mat = m_electric; m_electric = 0; }
			
			m_plastic += m_electric;
			m_electric = 0;
		}
		
		if(txt == "garbage_max" || txt == "paper_max" || txt == "bio_max" || txt == "metal_max" || txt == "glass_max" || txt == "plastic_max" || txt == "build_mat_max" || txt == "electric_max")
		{
			if(txt == "garbage_max")
			{
				pocet = m_garbage;
				disposal_cost_50T = disposal_cost_garbage_50T;
				disposal_cost_10T = disposal_cost_garbage_10T;
				disposal_cost_1T = disposal_cost_garbage_1T;
			}
			if(txt == "paper_max")
			{
				pocet = m_paper;
				disposal_cost_50T = disposal_cost_paper_50T;
				disposal_cost_10T = disposal_cost_paper_10T;
				disposal_cost_1T = disposal_cost_paper_1T;
			}
			if(txt == "bio_max")
			{
				pocet = m_bio;
				disposal_cost_50T = disposal_cost_bio_50T;
				disposal_cost_10T = disposal_cost_bio_10T;
				disposal_cost_1T = disposal_cost_bio_1T;
			}
			if(txt == "metal_max")
			{
				pocet = m_metal;
				disposal_cost_50T = disposal_cost_metal_50T;
				disposal_cost_10T = disposal_cost_metal_10T;
				disposal_cost_1T = disposal_cost_metal_1T;
			}
			if(txt == "glass_max")
			{
				pocet = m_glass;
				disposal_cost_50T = disposal_cost_glass_50T;
				disposal_cost_10T = disposal_cost_glass_10T;
				disposal_cost_1T = disposal_cost_glass_1T;
			}
			if(txt == "plastic_max")
			{
				pocet = m_plastic;
				disposal_cost_50T = disposal_cost_plastic_50T;
				disposal_cost_10T = disposal_cost_plastic_10T;
				disposal_cost_1T = disposal_cost_plastic_1T;
			}	
			if(txt == "build_mat_max")
			{
				pocet = m_build_mat;
				disposal_cost_50T = disposal_cost_build_mat_50T;
				disposal_cost_10T = disposal_cost_build_mat_10T;
				disposal_cost_1T = disposal_cost_build_mat_1T;
			}	
			if(txt == "electric_max")
			{
				pocet = m_build_mat;
				disposal_cost_50T = disposal_cost_build_mat_50T;
				disposal_cost_10T = disposal_cost_build_mat_10T;
				disposal_cost_1T = disposal_cost_build_mat_1T;
			}
			if(txt == "woods_max")
			{
				pocet = m_build_mat;
				disposal_cost_50T = disposal_cost_build_mat_50T;
				disposal_cost_10T = disposal_cost_build_mat_10T;
				disposal_cost_1T = disposal_cost_build_mat_1T;
			}
			
			if(pocet > 1000 && coins > (disposal_cost_50T-1))
			{ 
				Debug.Log("OK_50T");
				if(coins > (disposal_cost_50T-1))
				{
					nums = disposal_cost_50T;
					nums = (nums/5000);
					nums = pocet*nums;
					helper_1 = pocet;
				}
				if( coins < (disposal_cost_50T) && coins > (disposal_cost_50T/50))
				{
					helper = 0f;	
					helper = disposal_cost_50T/50;	
					helper = coins/helper;
					if(helper < 1f) 
					{ 
						helper = (disposal_cost_50T/50);
					}
					else
					{
						helper = (int)helper;
					}
					coins = coins - (int)helper;
					nums = helper;
					helper = (helper*(disposal_cost_50T/50));
					helper_1 = (int)helper;
				}
			}
			
		 	if(pocet > 100 && pocet < 1001 && coins < disposal_cost_50T && coins > (disposal_cost_10T-1))
			{ 
				Debug.Log("OK_10T");
				if(coins > (disposal_cost_10T-1))
				{
					nums = disposal_cost_10T;
					nums = (nums/1000);
					nums = pocet*nums;
					helper_1 = pocet;
				}
				if( coins < (disposal_cost_10T) && coins > (disposal_cost_10T/10))
				{
					helper = 0f;
					helper = (disposal_cost_10T/10);
					helper = coins/helper;
					if(helper < 1f) 
					{ 
						helper = 1f;
					}
					else
					{
						helper = (int)helper;
						
					}
					coins = coins - (int)helper;
					nums = helper;
					helper = helper * (disposal_cost_10T/10);
					helper_1 = (int)helper;
				}
			}
			
			    d = (100/disposal_cost_1T);
				if(d < 4f) i = 3;
				if(d > 3.9f && d < 5f) i = 4;
				if(d > 4.9f) i = 5;
				
			/* garbage to 100ks, for 4ks of 1 coins max 25 coins */
			if(pocet > i && coins > 0 && coins < disposal_cost_10T)
			{ 
				Debug.Log("OK_1T");
				if(coins > (disposal_cost_1T-1) && pocet > 100)
				{
					Debug.Log("OK_1T_state_1");
					helper = 0f;	
					helper = coins/disposal_cost_1T;
					helper = helper/100;
					nums = coins;
					helper_1 = (int)helper;
					Debug.Log(nums+"coins");
					Debug.Log(helper+"scraps");
				}
				else if(coins > (disposal_cost_1T-1) && pocet < 101)
				{
					Debug.Log("OK_1T_state_2");
					nums = disposal_cost_1T;
					nums = (nums/100);
					nums = pocet*nums;
					helper_1 = pocet;
				}
				else
				{
					
					coin_current = coins;
					for(int x = 0; x < 10; x++)
					{
						if( coin_current < (disposal_cost_1T) && coin_current > 0 && pocet > i )
						{
							Debug.Log("OK_1T_state_3");
							helper = 0f;	
							helper = coin_current/(100/disposal_cost_1T);
							if((int)helper < 1f) 
							{ 
								helper = 1f;
							}
							else
							{
								helper = (int)helper;
								helper = helper*(100/disposal_cost_1T);
							}
							nums = (int)helper;
							helper_1 = (int)helper*(100/disposal_cost_1T);
							coin_current -= (int)nums;
							coin_current_2 += (int)nums;
							scrap_current += helper_1; 
							Debug.Log(coin_current+"coins");
							Debug.Log(scrap_current+"scraps");
							if(coin_current < 1)
							{
								nums = coin_current_2;
								helper_1 = scrap_current;
							}
						}
						
					}
				}
			}
			
			if(txt == "garbage_max") m_garbage -= helper_1;
			if(txt == "paper_max") m_paper -= helper_1;
			if(txt == "bio_max") m_bio -= helper_1;
			if(txt == "metal_max") m_metal -= helper_1;
			if(txt == "glass_max") m_glass -= helper_1;
			if(txt == "plastic_max") m_plastic -= helper_1;
			if(txt == "build_mat_max") m_build_mat -= helper_1;
			if(txt == "electric_max") m_electric -= helper_1;
			if(txt == "woods_max") m_woods -= helper_1;
			if(txt == "tires_max") m_tires -= helper_1;
			if(txt == "vehicles_max") m_vehicles -= helper_1;
			if(txt == "oil_max") m_oil -= helper_1;
			if(txt == "chemicals_max") m_chemicals -= helper_1;
			
			economicManager.GetComponent<Economic_manager>().coins -= (int)nums;
		}
		
		/* woods */
		if(txt == "woods_1t"){ m_tires -= 100; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_tires_1T; }
		if(txt == "woods_10t"){ m_tires -= 1000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_tires_10T; }
		if(txt == "woods_50t"){ m_tires -= 5000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_tires_50T; }
		//if(txt == "woods_max" && coins >= disposal_cost_garbage_50T && m_garbage >= 50){ m_garbage -= 50; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_garbage_50T; }
		if(txt == "woods_separate") {if(tires_recycle){tires_recycle = false;}else{tires_recycle = true;}}
		
		/* tires */
		if(txt == "tires_1t"){ m_tires -= 100; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_tires_1T; }
		if(txt == "tires_10t"){ m_tires -= 1000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_tires_10T; }
		if(txt == "tires_50t"){ m_tires -= 5000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_tires_50T; }
		//if(txt == "garbage_max" && coins >= disposal_cost_garbage_50T && m_garbage >= 50){ m_garbage -= 50; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_garbage_50T; }
		if(txt == "tires_separate") {if(tires_recycle){tires_recycle = false;}else{tires_recycle = true;}}
		
		/* vehicles */
		if(txt == "vehicles_1t"){ m_vehicles -= 100; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_vehicles_1T; }
		if(txt == "vehicles_10t"){ m_vehicles -= 1000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_vehicles_10T; }
		if(txt == "vehicles_50t"){ m_vehicles -= 5000; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_vehicles_50T; }
		//if(txt == "garbage_max" && coins >= disposal_cost_garbage_50T && m_garbage >= 50){ m_garbage -= 50; economicManager.GetComponent<Economic_manager>().coins -= disposal_cost_garbage_50T; }
		if(txt == "vehicles_separate") {if(vehicles_recycle){vehicles_recycle = false;}else{vehicles_recycle = true;}}
		
	}
	
	public float num_help;
    public void Update()
    {
		
		warehouse_level.text = "level "+level.ToString() + " / " + max_storage.ToString()+"t";
		
		GameObject go;
		/* GARBAGE */
		go = garbage_BTN_separate.transform.gameObject;
		if(level > 1)
		{
			garbage_go.transform.GetChild(0).transform.gameObject.SetActive(false);
			garbage_go.transform.GetChild(1).transform.gameObject.GetComponent<Text>().text = "Separate";
			if(!garbage_recycle){go.GetComponent<Image>().color = new Color32(255,64,64,255);} else { garbage_rooms.SetActive(true); go.GetComponent<Image>().color = new Color32(64,255,64,255); }
		} else {go.GetComponent<Image>().color = new Color32(255,64,64,255);}
		/* PAPER */
		go = paper_BTN_separate.transform.gameObject;
		if(level > 2)
		{
			paper_go.transform.GetChild(0).transform.gameObject.SetActive(false);
			paper_go.transform.GetChild(1).transform.gameObject.GetComponent<Text>().text = "Recycle";
			if(!paper_recycle){go.GetComponent<Image>().color = new Color32(255,64,64,255);} else { paper_rooms.SetActive(true); go.GetComponent<Image>().color = new Color32(64,255,64,255); }
		} else {go.GetComponent<Image>().color = new Color32(255,64,64,255);}
		/* BIO */
		go = bio_BTN_separate.transform.gameObject;
		if(level > 3)
		{
			bio_go.transform.GetChild(0).transform.gameObject.SetActive(false);
			bio_go.transform.GetChild(1).transform.gameObject.GetComponent<Text>().text = "Recycle";
			if(!bio_recycle){go.GetComponent<Image>().color = new Color32(255,64,64,255);} else {  bio_rooms.SetActive(true);go.GetComponent<Image>().color = new Color32(64,255,64,255); }
		} else {go.GetComponent<Image>().color = new Color32(255,64,64,255);}
		/* METAL */
		go = metal_BTN_separate.transform.gameObject;
		if(level > 4)
		{
			metal_go.transform.GetChild(0).transform.gameObject.SetActive(false);
			metal_go.transform.GetChild(1).transform.gameObject.GetComponent<Text>().text = "Recycle";
			if(!metal_recycle){go.GetComponent<Image>().color = new Color32(255,64,64,255);} else { go.GetComponent<Image>().color = new Color32(64,255,64,255); }
		} else {go.GetComponent<Image>().color = new Color32(255,64,64,255);}
		/* GLASS */
		go = glass_BTN_separate.transform.gameObject;
		if(level > 5)
		{
			glass_go.transform.GetChild(0).transform.gameObject.SetActive(false);
			glass_go.transform.GetChild(1).transform.gameObject.GetComponent<Text>().text = "Recycle";
			if(!glass_recycle){go.GetComponent<Image>().color = new Color32(255,64,64,255);} else { go.GetComponent<Image>().color = new Color32(64,255,64,255); }
		} else {go.GetComponent<Image>().color = new Color32(255,64,64,255);}
		/* PLASTIC */
		go = plastic_BTN_separate.transform.gameObject;
		if(level > 6)
		{
			plastic_go.transform.GetChild(0).transform.gameObject.SetActive(false);
			plastic_go.transform.GetChild(1).transform.gameObject.GetComponent<Text>().text = "Recycle";
			if(!plastic_recycle){go.GetComponent<Image>().color = new Color32(255,64,64,255);} else { go.GetComponent<Image>().color = new Color32(64,255,64,255); }
		} else {go.GetComponent<Image>().color = new Color32(255,64,64,255);}
		/* BUILD_MAT */
		go = build_mat_BTN_separate.transform.gameObject;
		if(level > 7)
		{
			build_mat_go.transform.GetChild(0).transform.gameObject.SetActive(false);
			build_mat_go.transform.GetChild(1).transform.gameObject.GetComponent<Text>().text = "Recycle";
			if(!glass_recycle){go.GetComponent<Image>().color = new Color32(255,64,64,255);} else { go.GetComponent<Image>().color = new Color32(64,255,64,255); }
		} else {go.GetComponent<Image>().color = new Color32(255,64,64,255);}
		/* ELECTRIC */
		go = electric_BTN_separate.transform.gameObject;
		if(level > 8)
		{
			electric_go.transform.GetChild(0).transform.gameObject.SetActive(false);
			electric_go.transform.GetChild(1).transform.gameObject.GetComponent<Text>().text = "Separate";
			if(!electric_recycle){go.GetComponent<Image>().color = new Color32(255,64,64,255);} else { go.GetComponent<Image>().color = new Color32(64,255,64,255); }
		} else {go.GetComponent<Image>().color = new Color32(255,64,64,255);}
		/* WOODS */
		go = woods_BTN_separate.transform.gameObject;
		if(level > 9)
		{
			woods_go.transform.GetChild(0).transform.gameObject.SetActive(false);
			woods_go.transform.GetChild(1).transform.gameObject.GetComponent<Text>().text = "Recycle";
			if(!woods_recycle){go.GetComponent<Image>().color = new Color32(255,64,64,255);} else { go.GetComponent<Image>().color = new Color32(64,255,64,255); }
		} else {go.GetComponent<Image>().color = new Color32(255,64,64,255);}
		/* TIRES */
		go = tires_BTN_separate.transform.gameObject;
		if(level > 10)
		{
			tires_go.transform.GetChild(0).transform.gameObject.SetActive(false);
			tires_go.transform.GetChild(1).transform.gameObject.GetComponent<Text>().text = "Recycle";
			if(!tires_recycle){go.GetComponent<Image>().color = new Color32(255,64,64,255);} else { go.GetComponent<Image>().color = new Color32(64,255,64,255); }
		} else {go.GetComponent<Image>().color = new Color32(255,64,64,255);}
		/* VEHICLES */
		go = vehicles_BTN_separate.transform.gameObject;
		if(level > 11)
		{
			vehicles_go.transform.GetChild(0).transform.gameObject.SetActive(false);
			vehicles_go.transform.GetChild(1).transform.gameObject.GetComponent<Text>().text = "Separate";
			if(!vehicles_recycle){go.GetComponent<Image>().color = new Color32(255,64,64,255);} else { go.GetComponent<Image>().color = new Color32(64,255,64,255); }
		} else {go.GetComponent<Image>().color = new Color32(255,64,64,255);}
		/* OIL */
		go = oil_BTN_separate.transform.gameObject;
		if(level > 12)
		{
			oil_go.transform.GetChild(0).transform.gameObject.SetActive(false);
			oil_go.transform.GetChild(1).transform.gameObject.GetComponent<Text>().text = "Recycle";
			if(!oil_recycle){go.GetComponent<Image>().color = new Color32(255,64,64,255);} else { go.GetComponent<Image>().color = new Color32(64,255,64,255); }
		} else {go.GetComponent<Image>().color = new Color32(255,64,64,255);}
		/* CHEMICALS */
		go = chemicals_BTN_separate.transform.gameObject;
		if(level > 13)
		{
			chemicals_go.transform.GetChild(0).transform.gameObject.SetActive(false);
			chemicals_go.transform.GetChild(1).transform.gameObject.GetComponent<Text>().text = "Recycle";
			if(!chemicals_recycle){go.GetComponent<Image>().color = new Color32(255,64,64,255);} else { go.GetComponent<Image>().color = new Color32(64,255,64,255); }
		} else {go.GetComponent<Image>().color = new Color32(255,64,64,255);}
		
		cars_level_text.text = "Level"+"\n"+cars_level.ToString();
		num_help = current_storage;
		num_help = num_help/100;
		total_storage.text = "Total storage: "+ max_storage.ToString() + "t/" + num_help.ToString()+"t";
		Enable_disable_buttons();
		
		if(level > 1){ paper = true; }
		if(level > 2){ metal = true; }
		if(level > 3){ bio = true; }
		if(level > 4){ glass = true; }
		if(level > 5){ plastic = true; }
		if(level > 6){ build_mat = true; }
		if(level > 7){ electric = true; }
		if(level > 8){ woods = true; }
		if(level > 9){ tires = true; }
		if(level > 10){ vehicles = true; }
		if(level > 11){ oil = true; }
		if(level > 12){ chemicals = true; }
		
		string txt;
		if(coins >= warehouse_cost){ txt = "  "; arrow_warehouseLevel_BTN.SetActive(true); } else {txt = ""; arrow_warehouseLevel_BTN.SetActive(false);}
		txt = "Level"+txt+"\n"+level.ToString();
		if(level < 1) txt = "Start!";
		warehouse_level_btn.text = txt;
		
		current_storage = 0;
		current_storage += m_garbage;
		current_storage += m_paper;
		current_storage += m_metal;
		current_storage += m_bio;
		current_storage += m_glass;
		current_storage += m_plastic;
		current_storage += m_build_mat;
		current_storage += m_electric;
		current_storage += m_woods;
		current_storage += m_tires;
		current_storage += m_vehicles;
		current_storage += m_oil;
		current_storage += m_chemicals;
    }
	
	public void Enable_disable_buttons()
	{
		coins = economicManager.GetComponent<Economic_manager>().coins;
		if(coins >= warehouse_cost && level < 100){ warehouseUpgradeBTN.interactable = true; } else { warehouseUpgradeBTN.interactable = false; }
		if(coins >= cars_cost && cars_level < 100){ carsUpgradeBTN.interactable = true; arrow_CarLevel_BTN.SetActive(true); } else { carsUpgradeBTN.interactable = false; arrow_CarLevel_BTN.SetActive(false); }
		
		/* garbage */
		if(coins >= disposal_cost_garbage_1T && m_garbage >= 100 ){ garbage_BTN_1t.interactable = true; } else { garbage_BTN_1t.interactable = false; }
		if(coins >= disposal_cost_garbage_10T && m_garbage >= 1000 ){ garbage_BTN_10t.interactable = true; } else { garbage_BTN_10t.interactable = false; }
		if(coins >= disposal_cost_garbage_50T && m_garbage >= 5000 ){ garbage_BTN_50t.interactable = true; } else { garbage_BTN_50t.interactable = false; }
		if(coins > 0 && m_garbage > 3) { garbage_BTN_max.interactable = true; } else { garbage_BTN_max.interactable = false; }
		if(m_garbage > 0){ garbage_BTN_separate.interactable = true; } else { garbage_BTN_separate.interactable = false; }
		/* paper */
		if(coins >= disposal_cost_paper_1T && m_paper >= 100 ){ paper_BTN_1t.interactable = true; } else { paper_BTN_1t.interactable = false; }
		if(coins >= disposal_cost_paper_10T && m_paper >= 1000 ){ paper_BTN_10t.interactable = true; } else { paper_BTN_10t.interactable = false; }
		if(coins >= disposal_cost_paper_50T && m_paper >= 5000 ){ paper_BTN_50t.interactable = true; } else { paper_BTN_50t.interactable = false; }
		if(coins > 0 && m_paper > 5 ){ paper_BTN_max.interactable = true; } else { paper_BTN_max.interactable = false; }
		if(m_paper > 0 ){ paper_BTN_separate.interactable = true; } else { paper_BTN_separate.interactable = false; }
		/* bio */
		if(coins >= disposal_cost_bio_1T && m_bio >= 100 ){ bio_BTN_1t.interactable = true; } else { bio_BTN_1t.interactable = false; }
		if(coins >= disposal_cost_bio_10T && m_bio >= 1000 ){ bio_BTN_10t.interactable = true; } else { bio_BTN_10t.interactable = false; }
		if(coins >= disposal_cost_bio_50T && m_bio >= 5000 ){ bio_BTN_50t.interactable = true; } else { bio_BTN_50t.interactable = false; }
		if(coins > 0 && m_bio > 5 ){ bio_BTN_max.interactable = true; } else { bio_BTN_max.interactable = false; }
		if(m_bio > 0 ){ bio_BTN_separate.interactable = true; } else { bio_BTN_separate.interactable = false; }
		/* metal */
		if(coins >= disposal_cost_metal_1T && m_metal >= 100 ){ metal_BTN_1t.interactable = true; } else { metal_BTN_1t.interactable = false; }
		if(coins >= disposal_cost_metal_10T && m_metal >= 1000 ){ metal_BTN_10t.interactable = true; } else { metal_BTN_10t.interactable = false; }
		if(coins >= disposal_cost_metal_50T && m_metal >= 5000 ){ metal_BTN_50t.interactable = true; } else { metal_BTN_50t.interactable = false; }
		if(coins > 0 && m_metal > 5 ){ metal_BTN_max.interactable = true; } else { metal_BTN_max.interactable = false; }
		if(m_metal > 0 ){ metal_BTN_separate.interactable = true; } else { metal_BTN_separate.interactable = false; }
		/* glass */
		if(coins >= disposal_cost_glass_1T && m_glass >= 100 ){ glass_BTN_1t.interactable = true; } else { glass_BTN_1t.interactable = false; }
		if(coins >= disposal_cost_glass_10T && m_glass >= 1000 ){ glass_BTN_10t.interactable = true; } else { glass_BTN_10t.interactable = false; }
		if(coins >= disposal_cost_glass_50T && m_glass >= 5000 ){ glass_BTN_50t.interactable = true; } else { glass_BTN_50t.interactable = false; }
		if(coins > 0 && m_glass > 5) { glass_BTN_max.interactable = true; } else { glass_BTN_max.interactable = false; }
		if(m_glass > 0){ glass_BTN_separate.interactable = true; } else { glass_BTN_separate.interactable = false; }
		/* plastic */
		if(coins >= disposal_cost_plastic_1T && m_plastic >= 100 ){ plastic_BTN_1t.interactable = true; } else { plastic_BTN_1t.interactable = false; }
		if(coins >= disposal_cost_plastic_10T && m_plastic >= 1000 ){ plastic_BTN_10t.interactable = true; } else { plastic_BTN_10t.interactable = false; }
		if(coins >= disposal_cost_plastic_50T && m_plastic >= 5000 ){ plastic_BTN_50t.interactable = true; } else { plastic_BTN_50t.interactable = false; }
		if(coins > 0 && m_plastic > 5) { plastic_BTN_max.interactable = true; } else { plastic_BTN_max.interactable = false; }
		if(m_plastic > 0){ plastic_BTN_separate.interactable = true; } else { plastic_BTN_separate.interactable = false; }
		/* build. mat. */
		if(coins >= disposal_cost_build_mat_1T && m_build_mat >= 100 ){ build_mat_BTN_1t.interactable = true; } else { build_mat_BTN_1t.interactable = false; }
		if(coins >= disposal_cost_build_mat_10T && m_build_mat >= 1000 ){ build_mat_BTN_10t.interactable = true; } else { build_mat_BTN_10t.interactable = false; }
		if(coins >= disposal_cost_build_mat_50T && m_build_mat >= 5000 ){ build_mat_BTN_50t.interactable = true; } else { build_mat_BTN_50t.interactable = false; }
		if(coins > 0 && m_build_mat > 5) { build_mat_BTN_max.interactable = true; } else { build_mat_BTN_max.interactable = false; }
		if(m_build_mat > 0){ build_mat_BTN_separate.interactable = true; } else { build_mat_BTN_separate.interactable = false; }
		/* electric */
		if(coins >= disposal_cost_electric_1T && m_electric >= 100 ){ electric_BTN_1t.interactable = true; } else { electric_BTN_1t.interactable = false; }
		if(coins >= disposal_cost_electric_10T && m_electric >= 1000 ){ electric_BTN_10t.interactable = true; } else { electric_BTN_10t.interactable = false; }
		if(coins >= disposal_cost_electric_50T && m_electric >= 5000 ){ electric_BTN_50t.interactable = true; } else { electric_BTN_50t.interactable = false; }
		if(coins > 0 && m_electric > 5) { electric_BTN_max.interactable = true; } else { electric_BTN_max.interactable = false; }
		if(m_electric > 0){ electric_BTN_separate.interactable = true; } else { electric_BTN_separate.interactable = false; }
		/* woods */
		if(coins >= disposal_cost_woods_1T && m_woods >= 100 ){ woods_BTN_1t.interactable = true; } else { woods_BTN_1t.interactable = false; }
		if(coins >= disposal_cost_woods_10T && m_woods >= 1000 ){ woods_BTN_10t.interactable = true; } else { woods_BTN_10t.interactable = false; }
		if(coins >= disposal_cost_woods_50T && m_woods >= 5000 ){ woods_BTN_50t.interactable = true; } else { woods_BTN_50t.interactable = false; }
		if(coins > 0 && m_woods > 5) { woods_BTN_max.interactable = true; } else { woods_BTN_max.interactable = false; }
		if(m_woods > 0){ woods_BTN_separate.interactable = true; } else { woods_BTN_separate.interactable = false; }
		
		if(coins >= disposal_cost_tires_1T && m_tires >= 100 ){ tires_BTN_1t.interactable = true; } else { tires_BTN_1t.interactable = false; }
		if(coins >= disposal_cost_tires_10T && m_tires >= 1000 ){ tires_BTN_10t.interactable = true; } else { tires_BTN_10t.interactable = false; }
		if(coins >= disposal_cost_tires_50T && m_tires >= 5000 ){ tires_BTN_50t.interactable = true; } else { tires_BTN_50t.interactable = false; }
		if(coins >= 0 && m_tires >= 5 ){ tires_BTN_max.interactable = true; } else { tires_BTN_max.interactable = false; }
		if(m_tires > 0){ tires_BTN_separate.interactable = true; } else { tires_BTN_separate.interactable = false; }
		
		if(coins >= disposal_cost_vehicles_1T && m_vehicles >= 100 ){ vehicles_BTN_1t.interactable = true; } else { vehicles_BTN_1t.interactable = false; }
		if(coins >= disposal_cost_vehicles_10T && m_vehicles >= 1000 ){ vehicles_BTN_10t.interactable = true; } else { vehicles_BTN_10t.interactable = false; }
		if(coins >= disposal_cost_vehicles_50T && m_vehicles >= 5000 ){ vehicles_BTN_50t.interactable = true; } else { vehicles_BTN_50t.interactable = false; }
		if(coins >= 0 && m_vehicles >= 5 ){ vehicles_BTN_max.interactable = true; } else { vehicles_BTN_max.interactable = false; }
		if(m_vehicles > 0){ vehicles_BTN_separate.interactable = true; } else { vehicles_BTN_separate.interactable = false; }
		
		if(coins >= disposal_cost_oil_1T && m_oil >= 100 ){ oil_BTN_1t.interactable = true; } else { oil_BTN_1t.interactable = false; }
		if(coins >= disposal_cost_oil_10T && m_oil >= 1000 ){ oil_BTN_10t.interactable = true; } else { oil_BTN_10t.interactable = false; }
		if(coins >= disposal_cost_oil_50T && m_oil >= 5000 ){ oil_BTN_50t.interactable = true; } else { oil_BTN_50t.interactable = false; }
		if(coins >= 0 && m_oil >= 5 ){ oil_BTN_max.interactable = true; } else { oil_BTN_max.interactable = false; }
		if(m_oil > 0){ oil_BTN_separate.interactable = true; } else { oil_BTN_separate.interactable = false; }
		
		if(coins >= disposal_cost_chemicals_1T && m_chemicals >= 100 ){ chemicals_BTN_1t.interactable = true; } else { chemicals_BTN_1t.interactable = false; }
		if(coins >= disposal_cost_chemicals_10T && m_chemicals >= 1000 ){ chemicals_BTN_10t.interactable = true; } else { chemicals_BTN_10t.interactable = false; }
		if(coins >= disposal_cost_chemicals_50T && m_chemicals >= 5000 ){ chemicals_BTN_50t.interactable = true; } else { chemicals_BTN_50t.interactable = false; }
		if(coins >= 0 && m_chemicals >= 5 ){ chemicals_BTN_max.interactable = true; } else { chemicals_BTN_max.interactable = false; }
		if(m_chemicals > 0){ chemicals_BTN_separate.interactable = true; } else { chemicals_BTN_separate.interactable = false; }
		
	}
}