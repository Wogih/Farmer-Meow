using Unity.VisualScripting;
using UnityEngine;

public class Move_camera_to_player : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float move_speed;

    void FixedUpdate()
    {
        Vector3 new_position = Vector3.Lerp(transform.position, new Vector3(player.position.x, player.position.y, -10), move_speed * Time.fixedDeltaTime);
        transform.position = new_position;
    }
}
