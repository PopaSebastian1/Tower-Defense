using UnityEngine;

public class PlaceTurretOnClick : MonoBehaviour
{
    public float placementRadius = 1f;
    private GameObject player;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {

        if (Input.GetMouseButton(0))
        {

            Vector3 clickPosition = GetMouseWorldPosition();
            if(clickPosition == Vector3.zero)
            {
                return;
            }

            if (!IsTurretPresentNearby(clickPosition))
            {
                if (player.GetComponent<PlayerScript>().GetMoney() >= BuildManager.instance.GetTurretToBuild().GetComponent<ITurretStats>().GetCost())
                {
                    player.GetComponent<PlayerScript>().RemoveMoney(100);
                    var turret = BuildManager.instance.GetTurretToBuild();
                    Instantiate(turret, clickPosition, Quaternion.identity);
                }
                else
                {
                    Debug.Log("Not enough money to place a turret.");
                }

            }
            else
            {
                Debug.Log("A turret is already placed nearby.");
            }
        }
    }


    private Vector3 GetMouseWorldPosition()
    {

        Vector3 mousePosition = Input.mousePosition;


        Ray ray = Camera.main.ScreenPointToRay(mousePosition);


        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Plane"))
            {
                return hit.point;

            }
        }

        return Vector3.zero;
    }


    private bool IsTurretPresentNearby(Vector3 position)
    {

        Collider[] colliders = Physics.OverlapSphere(position, placementRadius);


        foreach (Collider collider in colliders)
        {

            if (collider.CompareTag("Turret"))
            {
                return true;
            }
        }

        return false;
    }
}
