using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using log4net.Appender;
using log4net.Core;

namespace Nvx.Log4netAutofacXmlConfigurator.Sample
{
	public class SampleAppender : AppenderSkeleton
	{
		private readonly IComponentContext _componentContext;

		public SampleAppender(IComponentContext componentContext)
		{
			_componentContext = componentContext;
		}

		protected override void Append(LoggingEvent loggingEvent)
		{
			
		}
	}
}
