using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using RLD;

public class MyPaint : MonoBehaviour {

    public LayerMask DrawLayer;
    public Color paintColor = Color.red;
    public float paintSize = 0.1f;
    public Material lineMaterial;

    private LineRenderer currentLine;
    private List<Vector3> positions = new List<Vector3>();
    private bool isMouseDown = false;
    private Vector3 lastMousePostion = Vector3.zero;
    private float lineDistance = 0.02f;
    private List<GameObject> _Objs = new List<GameObject>();
    private Ray _ray;
    private RaycastHit _hit;

    // Use this for initialization
    void Start() {
        CreatMeshTest();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) & GetMouseHit()!=null) {
            CreatBrush();
            currentLine.material = lineMaterial;
            currentLine.startWidth = paintSize;
            currentLine.endWidth = paintSize;
            currentLine.shadowCastingMode = ShadowCastingMode.Off;
            currentLine.receiveShadows = false;
            //currentLine.startColor = paintColor;
            //currentLine.endColor = paintColor;
            currentLine.numCornerVertices = 5;
            currentLine.numCapVertices = 5;
            Vector3 position = GetMousePoint();

            AddPosition(position);
            isMouseDown = true;
            lineDistance += 0.1f;
        }

        if (isMouseDown) {
            Vector3 position = GetMousePoint();
            if (Vector3.Distance(position, lastMousePostion) > 0.1f & position != Vector3.zero)
                AddPosition(position);
        }

        if (Input.GetMouseButtonUp(0)) {
            currentLine = null;
            //positions.Clear();
            isMouseDown = false;
        }

    }
    void AddPosition(Vector3 position) {
        position.z -= lineDistance;
        positions.Add(position);
        currentLine.positionCount = positions.Count;
        currentLine.SetPositions(positions.ToArray());
        lastMousePostion = position;
    }
    void CreatBrush() {
        if (GetMouseHit() != null) {
            GameObject go = new GameObject();
            go.transform.SetParent(GetMouseHit());
            currentLine = go.AddComponent<LineRenderer>();
            _Objs.Add(go.gameObject);
        }
    }
    Vector3 GetMousePoint() {
        if (GetMouseHit()!=null) {
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
    public void CreatMesh() {
        MeshFilter meshFilter = (MeshFilter)GameObject.Find("face").GetComponent(typeof(MeshFilter));
        Mesh mesh = meshFilter.mesh;
        Vector3[] vertices = new Vector3[positions.Count];
        int[] triangles = new int[(positions.Count - 2) * 3];

        vertices = positions.ToArray();
        mesh.vertices = vertices;

        int start = 0;

        int end = positions.Count-2;

        //for (int i = start; i < end; i++) {
        //    for (int j = 0; j < 3; j++) {
        //        if (i % 2 == 0) {
        //            triangles[3 * i + j] = i + j;
        //        } else {
        //            triangles[3 * i + j] = i + 2 - j;
        //        }

        //    }
        //}
        //meshFilter.mesh = LineMesh.CreateLine(vertices[0], vertices[vertices.Length-1], Color.red);
        //meshFilter.mesh = LineMesh.CreateCoordSystemAxesLines(1, Color.red);
        //meshFilter.mesh = BoxMesh.CreateWireBox(1, 1, 1, Color.red);
        meshFilter.mesh = CircleMesh.CreateCircleXY(2, 5, Color.red);

        mesh.triangles = triangles;
    }
    public void CreatMeshTest() {
        MeshFilter meshFilter = (MeshFilter)GameObject.Find("face").GetComponent(typeof(MeshFilter));

        meshFilter.mesh = LineMesh.CreateCoordSystemAxesLines(1, Color.red);
        //meshFilter.mesh = LineMesh.CreateLine(vertices[0], vertices[vertices.Length-1], Color.red);
        //meshFilter.mesh = LineMesh.CreateCoordSystemAxesLines(1, Color.red);
        //meshFilter.mesh = BoxMesh.CreateWireBox(1, 1, 1, Color.red);

        //meshFilter.mesh = QuadMesh.CreateQuadXY(1, 1, Color.red);
        //meshFilter.mesh = SphereMesh.CreateSphere(0.1f, 50, 20, Color.red);
    }
}
