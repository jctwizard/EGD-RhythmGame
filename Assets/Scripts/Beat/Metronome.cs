using UnityEngine;
using System.Collections;

// The sections which have been commented out can be added in to get a metronome 'click' backing which can be helpful for checking events are 'on the beat'

[RequireComponent(typeof(AudioSource))]
public class Metronome : MonoBehaviour
{
	public double bpm = 130.0F;			// Beats per minute of the audio

	public int signatureHi = 16;		// Upper half of time signature
	public int signatureLo = 16;		// Lower half of time signature
	public int measure = 0;				// Bar count
	private double nextTick = 0.0F;		// Next tick

	//public float gain = 0.5F;			// the gain of the tick
	//private float amp = 0.0F;			// the amplitude of the tick
	//private float phase = 0.0F;			// the phase of the tick

	private double sampleRate = 0.0F;	// Sample Rate

	private int accent;					// The beat count
	public int Accent
	{get {return accent;}}
	private bool running = false;
	
	public void SetRunning(bool run)
	{
		accent = signatureHi;
		double startTick = AudioSettings.dspTime;
		sampleRate = AudioSettings.outputSampleRate;
		nextTick = startTick * sampleRate;
		running = run;
	}

	void OnAudioFilterRead(float[] data, int channels)
	{
		if (!running)
			return;
		
		double samplesPerTick = sampleRate * 60.0F / bpm * 4.0F / signatureLo;
		double sample = AudioSettings.dspTime * sampleRate;

		int dataLen = data.Length / channels;
		int n = 0;
		while (n < dataLen)
		{
			//float x = gain * amp * Mathf.Sin(phase);
			//int i = 0;
			//while (i < channels)
			//{
			//	data[n * channels + i] += x;
			//	i++;
			//}
			while (sample + n >= nextTick)
			{
				nextTick += samplesPerTick;
			//	amp = 1.0F;
				if (++accent > signatureHi)
				{
					accent = 1;
			//		amp *= 2.0F;
					measure++;
				}
				Debug.Log("Tick: " + accent + "/" + signatureHi);
			}
			//phase += amp * 0.3F;
			//amp *= 0.993F;
			n++;
		}
	}
}

