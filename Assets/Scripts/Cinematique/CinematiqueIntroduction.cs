using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.WSA;
using UnityEngine.SceneManagement;

public class CinematiqueIntroduction : MonoBehaviour
{
    private bool isLeaderFranceMoveUp = false;
    private bool isLeaderEspagneMoveUp = false;
    private bool isLeaderSaintEmpireMoveUp = false;
    private bool isLeaderAngleterreMoveUp = false;
    private bool isLeaderPortugalMoveUp = false;
    private bool isLeaderEcosseMoveUp = false;
    private bool isLeaderDanemarkNorvegeMoveUp = false;
    private bool isLeaderSuedeMoveUp = false;
    private bool isLeaderPologneMoveUp = false;
    private bool isLeaderRussieMoveUp = false;
    private bool isCastleMoveUp = false;
    private bool isHammerMoveUp = false;

    private double FranceMoveUpStop = 6.15;
    private double EspagneMoveUpStop = 3.53;
    private double SaintEmpireMoveUpStop = 7.97;
    private double AngleterreMoveUpStop = 7.11;
    private double PortugalMoveUpStop = 3.61;
    private double EcosseMoveUpStop = 14.52;
    private double DanemarkNorvegeMoveUpStop = 10.42;
    private double SuedeMoveUpStop = 16.01;
    private double PologneMoveUpStop = 9.27;
    private double RussieMoveUpStop = 9.2;
    private double CastleMoveUpStop = 0.356; //0.126  0.571
    private double HammerMoveUpStop = 3.75;

    private bool isLeaderFranceMoveDown = false;
    private bool isLeaderEspagneMoveDown = false;
    private bool isLeaderSaintEmpireMoveDown = false;
    private bool isLeaderAngleterreMoveDown = false;
    private bool isLeaderPortugalMoveDown = false;
    private bool isLeaderEcosseMoveDown = false;
    private bool isLeaderDanemarkNorvegeMoveDown = false;
    private bool isLeaderSuedeMoveDown = false;
    private bool isLeaderPologneMoveDown = false;
    private bool isLeaderRussieMoveDown = false;
    private bool isCastleMoveDown = false;

    private bool isLightOff = false;
    public float fadeDuration = 1f;
    private float initialIntensity;
    private float targetIntensity = 0f;
    private float timerLight = 0f;

    private Vector3 carteOnGround = new Vector3(2.84f, -1.84f, 1.22f);
    private float moveMapStartTime;
    private bool isMovingMapToGround;

    private int frame = 0;
    private int intervalStartMovingUp = 100;

    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float pushDistance = 0.5f;

    [SerializeField] private GameObject hammer;
    [SerializeField] private GameObject castle;
    [SerializeField] private GameObject carte;
    [SerializeField] private GameObject leaderFrance;
    [SerializeField] private GameObject leaderEspagne;
    [SerializeField] private GameObject leaderSaintEmpire;
    [SerializeField] private GameObject leaderAngleterre;
    [SerializeField] private GameObject leaderPortugal;
    [SerializeField] private GameObject leaderEcosse;
    [SerializeField] private GameObject leaderDanemarkNorvege;
    [SerializeField] private GameObject leaderSuede;
    [SerializeField] private GameObject leaderPologne;
    [SerializeField] private GameObject leaderRussie;
    [SerializeField] private Light light;

