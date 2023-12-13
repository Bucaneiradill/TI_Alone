
using UnityEngine;
using UnityEngine.AI;

public class PreviewSystem : MonoBehaviour
{
    private GameObject previewObject;

    [SerializeField]
    private Material previewMaterialPrefab;
    private Material previewMaterialInstance;
    [SerializeField] LayerMask previewLayerMask;
    Renderer[] renderers;
    [HideInInspector] public bool placementAvailable;

    private void Start()
    {
        previewMaterialInstance = new Material(previewMaterialPrefab);
    }

    public void StartShowingPlacementPreview(GameObject prefab)
    {
        previewObject = Instantiate(prefab);
        if(previewObject.TryGetComponent(out NavMeshObstacle obstacle) == true)
        {
            obstacle.enabled = false;
        }
        previewObject.layer = LayerMask.NameToLayer("Preview");
        PreparePreview(previewObject);
    }

    private void PreparePreview(GameObject previewObject)
    {
        renderers = previewObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = previewMaterialInstance;
            }
            renderer.materials = materials;
        }
    }

    public void StopShowingPreview()
    {
        if (previewObject != null)
            Destroy(previewObject);
    }

    public void UpdatePosition(Vector3 position, bool validity)
    {
        if (previewObject != null)
        {
            MovePreview(position);
            //checar aqui se o previewObject está colidindo com algo
            bool isColliding = CheckCollision();
            placementAvailable = !isColliding;
            ApplyFeedbackToPreview(!isColliding);
        }
    }

    private bool CheckCollision()
    {
        // Inicializar o tamanho do objeto de preview
        Bounds bounds = new Bounds(previewObject.transform.position, Vector3.zero);

        // Calcular os limites combinados dos renderers
        foreach (Renderer renderer in renderers)
        {
            bounds.Encapsulate(renderer.bounds);
        }

        // Verificar colisões usando um cubo de colisão ao redor do objeto de preview
        Collider[] colliders = Physics.OverlapBox(bounds.center, bounds.extents, Quaternion.identity, previewLayerMask);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("Preview"))
            {
                Debug.Log(collider.gameObject.name);
                Physics.IgnoreCollision(previewObject.GetComponent<Collider>(), collider);
            }
            
        }
        
        // Se houver colisões, trate-as aqui
        if (colliders.Length > 0)
        {
            return true;
        }

        return false;
    }


    private void ApplyFeedbackToPreview(bool validity)
    {
        Color c = validity ? Color.white : Color.red;
        c.a = 0.5f;
        previewMaterialInstance.color = c;
    }

    private void MovePreview(Vector3 position)
    {
        previewObject.transform.position = position;
    }
}