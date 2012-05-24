Nvx.Log4netAutofacXmlConfigurator
=================================

Implementation of log4net configurator using autofac.

Sample implemetation:

using Autofac;
using Autofac.Configuration;
using log4net;
using log4net.Core;
using Nvx.Log4netAutofacXmlConfigurator;

//  ....

_builder = new ContainerBuilder();
_builder.RegisterModule(new ConfigurationSettingsReader());
_builder.RegisterType<RepositorySelector>().As<IRepositorySelector>().SingleInstance();
_container = _builder.Build();

LoggerManager.RepositorySelector = _container.Resolve<IRepositorySelector>();
_container.CreateInstance<XmlConfigurator>().Configure();

var logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
logger.Debug("haha!");