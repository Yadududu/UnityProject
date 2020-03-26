using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateViewTestAutoGetUI : MonoBehaviour {
    
    private int _YearInit;
    private float _Year;
    private int _Month;
    private int _Day;
    private CanvasUIPanel _GetUI = new CanvasUIPanel();

    private void Start() {
        _GetUI.OnAwake(gameObject);
        Init();
    }
    private void Init() {
        _YearInit = DateModel.YearInit;
        _GetUI.Display_txt.text = "";
        _GetUI.Back_btn.interactable = false;
        _GetUI.Back_btn.onClick.AddListener(BackBtn);
        _GetUI.Sel_btn.onClick.AddListener(() => _GetUI.PopWindow_go.SetActive(true));
        _GetUI.Pre_btn.onClick.AddListener(YearPreBtn);
        _GetUI.Next_btn.onClick.AddListener(YearNextBtn);

        for (int i = 0; i < _GetUI.Year_btns.Count; i++) {
            int num = _YearInit + i;
            _GetUI.Year_btns[i].GetComponentInChildren<Text>().text = num.ToString();
            _GetUI.Year_btns[i].onClick.AddListener(() => YearBtn(num));
        }
        for (int i = 0; i < _GetUI.Month_btns.Count; i++) {
            int num = 1 + i;
            _GetUI.Month_btns[i].GetComponentInChildren<Text>().text = num.ToString();
            _GetUI.Month_btns[i].onClick.AddListener(() => MonthBtn(num));
        }
        for (int i = 0; i < _GetUI.Day_btns.Count; i++) {
            int num = 1 + i;
            _GetUI.Day_btns[i].GetComponentInChildren<Text>().text = num.ToString();
            _GetUI.Day_btns[i].onClick.AddListener(() => DayBtn(num));
        }
    }
    private void YearBtn(int num) {
        _GetUI.YearWin_go.SetActive(false);
        _GetUI.MonthWin_go.SetActive(true);
        _GetUI.Back_btn.interactable = true;
        _GetUI.Display_txt.text = num.ToString();
        _GetUI.Year_input.text = num.ToString();
        _Year = num;
    }
    private void MonthBtn(int num) {
        _GetUI.MonthWin_go.SetActive(false);
        _GetUI.DayWin_go.SetActive(true);
        _GetUI.Display_txt.text = _GetUI.Display_txt.text + "-" + num;
        _GetUI.Month_input.text = num.ToString();
        _Month = num;
        _Day = DateModel.GetDay(_Year, _Month);
        foreach (Button btn in _GetUI.Day_btns) {
            btn.gameObject.SetActive(false);
        }
        for (int i = 0; i < _Day; i++) {
            _GetUI.Day_btns[i].gameObject.SetActive(true);
        }
    }
    private void DayBtn(int num) {
        _GetUI.DayWin_go.SetActive(false);
        _GetUI.PopWindow_go.SetActive(false);
        _GetUI.YearWin_go.SetActive(true);
        _GetUI.Back_btn.interactable = false;
        _GetUI.Display_txt.text = "";
        _GetUI.Day_input.text = num.ToString();
    }
    private void YearPreBtn() {
        if (_YearInit <= DateModel.YearMin) return;
        _YearInit = _YearInit - 10;
        for (int i = 0; i < _GetUI.Year_btns.Count; i++) {
            int num = _YearInit + i;
            _GetUI.Year_btns[i].GetComponentInChildren<Text>().text = num.ToString();
            _GetUI.Year_btns[i].onClick.AddListener(() => YearBtn(num));
        }
    }
    private void YearNextBtn() {
        if (_YearInit >= DateModel.YearMax) return;
        _YearInit = _YearInit + 10;
        for (int i = 0; i < _GetUI.Year_btns.Count; i++) {
            int num = _YearInit + i;
            _GetUI.Year_btns[i].GetComponentInChildren<Text>().text = num.ToString();
            _GetUI.Year_btns[i].onClick.AddListener(() => YearBtn(num));
        }
    }
    private void BackBtn() {
        if (_GetUI.MonthWin_go.activeSelf) {
            _GetUI.YearWin_go.SetActive(true);
            _GetUI.MonthWin_go.SetActive(false);
            _GetUI.Back_btn.interactable = false;
            _GetUI.Display_txt.text = "";
        }
        if (_GetUI.DayWin_go.activeSelf) {
            _GetUI.MonthWin_go.SetActive(true);
            _GetUI.DayWin_go.SetActive(false);
            _GetUI.Display_txt.text = _Year.ToString();
        }
    }
}
