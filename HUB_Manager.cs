using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUB_Manager : MonoBehaviour
{
	public Text garbage_num;
	public Text paper_num;
	public Text bio_num;
	public Text metal_num;
	public Text glass_num;
	public Text plastic_num;
	public Text build_mat_num;
	public Text electric_num;
	public Text woods_num;
	public Text tires_num;
	public Text vehicles_num;
	public Text oil_num;
	public Text chemicals_num;
	
	public Text warehouse_level_num;
	public Text cars_level_num;
	
	public GameObject storage_hub;
	public Warehouse warehouse;
	
	private GameObject economicManager; 
	
	public GameObject storage_go;
	public GameObject upgrade_go;
	
	public GameObject garbage_lock,paper_lock,bio_lock,metal_lock,glass_lock,plastic_lock,build_mat_lock,electric_lock,woods_lock,tires_lock,vehicles_lock,oil_lock,chemicals_lock;
	public GameObject garbage_lock_export,paper_lock_export,bio_lock_export,metal_lock_export,glass_lock_export,plastic_lock_export,build_mat_lock_export,electric_lock_export,woods_lock_export,tires_lock_export,vehicles_lock_export,oil_lock_export,chemicals_lock_export;
    // Start is called before the first frame update
    void Start()
    {
		
		economicManager = GameObject.FindGameObjectWithTag("EconomicManager");
		GameObject warehouse_go = GameObject.FindGameObjectWithTag("Warehouse");
		warehouse = warehouse_go.GetComponent<Warehouse>();
		storage_go.SetActive(true);
		upgrade_go.SetActive(false);
        storage_hub.SetActive(false);
    }
	 void OnDisable()
    {
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
		//SaveData();
    }

    void OnEnable()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
		//LoadData();
    }
	/*
	void SaveData()
	{
		PlayerPrefs.SetInt("coins", economicManager.GetComponent<Economic_manager>().coins);
		PlayerPrefs.SetInt("warehouse_level", warehouse.level);
	}
	
	void LoadData()
	{
		economicManager.GetComponent<Economic_manager>().coins = PlayerPrefs.GetInt("coins");
		warehouse.level = PlayerPrefs.GetInt("warehouse_level");
	}
	*/
	public void Storage_Hub_Open()
	{
		if(warehouse.level < 1)
		{ 
			warehouse.level = 1;
			warehouse.cars_level = 1;
			warehouse.truck.SetActive(true);
			economicManager.GetComponent<Economic_manager>().coins += 150;
		}
		else
		{
			storage_hub.SetActive(true);
		}
	}
	
	public void Storage_Hub_Close()
	{
		storage_hub.SetActive(false);
	}
	
	public void Warehouse_storage()
	{
		storage_go.SetActive(true);
		upgrade_go.SetActive(false);
	}
	
	public void Warehouse_upgrade()
	{
		storage_go.SetActive(false);
		upgrade_go.SetActive(true);
	}
	
	//********** Timer ***********//
	public Text timer;
	public int total_time;
	/* ***** call this on update ***** */
	private float total_time_;
     private float secondsCount;
     private int minuteCount;
     // private int hourCount;
	 private string sec;
	 private string min;
	 
    public void Timer(){
		
		secondsCount += Time.deltaTime;
		total_time_ += Time.deltaTime;
		total_time = (int)total_time_;
         if(secondsCount >= 60){
                 minuteCount++;
                 secondsCount = 0;
            } else if(minuteCount >= 60){
                 //hourCount++;
                 minuteCount = 0;
              }
		  if(secondsCount >= 10){
			    sec = "";
		    } else {
			    sec = "0";
		    }
		  if(minuteCount >= 10){
			    min = "";
		     } else {
			 min = "0";
		     }
		timer.text =  min + minuteCount +":"+ sec +(int)secondsCount;
	}
	
	public void WasteRecycle()
	{
		if(warehouse.level > 1) { garbage_lock.SetActive(false); } else { garbage_lock.SetActive(true); }
		if(warehouse.level > 2) { paper_lock.SetActive(false); } else { paper_lock.SetActive(true); }
		if(warehouse.level > 3) { bio_lock.SetActive(false); } else { bio_lock.SetActive(true); }
		if(warehouse.level > 4) { metal_lock.SetActive(false); } else { metal_lock.SetActive(true); }
		if(warehouse.level > 5) { glass_lock.SetActive(false); } else { glass_lock.SetActive(true); }
		if(warehouse.level > 6) { plastic_lock.SetActive(false); } else { plastic_lock.SetActive(true); }
		if(warehouse.level > 7) { build_mat_lock.SetActive(false); } else { build_mat_lock.SetActive(true); }
		if(warehouse.level > 8) { electric_lock.SetActive(false); } else { electric_lock.SetActive(true); }
		if(warehouse.level > 9) { woods_lock.SetActive(false); } else { woods_lock.SetActive(true); }
		if(warehouse.level > 10) { tires_lock.SetActive(false); } else { tires_lock.SetActive(true); }
		if(warehouse.level > 11) { vehicles_lock.SetActive(false); } else { vehicles_lock.SetActive(true); }
		if(warehouse.level > 12) { oil_lock.SetActive(false); } else { oil_lock.SetActive(true); }
		if(warehouse.level > 13) { chemicals_lock.SetActive(false); } else { chemicals_lock.SetActive(true); }
	}
	
	public void WasteExport()
	{
		if(warehouse.cars_level > 0) { garbage_lock_export.SetActive(false); } else { garbage_lock_export.SetActive(true); }
		if(warehouse.cars_level > 1) { paper_lock_export.SetActive(false); } else { paper_lock_export.SetActive(true); }
		if(warehouse.cars_level > 2) { bio_lock_export.SetActive(false); } else { bio_lock_export.SetActive(true); }
		if(warehouse.cars_level > 3) { metal_lock_export.SetActive(false); } else { metal_lock_export.SetActive(true); }
		if(warehouse.cars_level > 4) { glass_lock_export.SetActive(false); } else { glass_lock_export.SetActive(true); }
		if(warehouse.cars_level > 5) { plastic_lock_export.SetActive(false); } else { plastic_lock_export.SetActive(true); }
		if(warehouse.cars_level > 6) { build_mat_lock_export.SetActive(false); } else { build_mat_lock_export.SetActive(true); }
		if(warehouse.cars_level > 7) { electric_lock_export.SetActive(false); } else { electric_lock_export.SetActive(true); }
		if(warehouse.cars_level > 8) { woods_lock_export.SetActive(false); } else { woods_lock_export.SetActive(true); }
		if(warehouse.cars_level > 9) { tires_lock_export.SetActive(false); } else { tires_lock_export.SetActive(true); }
		if(warehouse.cars_level > 10) { vehicles_lock_export.SetActive(false); } else { vehicles_lock_export.SetActive(true); }
		if(warehouse.cars_level > 11) { oil_lock_export.SetActive(false); } else { oil_lock_export.SetActive(true); }
		if(warehouse.cars_level > 12) { chemicals_lock_export.SetActive(false); } else { chemicals_lock_export.SetActive(true); }
		
	}
	
    // Update is called once per frame
    public void Update()
    {
		WasteRecycle();
		WasteExport();
		
		Timer();
		
		if(storage_hub.active)
		{
			
			float num = 0f;
			num = warehouse.m_garbage;
			garbage_num.text = (num/100).ToString() + " t";
		
			num = warehouse.m_paper;
			paper_num.text = (num/100).ToString() + " t";
		
			num = warehouse.m_bio;
			bio_num.text = (num/100).ToString() + " t";
		
			num = warehouse.m_metal;
			metal_num.text = (num/100).ToString() + " t";
		
			num = warehouse.m_glass;
			glass_num.text = (num/100).ToString() + " t";
		
			num = warehouse.m_plastic;
			plastic_num.text = (num/100).ToString() + " t";
		
			num = warehouse.m_build_mat;
			build_mat_num.text = (num/100).ToString() + " t";
		
			num = warehouse.m_electric;
			electric_num.text = (num/100).ToString() + " t";
			
			num = warehouse.m_woods;
			woods_num.text = (num/100).ToString() + " t";
			
			num = warehouse.m_tires;
			tires_num.text = (num/100).ToString() + " t";
			
			num = warehouse.m_vehicles;
			vehicles_num.text = (num/100).ToString() + " t";
			
			num = warehouse.m_oil;
			oil_num.text = (num/100).ToString() + " t";
			
			num = warehouse.m_chemicals;
			chemicals_num.text = (num/100).ToString() + " t";
		}
    }
}
