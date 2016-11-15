using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Magicolo;

namespace Magicolo {
	public class PureDataSequence_NoteTwo : MonoBehaviour {

		PureDataSequenceItem sequenceItem;
		Vector2 scroll;
		
		void OnGUI() {
			GUILayout.Label("Current Item: " + (sequenceItem == null ? "None" : sequenceItem.ToString()));
		
			GUILayout.Space(128);
		
			scroll = GUILayout.BeginScrollView(scroll, GUILayout.Width(Screen.width - 50));
		
			GUILayout.Label("Plays the Note_Two");
			if (GUILayout.Button("Play")) {
				sequenceItem = PureData.PlaySequence("Note_Two");
			}
				
			GUILayout.Space(8);
		
			if (sequenceItem != null) {
				GUILayout.Label("Stops the sequence if it is still playing.");
				if (GUILayout.Button("Stop")) {
					sequenceItem.Stop();
					sequenceItem = null;
				}
			}
		
			GUILayout.EndScrollView();
		}
	}
}