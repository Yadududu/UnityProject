using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bbUIPanel : MonoBehaviour{   
    //--AutoCreateStart
	public InputField Year_input;
	public InputField Month_input;
	public InputField Day_input;
	public Button Sel_btn;
	public GameObject PopWin_go;
	public Text Display_txt;
	public Button Back_btn;
	public List<GameObject> Win_gos = new List<GameObject>();
	public List<Button> Year_btns = new List<Button>();
	public Button Pre_btn;
	public Button Next_btn;
	public List<Button> Month_btns = new List<Button>();
	public List<Button> Day_btns = new List<Button>();

    //--AutoCreateEnd

    public void Awake(){

    }

    public void Start(){

    }
}