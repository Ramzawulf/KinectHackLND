using UnityEngine;
using System.Collections;

public class TestCube : MonoBehaviour
{
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		if (stream.isWriting)
		{
			Vector3 myPosition = transform.position;
			stream.Serialize(ref myPosition);
		}
		else
		{
			Vector3 receivedPosition = Vector3.zero;
			stream.Serialize(ref receivedPosition); //"Decode" it and receive it
			transform.position = receivedPosition;
		}
	}
}
 