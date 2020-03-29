using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class asUIPanel {   
	public InputField Year_input;
	public InputField Month_input;
	public InputField Day_input;
	public Button Sel_btn;
	public GameObject PopWindow_go;
	public Text Display_txt;
	public Button Back_btn;
	public GameObject YearWin_go;
	public List<Button> Year_btns = new List<Button>();
	public Button Pre_btn;
	public Button Next_btn;
	public GameObject MonthWin_go;
	public List<Button> Month_btns = new List<Button>();
	public GameObject DayWin_go;
	public List<Button> Day_btns = new List<Button>();


    public void OnAwake(GameObject viewGO){
		Year_input = viewGO.transform.Find("Background/Year_input").GetComponent<InputField>();
		Month_input = viewGO.transform.Find("Background/Month_input").GetComponent<InputField>();
		Day_input = viewGO.transform.Find("Background/Day_input").GetComponent<InputField>();
		Sel_btn = viewGO.transform.Find("Sel_btn").GetComponent<Button>();
		PopWindow_go = viewGO.transform.Find("PopWindow_go").gameObject;
		Display_txt = viewGO.transform.Find("PopWindow_go/Display_txt").GetComponent<Text>();
		Back_btn = viewGO.transform.Find("PopWindow_go/Back_btn").GetComponent<Button>();
		YearWin_go = viewGO.transform.Find("PopWindow_go/YearWin_go").gameObject;
		Year_btns.Add(viewGO.transform.Find("PopWindow_go/YearWin_go/Year/Year_btn (1)").GetComponent<Button>());
		Year_btns.Add(viewGO.transform.Find("PopWindow_go/YearWin_go/Year/Year_btn (2)").GetComponent<Button>());
		Year_btns.Add(viewGO.transform.Find("PopWindow_go/YearWin_go/Year/Year_btn (3)").GetComponent<Button>());
		Year_btns.Add(viewGO.transform.Find("PopWindow_go/YearWin_go/Year/Year_btn (4)").GetComponent<Button>());
		Year_btns.Add(viewGO.transform.Find("PopWindow_go/YearWin_go/Year/Year_btn (5)").GetComponent<Button>());
		Year_btns.Add(viewGO.transform.Find("PopWindow_go/YearWin_go/Year/Year_btn (6)").GetComponent<Button>());
		Year_btns.Add(viewGO.transform.Find("PopWindow_go/YearWin_go/Year/Year_btn (7)").GetComponent<Button>());
		Year_btns.Add(viewGO.transform.Find("PopWindow_go/YearWin_go/Year/Year_btn (8)").GetComponent<Button>());
		Year_btns.Add(viewGO.transform.Find("PopWindow_go/YearWin_go/Year/Year_btn (9)").GetComponent<Button>());
		Year_btns.Add(viewGO.transform.Find("PopWindow_go/YearWin_go/Year/Year_btn (10)").GetComponent<Button>());
		Pre_btn = viewGO.transform.Find("PopWindow_go/YearWin_go/Pre_btn").GetComponent<Button>();
		Next_btn = viewGO.transform.Find("PopWindow_go/YearWin_go/Next_btn").GetComponent<Button>();
		MonthWin_go = viewGO.transform.Find("PopWindow_go/MonthWin_go").gameObject;
		Month_btns.Add(viewGO.transform.Find("PopWindow_go/MonthWin_go/Month_btn (1)").GetComponent<Button>());
		Month_btns.Add(viewGO.transform.Find("PopWindow_go/MonthWin_go/Month_btn (2)").GetComponent<Button>());
		Month_btns.Add(viewGO.transform.Find("PopWindow_go/MonthWin_go/Month_btn (3)").GetComponent<Button>());
		Month_btns.Add(viewGO.transform.Find("PopWindow_go/MonthWin_go/Month_btn (4)").GetComponent<Button>());
		Month_btns.Add(viewGO.transform.Find("PopWindow_go/MonthWin_go/Month_btn (5)").GetComponent<Button>());
		Month_btns.Add(viewGO.transform.Find("PopWindow_go/MonthWin_go/Month_btn (6)").GetComponent<Button>());
		Month_btns.Add(viewGO.transform.Find("PopWindow_go/MonthWin_go/Month_btn (7)").GetComponent<Button>());
		Month_btns.Add(viewGO.transform.Find("PopWindow_go/MonthWin_go/Month_btn (8)").GetComponent<Button>());
		Month_btns.Add(viewGO.transform.Find("PopWindow_go/MonthWin_go/Month_btn (9)").GetComponent<Button>());
		Month_btns.Add(viewGO.transform.Find("PopWindow_go/MonthWin_go/Month_btn (10)").GetComponent<Button>());
		Month_btns.Add(viewGO.transform.Find("PopWindow_go/MonthWin_go/Month_btn (11)").GetComponent<Button>());
		Month_btns.Add(viewGO.transform.Find("PopWindow_go/MonthWin_go/Month_btn (12)").GetComponent<Button>());
		DayWin_go = viewGO.transform.Find("PopWindow_go/DayWin_go").gameObject;
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (1)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (2)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (3)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (4)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (5)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (6)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (7)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (8)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (9)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (10)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (11)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (12)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (13)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (14)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (15)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (16)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (17)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (18)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (19)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (20)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (21)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (22)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (23)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (24)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (25)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (26)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (27)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (28)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (29)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (30)").GetComponent<Button>());
		Day_btns.Add(viewGO.transform.Find("PopWindow_go/DayWin_go/Day_btn (31)").GetComponent<Button>());

    }

    public void OnDestroy(){
		Year_input = null;
		Month_input = null;
		Day_input = null;
		Sel_btn = null;
		PopWindow_go = null;
		Display_txt = null;
		Back_btn = null;
		YearWin_go = null;
		Year_btns = null;
		Pre_btn = null;
		Next_btn = null;
		MonthWin_go = null;
		Month_btns = null;
		DayWin_go = null;
		Day_btns = null;

    }
}