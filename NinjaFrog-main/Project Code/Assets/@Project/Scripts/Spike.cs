using UnityEngine;


public class Spike : MonoBehaviour
{

	private void OnTriggerEnter2D( Collider2D other )
	{
		if ( other.name.Contains( "Player" ) )
		{
			var player = other.GetComponent<Player>();
			player.Dead();
		}
        if (other.gameObject.CompareTag("Button"))
        {
			Destroy(gameObject);
        }
	}
}