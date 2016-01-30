using UnityEngine;
using System.Collections;

public class ccArduinoDispatcher : MonoBehaviour
{
	public string oscHost = "127.0.0.1";
	public int SendToPort = 12000;
	public int ListenerPort = 32000;
	public string address = "/arduino";

	public int channels = 4;
	public string eventPrefix = "a";
	public bool debug = false;

	UDPPacketIO udp;
	Osc handler;
	bool enabled = false;

	// Use this for initialization
	void OnEnable (){
		if (!debug) {
			udp = gameObject.AddComponent<UDPPacketIO> ();
			handler = gameObject.AddComponent<Osc> ();
		
			udp.init (oscHost, SendToPort, ListenerPort);
			handler.init (udp);
			handler.SetAddressHandler (address, Message);
			enabled = true;
		}
	}

	void Update(){
		if (debug) {
			if(Input.GetKey(KeyCode.Space)){
				Messenger.Broadcast<float>("a0",Input.mousePosition.x/Screen.width);
				Messenger.Broadcast<float>("a1",0);
				Messenger.Broadcast<float>("a2",Input.mousePosition.y/Screen.height);
			}
		}
	}

	void Message (OscMessage msg){
		if (!enabled)
			return;
		int min = Mathf.Max (msg.Values.Count, channels);
		for (int i = 0; i<min; i++) {
			Messenger.Broadcast<float>(eventPrefix+i,float.Parse(""+msg.Values[i])/1023.0f);
			Debug.Log((eventPrefix+i)+"   "+(float.Parse(""+msg.Values[i])/1023.0f));
		}
	}
}

