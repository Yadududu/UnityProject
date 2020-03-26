using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateView : MonoBehaviour {

    public InputField yearTxt;
    public InputField monthTxt;
    public InputField dayTxt;
    public Button selBtn;
    public GameObject popWindow;
    [Header("popWindow")]
    public Text display;
    public Button backBtn;
    public GameObject yearWindow;
    public Button[] yearBtn;
    public Button yearPreBtn;
    public Button yearNextBtn;
    public GameObject monthWindow;
    public Button[] monthBtn;
    public GameObject dayWindow;
    public Button[] dayBtn;

    private int _YearInit;
    private float _Year;
    private int _Month;
    private int _Day;

    private void Start() {
        Init();
    }
    private void Init() {
        _YearInit = DateModel.YearInit;
        display.text = "";
        backBtn.interactable = false;
        backBtn.onClick.AddListener(BackBtn);
        selBtn.onClick.AddListener(()=>popWindow.SetActive(true));
        yearPreBtn.onClick.AddListener(YearPreBtn);
        yearNextBtn.onClick.AddListener(YearNextBtn);

        for (int i = 0; i < yearBtn.Length; i++) {
            int num = _YearInit + i;
            yearBtn[i].GetComponentInChildren<Text>().text = num.ToString();
            yearBtn[i].onClick.AddListener(()=>YearBtn(num));
        }
        for (int i = 0; i < monthBtn.Length; i++) {
            int num = 1 + i;
            monthBtn[i].GetComponentInChildren<Text>().text = num.ToString();
            monthBtn[i].onClick.AddListener(()=>MonthBtn(num));
        }
        for (int i = 0; i < dayBtn.Length; i++) {
            int num = 1 + i;
            dayBtn[i].GetComponentInChildren<Text>().text = num.ToString();
            dayBtn[i].onClick.AddListener(() => DayBtn(num));
        }
    }
    private void YearBtn(int num) {
        yearWindow.SetActive(false);
        monthWindow.SetActive(true);
        backBtn.interactable = true;
        display.text = num.ToString();
        yearTxt.text = num.ToString();
        _Year = num;
    }
    private void MonthBtn(int num) {
        monthWindow.SetActive(false);
        dayWindow.SetActive(true);
        display.text = display.text + "-" + num;
        monthTxt.text = num.ToString();
        _Month = num;
        _Day = DateModel.GetDay(_Year, _Month);
        foreach (Button btn in dayBtn) {
            btn.gameObject.SetActive(false);
        }
        for (int i=0;i<_Day;i++) {
            dayBtn[i].gameObject.SetActive(true);
        }
    }
    private void DayBtn(int num) {
        dayWindow.SetActive(false);
        popWindow.SetActive(false);
        yearWindow.SetActive(true);
        backBtn.interactable = false;
        display.text = "";
        dayTxt.text = num.ToString();
    }
    private void YearPreBtn() {
        if (_YearInit <= DateModel.YearMin) return;
        _YearInit = _YearInit - 10;
        for (int i = 0; i < yearBtn.Length; i++) {
            int num = _YearInit + i;
            yearBtn[i].GetComponentInChildren<Text>().text = num.ToString();
            yearBtn[i].onClick.AddListener(() => YearBtn(num));
        }
    }
    private void YearNextBtn() {
        if (_YearInit >= DateModel.YearMax) return;
        _YearInit = _YearInit + 10;
        for (int i = 0; i < yearBtn.Length; i++) {
            int num = _YearInit + i;
            yearBtn[i].GetComponentInChildren<Text>().text = num.ToString();
            yearBtn[i].onClick.AddListener(() => YearBtn(num));
        }
    }
    private void BackBtn() {
        if (monthWindow.activeSelf) {
            yearWindow.SetActive(true);
            monthWindow.SetActive(false);
            backBtn.interactable = false;
            display.text = "";
        }
        if (dayWindow.activeSelf) {
            monthWindow.SetActive(true);
            dayWindow.SetActive(false);
            display.text = _Year.ToString();
        }
    }
}
