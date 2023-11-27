using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class MenuInicial : MonoBehaviour
{
    public GameObject niveles;
    public GameObject home;
    public GameObject notificacion;
    public GameObject login;
    public GameObject register;
    public GameObject ranking;
    public GameObject btnranking;

    public TMP_Text labelTitulo;
    public TMP_Text labelMensaje;

    public RowUi rowUi;
    public GameObject tableContainer;

    Color colorCase1 = new Color(1f, 0.823f, 0f); // Color hexadecimal: #FFD200
    Color colorCase2 = new Color(0.776f, 0.776f, 0.776f); // Color hexadecimal: #C6C6C6
    Color colorCase3 = new Color(0.715f, 0.435f, 0.337f); // Color hexadecimal: #B76F56
    void Start()
    {
        if (PlayerPrefs.HasKey("idUsuario"))
        {
            if (btnranking != null)
            {
                btnranking.SetActive(false);
            }
        }
        else
        {
            if (btnranking != null)
            {
                btnranking.SetActive(true);
            }
        }

    }

    void Update()
    {
        if (PlayerPrefs.HasKey("idUsuario"))
        {
            if (btnranking != null)
            {
                btnranking.SetActive(true);
            }
        }
        else
        {
            if (btnranking != null)
            {
                btnranking.SetActive(false);
            }
        }
    }
    public void Jugar(int index)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }

    public void Niveles()
    {
        if (PlayerPrefs.HasKey("idUsuario"))
        {
            // El valor existe, puedes recuperarlo
            //string idUsuario = PlayerPrefs.GetString("idUsuario");
            if (home != null && niveles != null) {
                niveles.SetActive(true);
                home.SetActive(false);
            }
        }
        else
        {
            // El valor no existe o no se ha guardado todavía
            if (notificacion != null)
            {
                labelTitulo.text = "Accede para jugar";
                labelMensaje.text = "Por favor, inicia sesión para acceder a todos nuestros niveles y disfrutar al máximo de la experiencia de juego.";
                notificacion.SetActive(true);

            }
        }
    }

    public void Login()
    {
        if (PlayerPrefs.HasKey("idUsuario"))
        {
            if (notificacion != null)
            {
                labelTitulo.text = "Sesion Activa";
                labelMensaje.text = "Ya estás autenticado. Si deseas iniciar sesión con otra cuenta, por favor, cierra la sesión actual primero.";
                notificacion.SetActive(true);

            }

        }
        else
        {
            if (home != null && login != null)
            {
                login.SetActive(true);
                home.SetActive(false);
            }

        }
    }

    public void Register()
    {
        if (PlayerPrefs.HasKey("idUsuario"))
        {
            if (notificacion != null)
            {
                labelTitulo.text = "Sesion Activa";
                labelMensaje.text = "Ya estás autenticado. Si deseas crear una nueva cuenta, por favor, cierra la sesión actual primero.";
                notificacion.SetActive(true);
            }

        }
        else
        {
            if (home != null && register != null)
            {
                register.SetActive(true);
                home.SetActive(false);
            }

        }
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        PlayerPrefs.DeleteKey("idUsuario");
        Application.Quit();
    }
    public void Ranking()
    {

        ranking.SetActive(true);
        home.SetActive(false);

        ConexionBD conexion = new ConexionBD();
        var coleccion = conexion.ConexionMongo2();

        var filtro = Builders<BsonDocument>.Filter.Empty;
        var usuariosTopScore = coleccion.Find(filtro)
            .Sort(Builders<BsonDocument>.Sort.Descending("score"))
            .Limit(10)
            .ToList();

        if (usuariosTopScore != null && usuariosTopScore.Any())
        {
            DeleteAllChildren();
            int position = 0;
            foreach (var usuario in usuariosTopScore)
            {
                var row = Instantiate(rowUi, tableContainer.transform).GetComponent<RowUi>();
                position += 1;
                var score = usuario["score"].ToString();
                var name = usuario["user"].ToString();

                string rankString;
                switch (position)
                {
                    default:
                        rankString = position.ToString() + "TH"; break;

                    case 1: rankString = "1ST"; break;
                    case 2: rankString = "2ND"; break;
                    case 3: rankString = "3RD"; break;
                }

                Debug.Log($"{position} - {name} - {score},");
                if(position == 1)
                {
                    row.rank.color = Color.green;
                    row.name.color = Color.green;
                    row.score.color = Color.green;
                }

                row.rank.text = rankString;
                row.name.text = score;
                row.score.text = name;

                switch (position)
                {
                    default:
                        row.trophy.enabled = false;
                        break;
                    case 1:
                        row.trophy.color = colorCase1;
                        break;
                    case 2:
                        row.trophy.color = colorCase2;
                        break;
                    case 3:
                        row.trophy.color = colorCase3;
                        break;

                }

            }
        }

    }

    void DeleteAllChildren()
    {
        foreach (Transform child in tableContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }


}
