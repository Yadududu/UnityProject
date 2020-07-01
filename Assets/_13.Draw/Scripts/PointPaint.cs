using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PointPaint : MonoBehaviour {

    public LayerMask DrawLayer;
    public Color paintColor = Color.red;
    public float paintSize = 0.1f;
    public Material lineMaterial;

    private LineRenderer currentLine;
    private float lineDistance = 0.02f;
    private List<Vector3> positions = new List<Vector3>();
    private List<GameObject> _Objs = new List<GameObject>();
    private Ray _ray;
    private RaycastHit _hit;
    private bool _close = true;
    private Vector3 _recordFirstPoint;
    private Vector3 _lastPaint;
    private Vector3 _currentPosition;
    Vector3 position = new Vector3(800, 400, 0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) & GetMouseHit() != null) {
            CreatBrush();
            if (_currentPosition != null) _lastPaint = _currentPosition; 
            _currentPosition = GetMousePoint();

            position = new Vector3((_lastPaint.x + _currentPosition.x) / 2, (_lastPaint.y + _currentPosition.y) / 2, (_lastPaint.z + _currentPosition.z) / 2);

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Camera.main.WorldToScreenPoint(position));
            if (Physics.Raycast(ray, out hit)) {
                Debug.Log(_currentPosition);
                Debug.Log(hit.transform);
                Debug.Log(hit.point);
                Debug.Log(position);
                position = hit.point;
                //Vector3 v3 = position;
                //v3.z = 0;
                //position = v3;
                Debug.Log(position);
                Debug.DrawLine(ray.origin, hit.point, Color.black);
            }

            AddPosition(position);
            AddPosition(_currentPosition);
        }

	}
    void AddPosition(Vector3 position) {
        position.z -= lineDistance;
        positions.Add(position);
        currentLine.positionCount = positions.Count;
        currentLine.SetPositions(positions.ToArray());
    }
    void CreatBrush() {
        if (GetMouseHit() != null & _close) {
            _close = false;
            GameObject go = new GameObject();
            go.transform.SetParent(GetMouseHit());
            currentLine = go.AddComponent<LineRenderer>();
            _Objs.Add(go.gameObject);

            currentLine.material = lineMaterial;
            currentLine.startWidth = paintSize;
            currentLine.endWidth = paintSize;
            currentLine.shadowCastingMode = ShadowCastingMode.Off;
            currentLine.receiveShadows = false;
            //currentLine.startColor = paintColor;
            //currentLine.endColor = paintColor;
            currentLine.numCornerVertices = 5;
            currentLine.numCapVertices = 5;

            _recordFirstPoint = GetMousePoint();
            _currentPosition = GetMousePoint();
            AddPosition(_currentPosition);
        }
    }
    Vector3 GetMousePoint() {

        if (GetMouseHit() != null) {
            Debug.DrawLine(_ray.origin, _hit.point, Color.red);
            return _hit.point;
        }
        return Vector3.zero;
    }
    Transform GetMouseHit() {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isCollider = Physics.Raycast(_ray, out _hit);
        if (isCollider) return _hit.transform;
        else return null;
    }
    public void Backout() {
        if (_Objs.Count != 0) {
            Destroy(_Objs[_Objs.Count - 1]);
            _Objs.RemoveAt(_Objs.Count - 1);
        }
    }
    public void BackoutPoint() {
        if (positions.Count != 0) {
            positions.RemoveAt(positions.Count - 1);
            currentLine.positionCount = positions.Count;
            currentLine.SetPositions(positions.ToArray());
        }
    }
    public void CloseBtn() {
        if (!_close) {
            _close = true;
            AddPosition(_recordFirstPoint);
            currentLine = null;
            positions.Clear();
        }
    }
}
