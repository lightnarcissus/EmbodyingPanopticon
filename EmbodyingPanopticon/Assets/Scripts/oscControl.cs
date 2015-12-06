//
//	  UnityOSC - Example of usage for OSC receiver
//
//	  Copyright (c) 2012 Jorge Garcia Martin
//
// 	  Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// 	  documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// 	  the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
// 	  and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// 	  The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// 	  of the Software.
//
// 	  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// 	  TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// 	  THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// 	  CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// 	  IN THE SOFTWARE.
//

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityOSC;
//using UnityStandardAssets.CrossPlatformInput;
//using UnityStandardAssets.Utility;

public class oscControl : MonoBehaviour {
	
	private Dictionary<string, ServerLog> servers;
	private Dictionary<string, ClientLog> clients;
	private float randVal=0f;
	private String msg="";

    public static float accX = 0f;
	// Script initialization
	void Start() {	
		Cursor.visible = false;
		OSCHandler.Instance.Init(); //init OSC
		servers = new Dictionary<string, ServerLog>();
		clients = new Dictionary<string,ClientLog> ();
        servers = OSCHandler.Instance.Servers;
        clients = OSCHandler.Instance.Clients;

		//initiator message
		OSCHandler.Instance.SendMessageToClient("localhost", "blah",2f);

       
		OSCHandler.Instance.UpdateLogs();

	}

	// NOTE: The received messages at each server are updated here
    // Hence, this update depends on your application architecture
    // How many frames per second or Update() calls per frame?
	void Update() {
		
		OSCHandler.Instance.UpdateLogs();
        //		if (UnityEngine.Random.value < 0.3f) {
        //			randVal = UnityEngine.Random.Range (0f, 0.7f);
        //			//OSCHandler.Instance.SendMessageToClient ("iPad Client", "/Visuals/fader2", 8f);
        //		}
        //OSCHandler.Instance.UpdateLogs();

        foreach (KeyValuePair<string, ServerLog> item in servers)
        {
            // If we have received at least one packet,
            // show the last received from the log in the Debug console
            if (item.Value.log.Count > 0)
            {
                int lastPacketIndex = item.Value.packets.Count - 1;
             //   int beforeLastPacketIndex = item.Value.packets.Count - 2;

                /*	UnityEngine.Debug.Log (String.Format ("SERVER: {0} ADDRESS: {1} VALUE : {2}", 
                                                            item.Key, // Server name
                                                            item.Value.packets [lastPacketIndex].Address, // OSC address
                                                            item.Value.packets [lastPacketIndex].Data [0].ToString ())); //First data value
                    */
                //				Debug.Log ("last one: "+item.Value.packets[lastPacketIndex].Address);
                //				Debug.Log ("one before that: "+item.Value.packets[beforeLastPacketIndex].Address);
                //{
                float tempVal = float.Parse(item.Value.packets[lastPacketIndex].Data[0].ToString());

                //critic section begins
                if (item.Value.packets[lastPacketIndex].Address == "/accxyz") //accelerometer XYZ
                {

                    accX = tempVal;

                }

            }
        }
			

		foreach( KeyValuePair<string, ClientLog> item in clients )
		{
			// If we have sent at least one message,
			// show the last sent message from the log in the Debug console
			if(item.Value.log.Count > 0) 
			{
				int lastMessageIndex = item.Value.messages.Count- 1;
				
//				UnityEngine.Debug.Log(String.Format("CLIENT: {0} ADDRESS: {1} VALUE 0: {2}", 
//				                                    item.Key, // Server name
//				                                    item.Value.messages[lastMessageIndex].Address, // OSC address
//				                                    item.Value.messages[lastMessageIndex].Data[0].ToString())); //First data value
//				                                    
			}

		}
	}
 
    
}