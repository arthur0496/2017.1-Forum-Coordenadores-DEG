﻿using NUnit.Framework;
using System;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;


namespace Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests {
        IApp app;
        Platform platform;

        public Tests(Platform platform) {
            this.platform = platform;

        }

        [SetUp]
        public void BeforeEachTest() {
            app = AppInitializer.StartApp(platform);
            app.WaitForElement("ImBackgroundLoginPage");
        }

        [Test]
        public void LoginCoordinatorSuccess() {
            app.EnterText("EtRegistrationLoginPage", "123456789");
            app.EnterText("EtPasswordLoginPage", "Pb1234567");
            app.Tap("BtLoginLoginPage");
            app.WaitForNoElement("BtLoginLoginPage");
            Assert.IsNotNull(app.Query("Início"));
            //app.Repl();
        }

        [Test]
        public void LoginAdministratorSuccess() {
            app.EnterText("EtRegistrationLoginPage", "12345678");
            app.EnterText("EtPasswordLoginPage", "Pb1234567");
            app.Tap("BtLoginLoginPage");

            app.WaitForNoElement("BtLoginLoginPage");
            Assert.IsNotNull(app.Query("Formulários"));
        }

        [Test]
        public void LoginFailureBlankSpaces() {
            app.Tap("BtLoginLoginPage");
            Assert.IsNotNull("OK");
        }

        [Test]
        public void LoginFailure() {
            app.EnterText("EtRegistrationLoginPage", "987654321");
            app.EnterText("EtPasswordLoginPage", "Pb1234567");
            app.Tap("BtLoginLoginPage");
            Assert.IsNotNull("OK");
        }
    }
}
