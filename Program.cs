using System;
using System.Threading;
using Org.Kevoree.Annotation;
using Org.Kevoree.Core.Api;
using Org.Kevoree;


namespace Org.Kevoree.YieldVersion
{

	[ComponentType]
    [Serializable]
    class YieldVersion : MarshalByRefObject, DeployUnit
	{
		private bool StopMe;
		private readonly string VERSION = "7.0.4";
		private Log.Log logger = Log.LogFactory.getLog (typeof(YieldVersion).ToString (), Log.Level.DEBUG, "YieldVersion");

        [Param]
        private String paramUseless1;

        [Param(Optional=false)]
        private byte paramUseless2;

        [Param(FragmentDependent=true)]
        private long paramUseless3;

        [Param(DefaultValue="okok")]
        private string paramUseless4;

		[Output]
		private Port port;

		[Start]
		public void Start ()
		{
			StopMe = false;
			Thread t = new Thread (new ThreadStart (new YieldVersion ().Run));
			logger.Debug (VERSION + " - Start");
            paramUseless1 = "";
            paramUseless2 = 0;
            paramUseless3 = 12;
            paramUseless4 = "pasokpasok";

            Console.Write(paramUseless1 + paramUseless2 + paramUseless3 + paramUseless4);
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
