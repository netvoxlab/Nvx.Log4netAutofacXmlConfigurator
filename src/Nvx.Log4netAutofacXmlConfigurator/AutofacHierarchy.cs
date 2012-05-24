using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using log4net.Appender;
using log4net.Core;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using log4net.Util;

namespace Nvx.Log4netAutofacXmlConfigurator
{
	public class AutofacHierarchy : Hierarchy, IXmlRepositoryConfigurator
	{
		private readonly IComponentContext _context;

		public AutofacHierarchy(IComponentContext context)
		{
			_context = context;
		}

		#region Implementation of IXmlRepositoryConfigurator

		/// <summary>
		/// Initialize the log4net system using the specified config
		/// </summary>
		/// <param name="element">the element containing the root of the config</param>
		void IXmlRepositoryConfigurator.Configure(System.Xml.XmlElement element)
		{
			XmlRepositoryConfigure(element);
		}

		/// <summary>
		/// Initialize the log4net system using the specified config
		/// </summary>
		/// <param name="element">the element containing the root of the config</param>
		/// <remarks>
		/// <para>
		/// This method provides the same functionality as the 
		/// <see cref="IBasicRepositoryConfigurator.Configure(IAppender)"/> method implemented
		/// on this object, but it is protected and therefore can be called by subclasses.
		/// </para>
		/// </remarks>
		protected void XmlRepositoryConfigure(System.Xml.XmlElement element)
		{
			ArrayList configurationMessages = new ArrayList();

			using (new LogLog.LogReceivedAdapter(configurationMessages))
			{
				XmlHierarchyConfigurator config = new XmlHierarchyConfigurator(_context,this);
				config.Configure(element);
			}

			Configured = true;

			ConfigurationMessages = configurationMessages;

			// Notify listeners
			OnConfigurationChanged(new ConfigurationChangedEventArgs(configurationMessages));
		}

		#endregion Implementation of IXmlRepositoryConfigurator
	}
}
