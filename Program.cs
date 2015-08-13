using System;
using System.Threading;
using Org.Kevoree.Annotation;
using Org.Kevoree.Core.Api;

namespace Org.Kevoree.YieldVersion
{



	[ComponentType]
    class YieldVersion
    {

		[Output]
		private Port port;

		[Start]
		public void Start() {
			Thread t = new Thread(new ThreadStart(new YieldVersion().Run));


			t.Start ();
		}

		public void Run() {
			while (true) {
				port.send("1.0.0", null);
			}
		}
    }
}