    // Start is called before the first frame update
    void Start()
    {
        initialIntensity = light.intensity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frame++;

        MoveUp(leaderFrance, isLeaderFranceMoveUp);
        MoveUp(leaderEspagne, isLeaderEspagneMoveUp);
        MoveUp(leaderSaintEmpire, isLeaderSaintEmpireMoveUp);
        MoveUp(leaderAngleterre, isLeaderAngleterreMoveUp);
        MoveUp(leaderPortugal, isLeaderPortugalMoveUp);
        MoveUp(leaderEcosse, isLeaderEcosseMoveUp);
        MoveUp(leaderDanemarkNorvege, isLeaderDanemarkNorvegeMoveUp);
        MoveUp(leaderSuede, isLeaderSuedeMoveUp);
        MoveUp(leaderPologne, isLeaderPologneMoveUp);
        MoveUp(leaderRussie, isLeaderRussieMoveUp);

        MoveDown(leaderFrance, isLeaderFranceMoveDown);
        MoveDown(leaderEspagne, isLeaderEspagneMoveDown);
        MoveDown(leaderSaintEmpire, isLeaderSaintEmpireMoveDown);
        MoveDown(leaderAngleterre, isLeaderAngleterreMoveDown);
        MoveDown(leaderPortugal, isLeaderPortugalMoveDown);
        MoveDown(leaderEcosse, isLeaderEcosseMoveDown);
        MoveDown(leaderDanemarkNorvege, isLeaderDanemarkNorvegeMoveDown);
        MoveDown(leaderSuede, isLeaderSuedeMoveDown);
        MoveDown(leaderPologne, isLeaderPologneMoveDown);
        MoveDown(leaderRussie, isLeaderRussieMoveDown);


        MoveUp(castle, isCastleMoveUp);
        MoveDown(castle, isCastleMoveDown);
        MoveUp(hammer, isHammerMoveUp);

        HandleFrame();

        MoveMapToGround();

        LightOff();
    }

    private void LightOff()
    {
        if (isLightOff)
        {
            // Calculer la nouvelle intensité en fonction du temps écoulé
            float normalizedTime = timerLight / fadeDuration;
            float newIntensity = Mathf.Lerp(initialIntensity, targetIntensity, normalizedTime);

            // Appliquer la nouvelle intensité à la lumière directionnelle
            light.intensity = newIntensity - 1f;

            // Mettre à jour le temps écoulé
            timerLight += Time.deltaTime;
        }
    }

    private void HandleFrame()
    {
        if (frame == 1)
        {
            isLeaderRussieMoveUp = true;
        }

        if (frame == intervalStartMovingUp)
        {
            isLeaderPologneMoveUp = true;
        }

        if (frame == intervalStartMovingUp * 2)
        {
            isLeaderSuedeMoveUp = true;
        }

        if (frame == intervalStartMovingUp * 3)
        {
            isLeaderDanemarkNorvegeMoveUp = true;
        }

        if (frame == intervalStartMovingUp * 4)
        {
            isLeaderEcosseMoveUp = true;
        }

        if (frame == intervalStartMovingUp * 5)
        {
            isLeaderAngleterreMoveUp = true;
        }

        if (frame == intervalStartMovingUp * 6)
        {
            isLeaderPortugalMoveUp = true;
        }

        if (frame == intervalStartMovingUp * 10)
        {
            isLeaderPologneMoveDown = true;
            isLeaderRussieMoveDown = true;
            isLeaderPortugalMoveDown = true;
            isLeaderAngleterreMoveDown = true;
            isLeaderEcosseMoveDown = true;
            isLeaderDanemarkNorvegeMoveDown = true;
            isLeaderSuedeMoveDown = true;

            isLeaderEspagneMoveUp = true;
            isLeaderSaintEmpireMoveUp = true;
        }

        if (frame == intervalStartMovingUp * 11)
        {
            isLeaderFranceMoveUp = true;
        }

        if (frame == intervalStartMovingUp * 14)
        {
            moveMapStartTime = Time.time;
            isMovingMapToGround = true;
        }

        if (frame == intervalStartMovingUp * 15)
        {
            isCastleMoveUp = true;
            isHammerMoveUp = true;
            isLightOff = true;
        }

        if (frame == intervalStartMovingUp * 17)
        {
            isLeaderFranceMoveDown = true;
            isLeaderEspagneMoveDown = true;
            isLeaderSaintEmpireMoveDown = true;
            isCastleMoveDown = true;
        }

        if (frame == intervalStartMovingUp * 21)
        {
            SceneManager.LoadScene("Index");
        }
    }

    private void MoveUp(GameObject objet, bool isMoving)
    {
        if (isMoving)
        {
            objet.transform.position = Vector3.MoveTowards(objet.transform.position,
                objet.transform.position + new Vector3(0, 1, 0), speed * Time.deltaTime);
            if (IsStopMovingUp(objet.name, objet.transform.position.y))
            {
                StopMovingUp(objet.name);
            }
        }
    }

