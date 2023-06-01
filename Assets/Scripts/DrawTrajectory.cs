using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    [SerializeField]
    [Range(3, 30)] private int _lineSegmentCount = 20;
    private List<Vector3> _linePoints = new List<Vector3>();

    #region  Singleton 
    public static DrawTrajectory Instance;

    void Awake()
    {
        Instance = this;
    }

    #endregion

    public void UpdateTrajectroy(Vector3 forveVector, Rigidbody rigidbody, Vector3 startingPoint)
    {
        Vector3 velocity = (forveVector / rigidbody.mass) * Time.fixedDeltaTime;

        float FlightDuration = (2 * velocity.y) / Physics.gravity.y;
        
        float stepTime = FlightDuration / _lineSegmentCount;

        _linePoints.Clear();

        for (int i = 1; i < _lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime * i;

            Vector3 MovementVector = new Vector3(
                 x: velocity.x * stepTimePassed,
                 y: velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                 z: velocity.z * stepTimePassed);

            Vector3 NewPointOnLine = -MovementVector + startingPoint;
            _linePoints.Add(NewPointOnLine);

        }
        _lineRenderer.positionCount = _linePoints.Count;
        _lineRenderer.SetPositions(_linePoints.ToArray());
    }
    public void HideLine()
    {
        //_lineRenderer.positionCount = 0;
    }
}
