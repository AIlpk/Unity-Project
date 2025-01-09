using UnityEngine;


public class Goal : MonoBehaviour
{
	private bool m_isGoal;
	private void OnTriggerEnter2D( Collider2D other )
	{
		
		if ( !m_isGoal )
		{
			if ( other.name.Contains( "Player" ) )
			{				
				var cameraShake = FindObjectOfType<CameraShaker>();
				cameraShake.Shake();
				m_isGoal = true;
				var animator = GetComponent<Animator>();
				animator.Play( "Pressed" );
			}
			if(other.name.Contains("Player"))
            {
				var player = other.GetComponent<Player>();
				player.Win();
            }
		}
	}
}