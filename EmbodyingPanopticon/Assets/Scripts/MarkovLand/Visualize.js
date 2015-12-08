public var Audio : AudioListener;

public var colorStart : Color = Color.red;
public var colorEnd : Color = Color.green;
public var duration : float = 1.0;

public var balls : GameObject[];
public var ball2 : GameObject;
public var pointLight : Light;
public var channel : int = 1;
public var numSamples : int = 256;
public var freq : int =1;
public var number = new Array ();

function Update () {    

var number = Audio.GetSpectrumData(numSamples, channel, FFTWindow.Hanning);

for (var i:int=0;i<balls.Length;i++)
{
balls[i].transform.localScale.y = 1 + Mathf.Sqrt(number[i*freq]) * 5;
balls[i].transform.localScale.x = 1 + Mathf.Sqrt(number[i*freq]) * 5;
balls[i].transform.localScale.z = 1 + Mathf.Sqrt(number[i*freq]) * 5;
}

Camera.main.fieldOfView = 60 + number[0] * 15;
pointLight.GetComponent.<Light>().intensity = 0.7 + number[freq] * 1.2;

var lerp : float = Mathf.PingPong (number[freq], duration) / duration;
ball2.GetComponent.<Renderer>().material.color = Color.Lerp (colorStart, colorEnd, lerp);
}