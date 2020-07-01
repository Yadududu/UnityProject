using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
public class LinqExample2 : MonoBehaviour {

    private Student[] students = new Student[]{
        new Student {stId = 1,stuName = "jack"},
        new Student {stId = 2,stuName = "taylor"},
        new Student {stId = 3,stuName = "fleming"}
    };
    private Course[] courses = new Course[]{
        new Course{stId = 1,courseName = "art"},
        new Course{stId = 2,courseName = "art"},
        new Course{stId = 1,courseName = "history"},
        new Course{stId = 3,courseName = "history"},
        new Course{stId = 3,courseName = "physics"},
    };

    public int[] groupA = { 1, 2, 3, 4, 5 };
    public int[] groupB = { 6, 7, 8, 9, 10 };

    private void OnEnable() {
        //join子句
        //var query = from s in students
        //            join c in courses on s.stId equals c.stId
        //            where c.courseName == "history"
        //            select s.stuName;

        //let子句
        //var query = from a in groupA
        //            from b in groupB
        //            let sum = a + b
        //            //where sum < 12
        //            select new { a, b, sum };

        //orderby子句
        //var query = from s in students
        //            join c in courses on s.stId equals c.stId
        //            where c.courseName == "history"
        //            orderby s.stuName  //排序
        //            select s.stuName;
        var query = students.SelectMany(c => courses, (s, c) => new { cid = c.stId, sId = s.stId, stuName = s.stuName, course = c.courseName })
                    .Where(x => x.cid == x.sId & x.course == "history")
                    .OrderBy(x => x.stuName)
                    .Select(x => x.stuName);

        //group子句
        //var query = from student in students
        //            group student by student.stId;
        //foreach (var s in query) {
        //    Debug.Log(s.Key);
        //    foreach (var t in s) {
        //        Debug.Log(t.stuName);
        //    }
        //}

        //into子句
        //var query = from student in students
        //            group student by student.stId into groupStId
        //            where groupStId.Key > 1
        //            select groupStId;
        //foreach (var str in query) {
        //    Debug.Log(str.Key);
        //}

        //联合查询
        //var query = from s in students
        //            from c in courses
        //            where s.stId == c.stId 
        //            //select s.stuName;
        //            select new { stId = s.stId, stuName = s.stuName, course = c.courseName };
        //var query = students.SelectMany(c => courses, (s, c) => new { cid = c.stId, sId = s.stId, stuName = s.stuName, course = c.courseName })
        //    .Where(x => x.cid == x.sId)
        //    .Select(x => new { stId = x.sId, stuName = x.stuName, course = x.course });

        foreach (var str in query) {
            Debug.Log(str);
        }
    }
}

public class Student {
    public int stId;
    public string stuName;
}
public class Course {
    public int stId;
    public string courseName;
}
