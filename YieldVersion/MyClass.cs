using System;
using System.Threading;
using Org.Kevoree.Annotation;
using Org.Kevoree.Core.Api;

namespace Org.Kevoree.YieldVersion
{
	[ComponentType]
	class YieldVersion
	{

		private readonly string Version = "1.0.0";

		[Output]
		private readonly Port tick;

		[Start]
		public void Start ()
		{
			Thread thd = new Thread (new ThreadStart (new YieldVersion ().Run));	
			thd.Start ();
		}

		public void Run ()
		{
			while (true) {
				Console.WriteLine (Version);
				Thread.Sleep (1000);
			}
		}
	}
}