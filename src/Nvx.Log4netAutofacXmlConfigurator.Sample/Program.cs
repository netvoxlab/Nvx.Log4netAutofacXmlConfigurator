using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Configuration;
using log4net;
using log4net.Core;

namespace Nvx.Log4netAutofacXmlConfigurator.Sample
{
	class Program
	{
		private static ContainerBuilder _builder;
		private static IContainer _container;

		static void Main(string[] args)
		{
			_builder = new ContainerBuilder();
			_builder.RegisterModule(new ConfigurationSettingsReader());
			_builder.RegisterType<RepositorySelector>().As<IRepositorySelector>().SingleInstance();
			_container = _builder.Build();

			//LoggerManager.RepositorySelector = new 
			LoggerManager.RepositorySelector = _container.Resolve<IRepositorySelector>();
			_container.CreateInstance<XmlConfigurator>().Configure();

			var logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
			logger.Debug("haha!");
		}
	}
}
