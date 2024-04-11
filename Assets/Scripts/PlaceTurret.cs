using UnityEngine;

public class PlaceTurretOnClick : MonoBehaviour
{
    public GameObject turretPrefab; // Prefab-ul turetei
    public float placementRadius = 1f; // Raza în care se verifică dacă există alte turete
    private GameObject player;
    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        // Verificați dacă utilizatorul face clic cu butonul stâng al mouse-ului
        if (Input.GetMouseButtonDown(0))
        {
            // Obțineți poziția clicului în spațiul lumii
            Vector3 clickPosition = GetMouseWorldPosition();

            if (!IsTurretPresentNearby(clickPosition))
            {
                if (player.GetComponent<PlayerScript>().GetMoney() >= 100)
                {
                    player.GetComponent<PlayerScript>().RemoveMoney(100);
                    Instantiate(turretPrefab, clickPosition, Quaternion.identity);
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

    // Funcție pentru a obține poziția clicului în spațiul lumii
    private Vector3 GetMouseWorldPosition()
    {
        // Obțineți poziția clicului pe ecran
        Vector3 mousePosition = Input.mousePosition;

        // Convertiți poziția clicului pe ecran într-un ray în spațiul lumii
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        // Lansați ray-ul în scenă și obțineți informații despre punctul de impact
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Returnați poziția punctului de impact
            return hit.point;
        }

        // Dacă nu a fost lovit niciun obiect, returnați Vector3.zero
        return Vector3.zero;
    }

    // Funcție pentru a verifica dacă există o turetă în apropierea unei anumite poziții
    private bool IsTurretPresentNearby(Vector3 position)
    {
        // Creați o sferă de suprapunere pentru a verifica dacă există alte obiecte în apropiere
        Collider[] colliders = Physics.OverlapSphere(position, placementRadius);

        // Parcurgeți toate obiectele suprapuse
        foreach (Collider collider in colliders)
        {
            // Verificați dacă obiectul suprapus este o turetă
            if (collider.CompareTag("Turret"))
            {
                return true; // Există deja o turetă în apropiere
            }
        }

        return false; // Nu există alte turete în apropiere
    }
}
