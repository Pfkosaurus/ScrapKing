using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Auto : MonoBehaviour
{
	//public Button button;
	public Animator anim;
	
	public WheelJoint2D frontwheel;
	public WheelJoint2D backwheel;
	public WheelJoint2D backwheel_2;
	
	public bool brzda;
	public BoxCollider2D brzdaKolider;
	public BoxCollider2D depoKolider;
	public Transform transform_depo;
	public bool depo;
	
	public Rigidbody2D rg2D;
	public float velocityX;
	JointMotor2D motorFront;

	JointMotor2D motorBack;
	
	public float speed = 100f;
	public float speedF;
	public float speedB;

	public float torqueF;
	public float torqueB;

	public bool TractionFront = true;
	public bool TractionBack = true;

	float carRotationSpeed;
	
	bool car_forward = true;
	bool stay = true;
	bool vylozit;
	bool run;
	float timer;
	float t;
	
	GameObject economicManager;
	GameObject warehouse_go;
	public int coins; //zisk
	public int level;
	
	public int num_scrap;
	public int kupit_Srot;
	public int srot;
	bool m_nalozit;
	int nalozenyTovar = 0;
	public GameObject invoke_point_out;
	public GameObject[] scrap_prefab_out;
	public bool dorazNavykladku;
	float helpSpeed;
	bool uzNalozeny;
	
	public GameObject garbage_go;
	private Vector3 garbage_pos;
	
	public Text current_scrap;

	// Use this for initialization
	void Start () 
	{
		garbage_pos = garbage_go.transform.localPosition;
		brzda = false;
		economicManager = GameObject.FindGameObjectWithTag("EconomicManager");
		warehouse_go = GameObject.FindGameObjectWithTag("Warehouse");
	}

	public void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag ("doraznavykladku"))
		{
			dorazNavykladku = true;
		}
		
		if (other.gameObject.CompareTag ("brzda"))
		{
			if(brzda)
			{
				stay = true;
				brzda = false;
				depoKolider.enabled = true;
			}
		}
		if (other.gameObject.CompareTag ("depo"))
		{
			//brzda = true;
			//brzdaKolider.enabled = true;
			
			motorBack.motorSpeed = 0f;
			
			if (TractionBack) {
				motorBack.maxMotorTorque = torqueF;
				backwheel.motor = motorBack;
				backwheel_2.motor = motorBack;
			}
			rg2D.velocity = new Vector2(0,0);
			rg2D.isKinematic = true;
			depoKolider.enabled = false;
			stay = true;
			run = false;
			//button.interactable = true;
			Objednat();
		}
	}
	
	public int m_select;
	public int selected;
	public float timer_scrap = 0f;
	private float nums_scrap;
	private float nums_scrap_help;

	public void Objednat()
	{
		if(coins >= kupit_Srot)
		{
			brzda = true;
			dorazNavykladku = false;
			helpSpeed = -15f;
			nalozenyTovar = 0;
			uzNalozeny = true;
			//m_nalozit = true;
			depo = false;
			//button.interactable = false;
			rg2D.isKinematic = false;
			economicManager.GetComponent<Economic_manager>().coins -= kupit_Srot;
			
			garbage_pos.y = 1.08f;
			
			garbage_go.transform.localPosition = garbage_pos;
			
			m_select = 0;
			nums_scrap_help = 0f;
			if(warehouse_go.GetComponent<Warehouse>().garbage){ m_select = 1; }
			if(warehouse_go.GetComponent<Warehouse>().paper){ m_select = 2; }
			if(warehouse_go.GetComponent<Warehouse>().metal){ m_select = 3; }
			if(warehouse_go.GetComponent<Warehouse>().bio){ m_select = 4; }
			if(warehouse_go.GetComponent<Warehouse>().glass){ m_select = 5; }
			if(warehouse_go.GetComponent<Warehouse>().plastic){ m_select = 6; }
			if(warehouse_go.GetComponent<Warehouse>().build_mat){ m_select = 7; }
			if(warehouse_go.GetComponent<Warehouse>().electric){ m_select = 8; }
			if(warehouse_go.GetComponent<Warehouse>().woods){ m_select = 9; }
			if(warehouse_go.GetComponent<Warehouse>().tires){ m_select = 10; }
			if(warehouse_go.GetComponent<Warehouse>().vehicles){ m_select = 11; }
			if(warehouse_go.GetComponent<Warehouse>().oil){ m_select = 12; }
			if(warehouse_go.GetComponent<Warehouse>().chemicals){ m_select = 13; }
			
			selected = Random.Range(1, m_select);
			Debug.Log(selected);
			
			//if(selected == 0) { num_scrap = Random.Range(349,551); }
			if(selected == 1) { num_scrap = Random.Range(249,351); } 			
			if(selected == 2) { num_scrap = Random.Range(249,351); } 	
			if(selected == 3) { num_scrap = Random.Range(249,351); } 	
			if(selected == 4) { num_scrap = Random.Range(249,351); } 				
			if(selected == 5) { num_scrap = Random.Range(249,351); } 			
			if(selected == 6) { num_scrap = Random.Range(249,351); } 			
			if(selected == 7) { num_scrap = Random.Range(249,351); } 						
			if(selected == 8) { num_scrap = Random.Range(249,351); } 	
			if(selected == 9) { num_scrap = Random.Range(249,351); } 	
			if(selected == 10) { num_scrap = Random.Range(249,351); } 	
			if(selected == 11) { num_scrap = Random.Range(249,351); } 				
			if(selected == 12) { num_scrap = Random.Range(249,351); } 				
			if(selected == 13) { num_scrap = Random.Range(249,351); } 				
			
			num_scrap = num_scrap + ((num_scrap/2)*level*2);
			srot = num_scrap;
		}	
	}
	
	public int earn_for_Car = 248;
	public int earn;
	private int nasobok;
	public void Update ()
	{
		
		float num_s = srot;
		current_scrap.text = (num_s/100).ToString()+"t";
		coins = economicManager.GetComponent<Economic_manager>().coins;
		level = warehouse_go.GetComponent<Warehouse>().cars_level;
		earn = (earn_for_Car+((earn_for_Car/2)*level));
			
		if(m_nalozit )
		{
			if(timer_scrap > 1.0f)
			{
				if(srot > 1450)
				{
					nasobok = 4;
				}
				else if(srot > 550 && srot < 1451)
				{
					nasobok = 3;
				}
				else if(srot > 150 && srot < 551 )
				{
					nasobok = 2;
				}
				else if(srot < 151)
				{
					nasobok = 1;
				}
				
				for( int t = 0; t < nasobok; t++)
				{
					if(srot > 0)
					{
						srot--;
					}
					float color_1 = Random.Range(0f,255f);
					float color_2 = Random.Range(0f,255f);	
					float color_3 = Random.Range(0f,255f);
					float pos_x = Random.Range(-0.50f,0.50f);	
					int x = scrap_prefab_out.Length;
					Vector3 m_pos = invoke_point_out.transform.position;
					m_pos.x += pos_x;
					GameObject go = Instantiate(scrap_prefab_out[Random.Range(0,x)], m_pos, invoke_point_out.transform.rotation);
					go.transform.localScale = new Vector3 ( 0.33f, 0.33f, 0.33f);
					go.GetComponent<Rigidbody2D>().mass = 0.5f;
					go.GetComponent<Rigidbody2D>().velocity = new Vector2(5,-3);
			
					if(selected == 1) { go.GetComponent<Scrap>().m_garbage = true; }
					if(selected == 2) { go.GetComponent<Scrap>().m_paper = true; }
					if(selected == 3) { go.GetComponent<Scrap>().m_metal = true; }
					if(selected == 4) { go.GetComponent<Scrap>().m_bio = true; }
					if(selected == 5) { go.GetComponent<Scrap>().m_glass = true; }
					if(selected == 6) { go.GetComponent<Scrap>().m_plastic = true; }
					if(selected == 7) { go.GetComponent<Scrap>().m_build_mat = true; }
					if(selected == 8) { go.GetComponent<Scrap>().m_electric = true; }
					if(selected == 9) { go.GetComponent<Scrap>().m_woods = true; }
					if(selected == 10) { go.GetComponent<Scrap>().m_tires = true; }
					if(selected == 11) { go.GetComponent<Scrap>().m_vehicles = true; }
					if(selected == 12) { go.GetComponent<Scrap>().m_oil = true; }
					if(selected == 13) { go.GetComponent<Scrap>().m_chemicals = true; }
	
					nalozenyTovar++;
				
					nums_scrap = num_scrap/140f;
				
					if(garbage_pos.y > -0.32f && nums_scrap <= nums_scrap_help)
					{
						garbage_pos.y -= 0.015f;
						nums_scrap_help -= nums_scrap;
					}
					else
					{
						nums_scrap_help += 1f;
					}
				}
				if(num_scrap <= nalozenyTovar)
				{
					economicManager.GetComponent<Economic_manager>().coins += earn;
					timer_scrap = 0f;
					m_nalozit = false;
					vylozit = false;
					//uzNalozeny = true;
				}
			}
			else
			{
				timer_scrap += Time.deltaTime;
			}
		}
		
		garbage_go.transform.localPosition = garbage_pos;
		
		if(uzNalozeny)
		{
			if(t > 1.0f)
			{
				stay = false;
				car_forward = true;
				run = true;
				t = 0f;
				uzNalozeny = false;
			}
			else
			{
				motorBack.motorSpeed = 0f;
				rg2D.velocity = new Vector2(0,0);
				t += Time.deltaTime;
			}
		}
		 
		velocityX = rg2D.velocity.x;
		
		if(velocityX != 0 && !stay && !vylozit)
		{
			vylozit = true;
		}
		if(velocityX == 0 && stay && vylozit && run)
		{
			if(num_scrap != 0 && warehouse_go.GetComponent<Warehouse>().max_storage < ((warehouse_go.GetComponent<Warehouse>().current_storage+(num_scrap+1))/100))
			{
				Debug.Log("Storage is full!");
			}
			else
			{
			brzda = false;
			dorazNavykladku = false;
			m_nalozit = true;
			//brzdaKolider.enabled = false;
			anim.SetBool ("vylozit", true);
			anim.SetBool ("vylozeny", false);
			}
		}
		if(velocityX == 0 && stay && !vylozit)
		{
			
			dorazNavykladku = true;
			anim.SetBool ("vylozit", false);
			anim.SetBool ("vylozeny", true);
			if(timer > 1.5f)
			{ 
				car_forward = false;
				stay = false;
				timer = 0f;
			}
			else
			{
				timer += Time.deltaTime;
			}
			
		}
	
		if (car_forward && !stay) {
			
			if (TractionFront) {
				if(motorFront.motorSpeed < speed)
				{
					motorFront.motorSpeed += speedF * -1;
				}
				motorFront.maxMotorTorque = torqueF;
				frontwheel.motor = motorFront;
			}

			if (TractionBack) {
				if(motorBack.motorSpeed < speed)
				{
					motorBack.motorSpeed += speedF * -1;
				}
				motorBack.maxMotorTorque = torqueF;
				backwheel.motor = motorBack;
				backwheel_2.motor = motorBack;
				backwheel_2.useMotor = false;

			}

		} else if (!car_forward && !stay) {


			if (TractionFront) {
				if(motorFront.motorSpeed > -speed)
				{
					motorFront.motorSpeed += speedB * -1;
				}
				motorFront.maxMotorTorque = torqueB;
				frontwheel.motor = motorFront;
			}

			if (TractionBack) {
				if(motorBack.motorSpeed > -speed)
				{
					motorBack.motorSpeed += speedB * -1;
				}
				motorBack.maxMotorTorque = torqueB;
				backwheel.motor = motorBack;
				backwheel_2.motor = motorBack;
			}

		} else {
			//backwheel_2.useMotor = false;
			//backwheel.useMotor = false;
			//frontwheel.useMotor = false;
			if(motorBack.motorSpeed > 50)
			{
				motorBack.motorSpeed -= speedB * -1;
			}
			else if(motorBack.motorSpeed < -50)
			{
				motorBack.motorSpeed -= speedF * -1;
				helpSpeed = motorBack.motorSpeed;
			}
			else
			{
				if(dorazNavykladku)
				{
					motorBack.motorSpeed = 0f;
					helpSpeed = motorBack.motorSpeed;
				}
				else
				{
					motorBack.motorSpeed = helpSpeed;
				}
			}
			
			if (TractionFront) {
				
				motorFront.maxMotorTorque = torqueF;
				frontwheel.motor = motorFront;
			}

			if (TractionBack) {
				motorBack.maxMotorTorque = torqueF;
				backwheel.motor = motorBack;
				backwheel_2.motor = motorBack;

			}

		}

		if (Input.GetAxisRaw ("Vertical") != 0) {

			GetComponent<Rigidbody2D> ().AddTorque (carRotationSpeed * Input.GetAxisRaw ("Horizontal") * -1);

		}

	}
	
}
