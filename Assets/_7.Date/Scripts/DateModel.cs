using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateModel : MonoBehaviour {

    public static DateModel Get { get; private set; }
    public const int YearInit = 2020;
    public const int YearMax = 2990;
    public const int YearMin = 0;

    private DateModel() {
        Get = this;
    }

    public int GetDay(float year, int month) {
        int day = 0;
        bool isLeapYear = false;
        if (year % 100 == 0) {
            if (year % 400 == 0) {
                isLeapYear = true;
            }
        } else if (year % 4 == 0) {
            isLeapYear = true;
        } else {
            isLeapYear = false;
        }
        switch (month) {
            case 1:
                day = 31;
                break;
            case 2:
                if (isLeapYear) day = 29;
                else day = 28;
                break;
            case 3:
                day = 31;
                break;
            case 4:
                day = 30;
                break;
            case 5:
                day = 31;
                break;
            case 6:
                day = 30;
                break;
            case 7:
                day = 31;
                break;
            case 8:
                day = 31;
                break;
            case 9:
                day = 30;
                break;
            case 10:
                day = 31;
                break;
            case 11:
                day = 30;
                break;
            case 12:
                day = 31;
                break;
        }
        return day;
    }
}
