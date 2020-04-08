using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CreateUIScript {
    public class CreateSpriteWin : EditorWindow {

        private string _ClassName = "";
        private string _Path = "Assets/Scripts/UI";
        private static CreateSpriteWin _Window;
        //当前选择得GameObject
        private static GameObject[] _GameObjects;

        [MenuItem("GameObject/Zeus/创建脚本", false, 0)]
        public static void ShowMyWindow() {
            _GameObjects = Selection.gameObjects;
            //保证只有一个对象
            if (_GameObjects.Length == 1) {
                _Window = EditorWindow.GetWindow<CreateSpriteWin>();
                _Window.Show();
            } else {
                EditorUtility.DisplayDialog("警告", "你只能选择一个GameObject", "确定");
            }
        }

        private void OnGUI() {
            _ClassName = EditorGUILayout.TextField("脚本前缀名:", _ClassName);

            ////获得一个长300的框
            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Width(Screen.width - 7));
            //将上面的框作为文本输入框
            _Path = EditorGUI.TextField(rect, "保存路径:", _Path);

            //如果鼠标正在拖拽中或拖拽结束时，并且鼠标所在位置在文本输入框内
            if ((Event.current.type == UnityEngine.EventType.DragUpdated
              || Event.current.type == UnityEngine.EventType.DragExited)
              && rect.Contains(Event.current.mousePosition)) {
                //改变鼠标的外表
                DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0) {
                    _Path = DragAndDrop.paths[0];
                }
            }

            if (GUILayout.Button("选择路径", GUILayout.Width(100))) {
                _Path = EditorUtility.SaveFilePanelInProject("选择路径", _ClassName, "", "");
            }

            if (GUILayout.Button("创建脚本")) {
                if (_ClassName != "") {
                    CreateSprite.CreateScript(_GameObjects[0], _ClassName, _Path);
                    _Window.Close();
                } else {
                    EditorUtility.DisplayDialog("警告", "名字不能为空!", "确定");
                }

            }
        }
    }

}
