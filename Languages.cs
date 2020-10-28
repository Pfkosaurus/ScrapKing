using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Languages : MonoBehaviour
{
	public GameObject title_go;
	public bool english, slovak;
	public Text title, title_message, title_BTN_continue;
	private string title_string,title_message_string,title_BTN_continue_string;
    // Start is called before the first frame update
    void Start()
    {
        //english = true;
    }
	
	public void Title_go()
	{
		title_go.SetActive(false);
	}

    // Update is called once per frame
    public void Update()
    {
        if(english)
		{
			        title_string = "Velcome to King of Scrap";
			title_message_string = "In the game you will be the manager of a company for the separation and recycling of waste and the production of new products.";
		}
		if(slovak)
		{
			        title_string = "Vitaj v King of Scrap";
			title_message_string = "Ako manager firmy je tvojou úlohou triediť a recyklovať odpad z mesta a následne z neho vytvoriť nové produkty, ktoré predáš a tým zvýšiš svoje príjmi.";
			title_message_string += "Ak budeš mať 0 minci, stoje sa zastavia. Ak nebudeš mať na poplatky prehral si! Veľa štastia!";
	   title_BTN_continue_string = "Pokračovať";
			//"Vitaj v novej firme na separovanie, recykláciu odpadu a výrobu nových produktov. Ako manager firmy vybuduj velku vyrobu";
		}
		if(title_go.active)
		{
			      	 title.text = title_string;
		     title_message.text = title_message_string;
		title_BTN_continue.text = title_BTN_continue_string;
		}
    }
}
