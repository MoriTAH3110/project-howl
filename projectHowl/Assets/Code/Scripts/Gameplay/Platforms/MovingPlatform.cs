using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float _speed = 5.0f;

    
    private int _nextWaypointIndex = 0;
    private int _prevWaypointIndex = 0;
    private float _timeToWaypoint;
    private float _elapsedTime;

    void FixedUpdate() {
        Travel();
    }

    private void Start() {
        SetTimeToWaypoint();
    }

    private void Travel() {
        if (waypoints.Length <= 0) {
            return;
        }

        _elapsedTime += Time.deltaTime;

        float elapsedPercentage = (_elapsedTime / _timeToWaypoint);
        this.transform.position = Vector3.Lerp(GetWaypointPosition(_prevWaypointIndex), GetWaypointPosition(_nextWaypointIndex), elapsedPercentage);

        if (Vector3.Distance(transform.position, GetWaypointPosition(_nextWaypointIndex)) < 0.1f) {
            SetWaypointsIndexes();
            SetTimeToWaypoint();
        }
    }

    private void SetWaypointsIndexes() {
        _prevWaypointIndex = _nextWaypointIndex;

        if ( _nextWaypointIndex < (waypoints.Length - 1 )) {
            _nextWaypointIndex += 1;
        } else {
            _nextWaypointIndex = 0;
        }
    }

    private void SetTimeToWaypoint() {
        _elapsedTime = 0f;

        float distanceToNextWaypoint = Vector3.Distance(this.transform.position, GetWaypointPosition(_nextWaypointIndex));

        _timeToWaypoint = distanceToNextWaypoint / _speed;
    }

    private Vector3 GetWaypointPosition(int waypointIndex) {
        return waypoints[waypointIndex].transform.position;
    }

    //Move player with platform
      private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            other.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            other.transform.SetParent(null);
        }
    }
}
