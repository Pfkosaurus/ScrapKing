using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Economic_manager : MonoBehaviour
{
	public Text coin_text;
	public int coins;
	private int coins_help;
	
	/* *** costs **** */
	public float amortization_truck_cost;
	public float electric_costs_KWh_1hod = 0.26f;
	public float water_costs_1_cm3 = 0.69f;
	public float gass_costs_KWh_1hod = 0.35f;
	
    // Start is called before the first frame update
    void Start()
    {
		GameObject go = GameObject.FindGameObjectWithTag("Coins_num");
		coin_text = go.GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if(coins > coins_help)
		{ 	
			if(coins > (coins_help+100000))
			{ 
				coins_help += 11111;
			}
			else if(coins > (coins_help+10000))
			{ 
				coins_help += 1111;
			}
			else if(coins > (coins_help+1000))
			{ 
				coins_help += 111;
			}
			else if(coins > (coins_help+100))
			{ 
				coins_help += 11;
			}
			else
			{
				coins_help++;
			}
		}
		
		if(coins < coins_help)
		{
			if(coins < (coins_help-100000))
			{ 
				coins_help -= 11111;
			}
			else if(coins < (coins_help-10000))
			{ 
				coins_help -= 1111;
			}
			else if(coins < (coins_help-1000))
			{ 
				coins_help -= 111;
			}
			else if(coins < (coins_help-100))
			{ 
				coins_help -= 11;
			}
			else
			{
				coins_help--; 
			}
		}
		
		
        coin_text.text = coins_help.ToString();
    }
}
