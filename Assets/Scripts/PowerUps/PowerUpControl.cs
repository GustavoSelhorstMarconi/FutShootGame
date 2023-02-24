using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUpControl : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private List<GameObject> powerUps;

    [Header("Configurations")]
    [SerializeField]
    private UnityEvent OnIncreaseBallSizeTakePowerUp;
    [SerializeField]
    private UnityEvent OnDecreaseBallSizeTakePowerUp;
    [SerializeField]
    private float minTimeNewPowerUp;
    [SerializeField]
    private float maxTimeNewPowerUp;
    [SerializeField]
    private float minValueXPosition;
    [SerializeField]
    private float maxValueXPosition;
    [SerializeField]
    private float minValueYPosition;
    [SerializeField]
    private float maxValueYPosition;

    private void Start()
    {
        Invoke(nameof(ActiveNewPowerUp), minTimeNewPowerUp);
    }

    private void ActiveNewPowerUp()
    {
        int indexPowerUp = Random.Range(0, powerUps.Count);

        Vector2 positionPowerUp = new Vector2(Random.Range(minValueXPosition, maxValueXPosition), Random.Range(minValueYPosition, maxValueYPosition));
        GameObject powerUp = Instantiate(powerUps[indexPowerUp], positionPowerUp, Quaternion.identity);

        if (powerUp.TryGetComponent<IncreaseBallSize>(out IncreaseBallSize increaseBallSize))
        {
            increaseBallSize.SetPowerUpControl(this);
        }
        if (powerUp.TryGetComponent<DecreaseBallSize>(out DecreaseBallSize decreaseBallSize))
        {
            decreaseBallSize.SetPowerUpControl(this);
        }

        powerUp.SetActive(true);

        float timeNewPowerUp = Random.Range(minTimeNewPowerUp, maxTimeNewPowerUp);
        Invoke(nameof(ActiveNewPowerUp), timeNewPowerUp);
    }

    public void CallPowerUp(GameObject powerUp)
    {
        if (powerUp.GetComponent<IncreaseBallSize>())
        {
            OnIncreaseBallSizeTakePowerUp?.Invoke();
        }
        else if (powerUp.GetComponent<DecreaseBallSize>())
        {
            OnDecreaseBallSizeTakePowerUp?.Invoke();
        }
    }
}