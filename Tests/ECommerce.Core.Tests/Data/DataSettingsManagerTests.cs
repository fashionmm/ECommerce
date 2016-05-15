using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.Data;
using NUnit.Framework;
using Rhino.Mocks;

namespace ECommerce.Core.Data.Tests
{
    [TestFixture()]
    public class DataSettingsManagerTests
    {
        [Test()]
        public void LoadSettingsTest()
        {
            var dataSettingManager = new DataSettingsManager();
            var webhelper = MockRepository.GenerateMock<IWebHelper>();
        
            Assert.Fail();
        }

        [Test()]
        public void SaveSettingsTest()
        {
            Assert.Fail();
        }
    }
}
