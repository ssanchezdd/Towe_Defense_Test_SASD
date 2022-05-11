using UnityEngine;
using UnityEngine.EventSystems;

public class Node_S : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager_S buildManager_S;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager_S = BuildManager_S.instance;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (!buildManager_S.CanBuild)
            return;

        if (turret != null)
        {
            Debug.Log("Already build something here, can't build another thing instead");
            return;
        }

        buildManager_S.BuildTurretOn(this);

    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager_S.CanBuild)
            return;
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
