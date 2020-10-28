using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
	public string factory;
	public string scrap_name;
	public int price = 1;
	private bool sell;
	public Vector2 speed;
	public GameObject warehouse_go;
	public bool m_garbage,m_paper,m_metal,m_bio,m_glass,m_plastic,m_build_mat,m_electric,m_woods,m_tires,m_vehicles,m_oil,m_chemicals;
	public bool m_copy_paper,m_newspaper,m_packaging,m_contaminated;
	// Start is called1 before the first frame update
    void Start()
    {
		warehouse_go = GameObject.FindGameObjectWithTag("Warehouse");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag ("oven")){
			other.gameObject.GetComponent<Oven>().num++;
			Destroy(this.gameObject,0.2f);
		}
		
		if (other.gameObject.CompareTag ("Garbage") || other.gameObject.CompareTag ("ground") ){
			if(m_garbage) warehouse_go.gameObject.GetComponent<Warehouse>().m_garbage++;
			if(m_metal) warehouse_go.gameObject.GetComponent<Warehouse>().m_metal++;
			if(m_paper) warehouse_go.gameObject.GetComponent<Warehouse>().m_paper++;
			if(m_bio) warehouse_go.gameObject.GetComponent<Warehouse>().m_bio++;
			if(m_glass) warehouse_go.gameObject.GetComponent<Warehouse>().m_glass++;
			if(m_plastic) warehouse_go.gameObject.GetComponent<Warehouse>().m_plastic++;
			if(m_build_mat) warehouse_go.gameObject.GetComponent<Warehouse>().m_build_mat++;
			if(m_electric) warehouse_go.gameObject.GetComponent<Warehouse>().m_electric++;
			if(m_tires) warehouse_go.gameObject.GetComponent<Warehouse>().m_tires++;
			if(m_vehicles) warehouse_go.gameObject.GetComponent<Warehouse>().m_vehicles++;
			Destroy(this.gameObject,0.1f);
		}
		
		if (other.gameObject.CompareTag ("contajner")){
			other.gameObject.GetComponent<Contajner>().num++;
			Destroy(this.gameObject,0.2f);
		}
		
		if (other.gameObject.CompareTag ("Storage_box_garbage") || other.gameObject.CompareTag("Storage_box_paper")){
			if(other.gameObject.name == "Storage_box_garbage")
			{
				//Debug.Log("OK");
				//GameObject sellObject = GameObject.FindGameObjectWithTag("Warehouse");
				if(scrap_name == "paper") warehouse_go.gameObject.GetComponent<Warehouse>().m_paper++;
				if(scrap_name == "bio") warehouse_go.gameObject.GetComponent<Warehouse>().m_bio++;
				if(scrap_name == "metal") warehouse_go.gameObject.GetComponent<Warehouse>().m_metal++;
				if(scrap_name == "glass") warehouse_go.gameObject.GetComponent<Warehouse>().m_glass++;
				if(scrap_name == "plastic") warehouse_go.gameObject.GetComponent<Warehouse>().m_plastic++;
				if(scrap_name == "build_mat") warehouse_go.gameObject.GetComponent<Warehouse>().m_build_mat++;
				if(scrap_name == "electric") warehouse_go.gameObject.GetComponent<Warehouse>().m_electric++;
				if(scrap_name == "woods") warehouse_go.gameObject.GetComponent<Warehouse>().m_woods++;
				if(scrap_name == "tires") warehouse_go.gameObject.GetComponent<Warehouse>().m_tires++;
				if(scrap_name == "vehicles") warehouse_go.gameObject.GetComponent<Warehouse>().m_vehicles++;
				if(scrap_name == "oil") warehouse_go.gameObject.GetComponent<Warehouse>().m_oil++;
				if(scrap_name == "chemicals") warehouse_go.gameObject.GetComponent<Warehouse>().m_chemicals++;
				Destroy(this.gameObject,0.0f);

				//Debug.Log("OK");
			
			}			
			else if(other.gameObject.name == "Storage_box_paper")
			{
				//Debug.Log("OK");
				GameObject sellObject = GameObject.FindGameObjectWithTag("Copy_paper");
				//for(int c = 0; c < sellObject.Length; c++)
				//{
					//Debug.Log("OK_2");
				
					if(sellObject.GetComponent<Copy_paper>())
					{
						//Debug.Log("OK_3");
						sellObject.GetComponent<Copy_paper>().num++;
						/*
						if(scrap_name == "m_copy_paper") sellObject[c].GetComponent<Paper_room>().m_copy_paper++;
						if(scrap_name == "m_newspaper")	sellObject[c].GetComponent<Paper_room>().m_newspaper++;
						if(scrap_name == "m_packaging") sellObject[c].GetComponent<Paper_room>().m_packaging++;
						if(scrap_name == "m_contaminated") sellObject[c].GetComponent<Paper_room>().m_contaminated++;
						*/
					}
					Destroy(this.gameObject,0.0f);
				//}
			}			
			else
			{
				GameObject sellObject = GameObject.FindGameObjectWithTag("Warehouse");
				if(m_metal) warehouse_go.gameObject.GetComponent<Warehouse>().crush_metal++;
				Destroy(this.gameObject,0.0f);
			}
		}
		
		if (other.gameObject.CompareTag ("sell_place") && !sell){
			sell = true;
			GameObject sellObject = GameObject.FindGameObjectWithTag("EconomicManager");
			sellObject.GetComponent<Economic_manager>().coins += price;
			Destroy(this.gameObject,0.0f);
		}
	}
	
	public void OnCollisionEnter2D(Collision2D other)
	{
		
	}
	
	public void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("belt")){
			speed = other.gameObject.GetComponent<Belt>().currentSpeed;
			this.GetComponent<Rigidbody2D>().velocity = speed;
		}	
		
	
	}	
}