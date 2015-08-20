using System;
using System.Threading;
using Org.Kevoree.Annotation;
using Org.Kevoree.Core.Api;
using Org.Kevoree;


namespace Org.Kevoree.YieldVersion
{

	[ComponentType]
	class YieldVersion
	{
		private bool StopMe;
		private readonly string VERSION = "3.0.0";
		private Log.Log logger = Log.LogFactory.getLog (typeof(YieldVersion).ToString (), Log.Level.DEBUG, "YieldVersion");

		[Output]
		private Port port;

		[Start]
		public void Start ()
		{
			StopMe = false;
			Thread t = new Thread (new ThreadStart (new YieldVersion ().Run));
			logger.Debug (VERSION + " - Start");
			t.Start ();
		}

		[Stop]
		public void Stop ()
		{
			this.StopMe = true;
			logger.Debug (VERSION + " - Stop");
		}

		[Update]
		public void Update ()
		{
			logger.Debug (VERSION + " - Update");
		}

		public void Run ()
		{
			logger.Debug (VERSION + " - Thread started");
			while (!StopMe) {
				port.send (VERSION, null);
				logger.Debug (VERSION + " - YIELD");
			}
			logger.Debug (VERSION + " - Thread finished");
		}
	}
}
