using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private int _waypointIndex = 0;

    void FixedUpdate() {
        Travel();
    }

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

    private void Travel() {
        if (waypoints.Length <= 0) {
            return;
        }

        Vector3 moveDirection = waypoints[_waypointIndex].position - transform.position;

        transform.Translate(moveDirection * _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[_waypointIndex].position) < 0.1f) {
            NextWaypointIndex();
        }
    }

    private void NextWaypointIndex() {
        if ( _waypointIndex < (waypoints.Length - 1 )) {
            _waypointIndex += 1;
        } else {
            _waypointIndex = 0;
        }
    }
}
