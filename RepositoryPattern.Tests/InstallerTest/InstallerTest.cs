using Castle.Windsor;
using FacadePattern;
using NUnit.Framework;

namespace RepositoryPattern.Tests.InstallerTest
{
    [TestFixture]
    internal class InstallerTest
    {   
        [Test]
        public void CreateContainer_Install_ClassesImplementingIFacadeClass()
        {
            var container = new WindsorContainer();
            container.Install(new FacadeInstaller());

            var facade = container.Resolve<IFacadeClass>();

            Assert.IsNotNull(facade);
            Assert.AreEqual(typeof(FacadeClass), facade.GetType());
        }
    }
}
