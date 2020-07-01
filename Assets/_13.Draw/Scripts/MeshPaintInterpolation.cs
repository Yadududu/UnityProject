using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RLD;

public class MeshPaintInterpolation : MonoBehaviour {

    public Material material;

    private List<GameObject> _Objs = new List<GameObject>();
    private List<GameObject> _Points = new List<GameObject>();
    private GameObject _parentObj;
    private Ray _ray;
    private RaycastHit _hit;
    private Vector3 _firstPoint;
    private Vector3 _lastPoint;
    private Vector3 _currentPoint;
    private bool _close;

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) & GetMouseHit() != null) {
            if (_parentObj == null) {
                _close = false;
                _firstPoint = GetMousePoint();
                CreatGameObject();
            }
            
            if (_lastPoint == Vector3.zero) _lastPoint = GetMousePoint();
            else _lastPoint = _currentPoint;
            _currentPoint = GetMousePoint();
            if (_lastPoint != _currentPoint) {
                Vector3 vct = Interpolation(_lastPoint, _currentPoint);
                CreatLineMesh(_lastPoint, vct);
                CreatSphereMesh(vct);
                CreatLineMesh(vct, _currentPoint);
                
            }
            CreatSphereMesh(GetMousePoint());
        }
    }
    void CreatGameObject() {
        _parentObj = new GameObject();
        _parentObj.transform.localEulerAngles = GetMouseHit().localEulerAngles;
        _parentObj.transform.SetParent(GetMouseHit());
        _Objs.Add(_parentObj);
    }
    MeshFilter GetMeshComponent() {
        GameObject _obj = new GameObject();
        _obj.transform.SetParent(_parentObj.transform);
        _Points.Add(_obj);

        MeshRenderer meshRenderer = _obj.AddComponent<MeshRenderer>();
        meshRenderer.material = material;
        MeshFilter meshFilter = _obj.AddComponent<MeshFilter>();

        return meshFilter;
    }
    void CreatSphereMesh(Vector3 position) {
        MeshFilter meshFilter = GetMeshComponent();
        meshFilter.transform.position = position;
        meshFilter.mesh = SphereMesh.CreateSphere(0.05f, 20, 20, Color.red);
    }
    void CreatLineMesh(Vector3 startPoint, Vector3 endPoint) {
        GetMeshComponent().mesh = LineMesh.CreateLine(startPoint, endPoint, Color.red);
    }
    Vector3 Interpolation(Vector3 startPoint, Vector3 endPoint) {
        Vector3 midPoint = new Vector3((startPoint.x + endPoint.x) / 2, (startPoint.y + endPoint.y) / 2, (startPoint.z + endPoint.z) / 2);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Camera.main.WorldToScreenPoint(midPoint));
        bool isCollider = Physics.Raycast(ray, out hit);
        return hit.point;
        //if (isCollider){
        //    CreatSphereMesh(hit.point);
        //}
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
            _lastPoint = Vector3.zero;
        }
    }
    public void BackoutPoint() {
        for (int i = 0; i < 2; i++) {
            if (_Points.Count != 0) {
                Destroy(_Points[_Points.Count - 1]);
                _Points.RemoveAt(_Points.Count - 1);
                if (_Points.Count == 0) {
                    _lastPoint = Vector3.zero;
                    Backout();
                }
            }
        }
    }
    public void CloseBtn() {
        if(!_close){
            _close = true;
            CreatLineMesh(_currentPoint, _firstPoint);
            _Points.Clear();
            _lastPoint = Vector3.zero;
            _parentObj = null;
        }
    }
}
