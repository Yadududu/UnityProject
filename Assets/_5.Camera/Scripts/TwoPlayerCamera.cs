using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerCamera : MonoBehaviour {

    public Transform[] targets;
    public float dampTime = 0.2f;                 // 相机重新对焦的大致时间。
    public float screenEdgeBuffer = 4f;           // 最上面/最下面的目标和屏幕边缘之间的空间。
    public float minSize = 6.5f;                  // 相机的最小正投影尺寸。

    private float m_ZoomSpeed;
    private Vector3 m_MoveVelocity;
    private Vector3 m_DesiredPosition;
    
    private void Update() {
        Move();
        Zoom();
    }

    private void Move() {
        FindAveragePosition();
        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, dampTime);
        
    }
    private void FindAveragePosition() {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;
        
        for (int i = 0; i < targets.Length; i++) {
            if (!targets[i].gameObject.activeSelf)
                continue;
            
            averagePos += targets[i].position;
            numTargets++;
        }
        if (numTargets > 0)
            averagePos /= numTargets;
        
        averagePos.y = transform.position.y;
        m_DesiredPosition = averagePos;
    }

    private void Zoom() {
        float requiredSize = FindRequiredSize();
        Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize, requiredSize, ref m_ZoomSpeed, dampTime);
    }
    private float FindRequiredSize() {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);
        float size = 0f;
        for (int i = 0; i < targets.Length; i++) {
            if (!targets[i].gameObject.activeSelf)
                continue;
            
            Vector3 targetLocalPos = transform.InverseTransformPoint(targets[i].position);
            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / Camera.main.aspect);
        }
        // 物体到屏幕边缘距离
        size += screenEdgeBuffer;
        size = Mathf.Max(size, minSize);
        return size;
    }
}
