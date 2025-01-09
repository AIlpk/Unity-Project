using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
	public GameObject m_playerHitPrefab;
	public bool IsSkipJumpSe;
	GameController gc;
    private void Start()
    {
		gc = FindObjectOfType<GameController>();
    }

    public void Dead()
	{
		gameObject.SetActive( false );
		var cameraShake = FindObjectOfType<CameraShaker>();
		cameraShake.Shake();
		Instantiate
		(
			m_playerHitPrefab,
			transform.position,
			Quaternion.identity
		);
		gc.SetGameoverState(true);
	}
	private void Awake()
	{	
		var motor = GetComponent<PlatformerMotor2D>();
		motor.onJump += OnJump;
	}
	private void OnJump()
	{
		if ( IsSkipJumpSe )
		{	
			IsSkipJumpSe = false;
		}
	
	}
	public void Win()
    {
		gameObject.SetActive(false);
		gc.SetgameWinState(true);

    }
}