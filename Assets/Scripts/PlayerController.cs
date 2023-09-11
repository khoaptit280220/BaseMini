using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10.0f;

    public float speedRotate = 10;
    public List<MeshRenderer> ListMeshRendererItem;

    private float horizontalInput;

    private float verticalInput;
    private DynamicJoystick dynamicJoystick => (PopupController.Instance.Get<PopupInGame>() as PopupInGame).DynamicJoystick;
    private Vector3 direction;
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        StartColor();
    }

    // Update is called once per frame
    void Update()
    {
        // horizontalInput = Input.GetAxis("Horizontal");
        // verticalInput = Input.GetAxis("Vertical");
        // transform.Translate(Vector3.forward * verticalInput * (Time.deltaTime * speed));
        // transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * speedRotate);
        if (GameManager.Instance.GameState == GameState.PlayingGame)
        {

            if (dynamicJoystick.Horizontal != 0 || dynamicJoystick.Vertical != 0)
            {
                direction = new Vector3(dynamicJoystick.Horizontal, 0.0f, dynamicJoystick.Vertical);
                Vector3 _rotation = new Vector3(0,
                    Mathf.Atan2(dynamicJoystick.Horizontal, dynamicJoystick.Vertical) * Mathf.Rad2Deg, 0);

                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_rotation),
                    speedRotate * Time.deltaTime);

                transform.position += direction * speed * Time.deltaTime;
            }

        }

    }

    public void SetColor(Color _color)
    {
        if (meshRenderer.material.color == _color)
        {
            Died();
        }
        else
        {
            meshRenderer.material.color = _color;
        }

    }

    private void Died()
    {
        GameManager.Instance.OnLoseGame(1);
    }

    private void StartColor()
    {
        int index = Random.Range(0, ListMeshRendererItem.Count);
        meshRenderer.material.color = ListMeshRendererItem[index].material.color;
    }
}
