using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MongoDB.Driver;
using System;
using MongoDB.Bson;
using UnityEngine.Networking;
using System.Text;
using SimpleJSON;

public class Login : MonoBehaviour
{
    public InputField campoUsuario;
    public InputField campoContrasena;

    public TMP_Text label;
    public TMP_Text labelTitulo;
    public TMP_Text labelMensaje;

    public GameObject login;
    public GameObject home;
    public GameObject notificacion;
    public GameObject ranking;

    public string backendURL = "https://invacioncaninaback.onrender.com";

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuInicio()
    {
        SceneManager.LoadScene(0);
    }

    public void ImprimirValores()
    {
        string valorCampo2 = campoUsuario.text;
        string valorCampo3 = campoContrasena.text;
        StartCoroutine(LoginRequest(valorCampo2, valorCampo3));

        Debug.Log("Valor del campo 2: " + valorCampo2);
        Debug.Log("Valor del campo 3: " + valorCampo3);

    }

    IEnumerator LoginRequest(string usuario, string contrasena)
    {
        // Crear un objeto Dictionary para los datos de inicio de sesión
        Dictionary<string, string> loginData = new Dictionary<string, string>
        {
            { "Usuario", usuario },
            { "Contrasena", contrasena }
        };

        // Convertir el objeto Dictionary a formato JSON
        string jsonData = JsonUtility.ToJson(loginData);

        using (UnityWebRequest request = new UnityWebRequest(backendURL + "/login", "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error en la solicitud: " + request.error);
                if (notificacion != null)
                {
                    labelTitulo.text = "Inicio de Sesion Fallido";
                    labelMensaje.text = "Lo sentimos, no hemos podido iniciar sesión con las credenciales proporcionadas. Verifica tu usuario y contraseña e intenta nuevamente. ";
                    notificacion.SetActive(true);

                }
            }
            else
            {
                string jsonRecibidoDelBackend = request.downloadHandler.text;

                ContenedorObjetos contenedor = JsonUtility.FromJson<ContenedorObjetos>(jsonRecibidoDelBackend);

                // Acceder al array de objetos dentro del contenedor
                UserResponse[] objetos = contenedor.objetos;

                // Ahora puedes usar los objetos en Unity
                foreach (UserResponse obj in objetos)
                {
                    Debug.Log("Nombre: " + obj._id + ", Valor: " + obj.Usuario);
                    // Hacer algo con estos objetos, como instanciarlos en escena, modificar propiedades, etc.
                }
                //if (users != null && users.Length > 0)
                //{
                //    string idUsuario = users[0]._id;
                //    string usuarioN = users[0].Usuario;

                //    Debug.Log("ID de usuario: " + idUsuario);
                //    Debug.Log("Usuario: " + usuarioN);
                //    PlayerPrefs.SetString("idUsuario", idUsuario);
                //    PlayerPrefs.SetString("usuario", usuarioN);
                //    //Debug.Log("ID del documento insertado: " + idUsuario);
                //    ControllerUser.Instance.InicioSession(idUsuario, usuarioN);
                //    if (home != null && login != null && ranking != null)
                //    {
                //        home.SetActive(true);
                //        ranking.SetActive(true);
                //        login.SetActive(false);
                //    }

                //    if (notificacion != null)
                //    {
                //        labelTitulo.text = $"Hola {usuarioN}!";
                //        labelMensaje.text = "Bienvenido de nuevo. Estamos encantados de verte. ¡Disfruta de tu experiencia en el juego!";
                //        notificacion.SetActive(true);
                //    }
                //    label.text = $"Hola {usuarioN} !";
                //}
                //else
                //{
                //    Debug.LogError("La respuesta del servidor está vacía o no tiene el formato esperado.");
                //}

            }
        }
    }
}
[System.Serializable]
public class UserResponse
{
    public string _id;
    public string Usuario;
}

[System.Serializable]
public class ContenedorObjetos
{
    public UserResponse[] objetos;
}
