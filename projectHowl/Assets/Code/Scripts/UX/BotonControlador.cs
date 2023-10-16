using UnityEngine;
using UnityEngine.UI;

public class BotonControlador : MonoBehaviour
{
    public Button boton; // Referencia al componente Button
    public GameObject Engranaje1;
    public GameObject Engranaje2;

    private void Start()
    {
        // Asigna el m�todo ResetearBoton al evento de clic del bot�n
        boton.onClick.AddListener(ResetearBoton);
    }

    private void ResetearBoton()
    {
        Engranaje1.transform.localScale = new Vector3(0, 0, 0);
        Engranaje2.transform.localScale = new Vector3(0, 0, 0);
        // Puedes agregar m�s acciones seg�n tus necesidades
        Debug.Log("Resetting");
    }
}