    private void MoveMapToGround()
    {
        if (isMovingMapToGround)
        {
            float moveDuration = 20.0f;
            float fraction = (Time.time - moveMapStartTime) / moveDuration;

            carte.transform.position = Vector3.Lerp(carte.transform.position, carteOnGround, fraction);

            Quaternion targetRotation = Quaternion.Euler(0, carte.transform.rotation.eulerAngles.y, 0);
            carte.transform.rotation = Quaternion.Lerp(carte.transform.rotation, targetRotation, fraction);

            if (fraction >= 1)
            {
                isMovingMapToGround = false;
            }
        }
    }

    private bool IsStopMovingUp(string objet, float y)
    {
        switch (objet)
        {
            case "France" when y > FranceMoveUpStop:
            case "Espagne" when y > EspagneMoveUpStop:
            case "SaintEmpire" when y > SaintEmpireMoveUpStop:
            case "Angleterre" when y > AngleterreMoveUpStop:
            case "Portugal" when y > PortugalMoveUpStop:
            case "Ecosse" when y > EcosseMoveUpStop:
            case "DanemarkNorvege" when y > DanemarkNorvegeMoveUpStop:
            case "Suede" when y > SuedeMoveUpStop:
            case "Pologne" when y > PologneMoveUpStop:
            case "Russie" when y > RussieMoveUpStop:
            case "Castle" when y > CastleMoveUpStop:
            case "Hammer" when y > HammerMoveUpStop:
                return true;
            default:
                return false;
        }
    }

    private void StopMovingUp(string objet)
    {
        switch (objet)
        {
            case "France":
                isLeaderFranceMoveUp = false;
                break;
            case "Espagne":
                isLeaderEspagneMoveUp = false;
                break;
            case "SaintEmpire":
                isLeaderSaintEmpireMoveUp = false;
                break;
            case "Angleterre":
                isLeaderAngleterreMoveUp = false;
                break;
            case "Portugal":
                isLeaderPortugalMoveUp = false;
                break;
            case "Ecosse":
                isLeaderEcosseMoveUp = false;
                break;
            case "DanemarkNorvege":
                isLeaderDanemarkNorvegeMoveUp = false;
                break;
            case "Suede":
                isLeaderSuedeMoveUp = false;
                break;
            case "Pologne":
                isLeaderPologneMoveUp = false;
                break;
            case "Russie":
                isLeaderRussieMoveUp = false;
                break;
            case "Castle":
                isCastleMoveUp = false;
                break;
            case "Hammer":
                isHammerMoveUp = false;
                break;
        }
    }


    private void MoveDown(GameObject objet, bool isMovingDown)
    {
        if (isMovingDown)
        {
            objet.transform.position = Vector3.MoveTowards(objet.transform.position,
                objet.transform.position + new Vector3(0, -1, 0), speed * 2 * Time.deltaTime);
            if (IsStopMovingDown(objet.name, objet.transform.position.y))
            {
                StopMovingDown(objet.name);
            }
        }
    }

    private bool IsStopMovingDown(string objet, float y)
    {
        if (y < -10.5)
        {
            return true;
        }

        return false;
    }

    private void StopMovingDown(string objet)
    {
        switch (objet)
        {
            case "France":
                isLeaderFranceMoveDown = false;
                break;
            case "Espagne":
                isLeaderEspagneMoveDown = false;
                break;
            case "SaintEmpire":
                isLeaderSaintEmpireMoveDown = false;
                break;
            case "Angleterre":
                isLeaderAngleterreMoveDown = false;
                break;
            case "Portugal":
                isLeaderPortugalMoveDown = false;
                break;
            case "Ecosse":
                isLeaderEcosseMoveDown = false;
                break;
            case "DanemarkNorvege":
                isLeaderDanemarkNorvegeMoveDown = false;
                break;
            case "Suede":
                isLeaderSuedeMoveDown = false;
                break;
            case "Pologne":
                isLeaderPologneMoveDown = false;
                break;
            case "Russie":
                isLeaderRussieMoveDown = false;
                break;
            case "Castle":
                isCastleMoveDown = true;
                break;
        }
    }
}