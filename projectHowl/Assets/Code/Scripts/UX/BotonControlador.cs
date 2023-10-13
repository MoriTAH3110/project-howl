using UnityEngine;
using UnityEngine.UI;

public class BotonControlador : MonoBehaviour
{
    public Button boton; // Referencia al componente Button
    public GameObject Engranaje1;
    public GameObject Engranaje2;

    private void Start()
    {
        // Asigna el método ResetearBoton al evento de clic del botón
        boton.onClick.AddListener(ResetearBoton);
    }

    private void ResetearBoton()
    {
        Engranaje1.transform.localScale = new Vector3(0, 0, 0);
        Engranaje2.transform.localScale = new Vector3(0, 0, 0);
        // Puedes agregar más acciones según tus necesidades
    }
}